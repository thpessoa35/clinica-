
using dapper;
using Dapper;
using HospitalSolution.Application.Common.Persistence;
using HospitalSolution.Domain.entities.Pacient;

using pacient;

namespace HospitalSolution.Infrastructure.DataBase
{
    public class DbPacientContext : IPacientRepository
    {
        private readonly DbContext _dbContext;
        public DbPacientContext(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Paciente pacient)
        {
            using (var db = _dbContext.CreateConnection())
            {
                await db.OpenAsync();

                string Query = @"INSERT INTO pacient (id, firstname, lastname, typeblood, cpf, phonenumber, created, updated)
                                              VALUES(@Id, @Firstname, @Lastname, @Typeblood , @Cpf, @Phonenumber,  @Created, @Updated);";

                await db.ExecuteAsync(Query, new
                {
                    pacient.Id.Id,
                    pacient.FirstName,
                    pacient.LastName,
                    pacient.TypeBlood,
                    pacient.Cpf,
                    pacient.PhoneNumber,
                    pacient.Created,
                    pacient.Updated,
                });

                string addressSql = @"
                        INSERT INTO Addresses (Address, City, State, ZipCode, Number, idpacient)
                        VALUES (@Address, @City, @State, @ZipCode, @Number, @Idpacient)";

                foreach (var address in pacient.Enderecos)
                {
                    await db.QueryAsync(addressSql, new
                    {
                        address.Id,
                        address.Address,
                        address.City,
                        address.State,
                        address.ZipCode,
                        address.Number,
                        Idpacient = pacient.Id.Id,
                    });
                }
            }
        }

        public async Task<Paciente?> FindById(string id)
        {
            using (var db = _dbContext.CreateConnection())
            {
                SqlMapper.AddTypeHandler(new PacientIdTypeHandler());
                await db.OpenAsync();

                string findId = "SELECT * FROM pacient WHERE id = @Id";




                return await db.QueryFirstOrDefaultAsync<Paciente>(findId, new { Id = id });


            }
        }


        public async Task<Paciente> Updated(string id, Paciente pacient)
        {
            using (var db = _dbContext.CreateConnection())
            {
                SqlMapper.AddTypeHandler(new PacientIdTypeHandler());

                await db.OpenAsync();

                var existingPaciente = await FindById(id);

                if (existingPaciente != null)
                {
                    string query = @" UPDATE pacient SET firstname = @FirstName, lastname = @LastName, typeblood = @TypeBlood, cpf = @Cpf, phonenumber = @PhoneNumber WHERE id = @Id";

                    await db.ExecuteAsync(query, new
                    {
                        Id = id,
                        pacient.FirstName,
                        pacient.LastName,
                        pacient.TypeBlood,
                        pacient.Cpf,
                        pacient.PhoneNumber
                    });
                }
            }
            return pacient;
        }
    }
}