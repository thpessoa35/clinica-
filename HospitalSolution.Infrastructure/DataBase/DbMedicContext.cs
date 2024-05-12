
using AutoMapper;
using dapper;
using Dapper;
using HospitalSolution.Domain.Entities.medic;

using HospitalSolution.Domain.Entities.Medic;
using HospitalSolution.Infrastructure.Persistence;

namespace HospitalSolution.Infrastructure.DataBase
{
    public class DbMedicContext : IMedicRepository
    {
        private readonly DbContext _context;

        public DbMedicContext(DbContext context)
        {
            _context = context;
        }

        public async Task Add(Medic medic)
        {
            using (var db = _context.CreateConnection())
            {
                await db.OpenAsync();

                string Query = @"INSERT INTO medic (id, firstname, lastname, email, password, crmnumber, specialty, hospitalaffiliation, phonenumber, created, updated)
                               VALUES(@Id, @Firstname, @Lastname, @Email, @Password, @Crmnumber, @Specialty, @Hospitalaffiliation, @Phonenumber, @Created, @Updated);";

                await db.ExecuteAsync(Query, new
                {
                    medic.Id.Id,
                    medic.FirstName,
                    medic.LastName,
                    medic.Email,
                    medic.Password,
                    medic.CRMNumber,
                    medic.Specialty,
                    medic.HospitalAffiliation,
                    medic.PhoneNumber,
                    medic.Created,
                    medic.Updated,
                });

                string addressSql = @"
                        INSERT INTO Addresses (Address, City, State, ZipCode, Number, idmedic)
                        VALUES (@Address, @City, @State, @ZipCode, @Number, @Idmedic)";

                foreach (var address in medic.Addresses)
                {
                    await db.QueryAsync(addressSql, new
                    {
                        address.Address,
                        address.City,
                        address.State,
                        address.ZipCode,
                        address.Number,
                        Idmedic = medic.Id.Id
                    });
                }
            }
        }

        public async Task<IEnumerable<Medic>> FindAll()
        {
            using (var db = _context.CreateConnection())
            {

                SqlMapper.AddTypeHandler(new MedicIdTypeHandler());
                string query = @" SELECT * FROM medic INNER JOIN addresses ON addresses.idmedic = medic.id";

                var medicDictionary = new Dictionary<string, Medic>();
                var medicList = await db.QueryAsync<Medic, MedicAddress, Medic>(
                    query,
                    (medic, address) =>
                    {
                        if (!medicDictionary.TryGetValue(medic.Id.Id.ToString(), out var medicEntry))
                        {
                            medicEntry = medic;
                            medicEntry.Addresses = new List<MedicAddress>();
                            medicDictionary.Add(medicEntry.Id.Id.ToString(), medicEntry);
                        }

                        medicEntry.Addresses.Add(address);
                        return medicEntry;

                    }, splitOn: "id, id"
                );

                return medicList;
            }
        }



        public async Task<IEnumerable<Medic?>> FindByEmail(string email)
        {
            using (var db = _context.CreateConnection())
            {
                string query = "SELECT email FROM medic WHERE email = @email";

                return await db.QueryFirstOrDefaultAsync(query, new { Email = email });
            }
        }

        public async Task<Medic> FindById(string id)
        {
            using (var db = _context.CreateConnection())
            {
                SqlMapper.AddTypeHandler(new MedicIdTypeHandler());
                string query = @"SELECT * FROM medic INNER JOIN addresses ON addresses.idmedic = medic.id WHERE medic.id = @Id";

                var medicDictionary = new Dictionary<string, Medic>();
                var medicList = await db.QueryAsync<Medic, MedicAddress, Medic>(
                    query,
                    (medic, address) =>
                    {
                        if (!medicDictionary.TryGetValue(medic.Id.Id.ToString(), out var medicEntry))
                        {
                            medicEntry = medic;
                            medicEntry.Addresses = new List<MedicAddress>();
                            medicDictionary.Add(medicEntry.Id.Id.ToString(), medicEntry);
                        }

                        medicEntry.Addresses.Add(address);
                        return medicEntry;

                    },
                    new { Id = id },
                    splitOn: "id, id"
                );

                return medicList.FirstOrDefault(); 
            }
        }
    }
}