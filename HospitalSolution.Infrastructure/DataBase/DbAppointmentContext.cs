
using System.ComponentModel.Design;
using dapper;
using Dapper;
using HospitalSolution.Application.Common.Persistence;
using HospitalSolution.Application.Common.Persistence.Queries;
using HospitalSolution.Domain.Appointment;
using HospitalSolution.Domain.Appointment.valueObject;
using HospitalSolution.Domain.entities.Pacient;
using HospitalSolution.Domain.Entities.Address.Entities;
using HospitalSolution.Domain.Entities.medic;
using HospitalSolution.Domain.Entities.Medic;
using pacient;

namespace HospitalSolution.Infrastructure.DataBase
{
    public class DbAppointmentContext : IAppointmentRepository, IGetByIdAppointment
    {
        private readonly DbContext _context;

        public DbAppointmentContext(DbContext context)
        {
            _context = context;
        }

        public async Task Add(Appointment appointment)
        {


            using (var db = _context.CreateConnection())
            {
                string query = "INSERT INTO appointment (id, status, description, medicid, pacientid, date) VALUES (@Id, @Status, @Description, @Medicid, @Pacientid, @date)";

                await db.QueryAsync<Appointment>(query, new
                {
                    appointment.Id.Id,
                    appointment.Status,
                    appointment.Description,
                    MedicId = appointment.MedicId.Id,
                    PacientId = appointment.PacientId.Id,
                    Date = appointment.Date
                });


            }
        }

        public Task<Appointment?> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Appointment>> GetDateAppointment(DateTime date)
        {
            SqlMapper.AddTypeHandler(new AppointmentIdTypeHandler());
            SqlMapper.AddTypeHandler(new MedicIdTypeHandler());
            SqlMapper.AddTypeHandler(new PacientIdTypeHandler());

            using (var db = _context.CreateConnection())
            {
                await db.OpenAsync();

                string query = @"
                SELECT a.*, p.*, m.id, m.firstname, m.lastname, m.email, m.phonenumber
                FROM appointment AS a
                INNER JOIN pacient AS p ON a.pacientid = p.id
                INNER JOIN medic AS m ON a.medicid = m.id
                WHERE DATE(a.date) = @Date";

                var appointments = await db.QueryAsync<Appointment, Paciente, Medic, Appointment>(
                    query,
                    (appointment, pacient, medic) =>
                    {
                        appointment.Pacient = pacient;
                        appointment.Medic = medic;
                        return appointment;
                    },
                    new { Date = date.Date },
                    splitOn: "id"
                );
                return appointments;
            }
        }


        public async Task<IEnumerable<Appointment>> GetManyAppointmentByIdMedic(string medicId)
        {
            using (var context = _context.CreateConnection())
            {

                SqlMapper.AddTypeHandler(new AppointmentIdTypeHandler());
                SqlMapper.AddTypeHandler(new PacientIdTypeHandler());


                var query = @"
            SELECT 
                a.id, a.status, a.description, 
                m.Id, m.firstname, m.lastname, m.phonenumber, 
                p.*,
                am.*, 
                ap.* 
            FROM 
                appointment AS a
            INNER JOIN 
                medic AS m ON a.medicid = m.id
            LEFT JOIN 
                pacient AS p ON a.pacientid = p.id
            LEFT JOIN 
                addresses AS am ON am.idmedic = m.id
            LEFT JOIN 
                addresses AS ap ON ap.idpacient = p.id
            WHERE 
                a.medicid = @MedicId;
        ";

                var appointments = await context.QueryAsync<Appointment, Medic, Paciente, MedicAddress, PacientAddress, Appointment>(
                    query, (appointment, medic, pacient, medicAddress, pacientAddress) =>
                    {
                        medic.Addresses = new List<MedicAddress> { medicAddress };
                        pacient.Enderecos = new List<PacientAddress> { pacientAddress };
                        appointment.Medic = medic;
                        appointment.Pacient = pacient;
                        return appointment;
                    },
                    new { MedicId = medicId },

                    splitOn: "id, id, id, id"
                );

                return appointments;
            }
        }
    }
}


