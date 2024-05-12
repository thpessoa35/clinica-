using System.Data;
using System.Threading.Tasks;
using dapper;
using Dapper;
using employe;
using HospitalSolution.Infrastructure.Persistence;

namespace HospitalSolution.Infrastructure.DataBaseInMemory
{
    public class DbEmployeContext : IEmployeRepository
    {
        private readonly DbContext _connection;

        public DbEmployeContext(DbContext connection)
        {
            _connection = connection;
        }

        public async Task Add(Employe employe)
        {
            using (var connection = _connection.CreateConnection())
            {
                await connection.OpenAsync();

                string employeSql = @"
                        INSERT INTO Employee (Id, FirstName, LastName, Email, Password, PhoneNumber)
                        VALUES (@Id, @FirstName, @LastName, @Email, @Password, @PhoneNumber)";

                await connection.ExecuteAsync(employeSql, new
                {
                    employe.Id.Id,
                    employe.FirstName,
                    employe.LastName,
                    employe.Email,
                    employe.Password,
                    employe.PhoneNumber
                });

                string addressSql = @"
                        INSERT INTO Addresses (Address, City, State, ZipCode, Number, idemployee)
                        VALUES (@Address, @City, @State, @ZipCode, @Number, @idemployee)";

                foreach (var address in employe.Addresses)
                {
                    await connection.QueryAsync(addressSql, new
                    {
                        address.Address,
                        address.City,
                        address.State,
                        address.ZipCode,
                        address.Number,
                        idemployee = employe.Id.Id
                    });
                }

            }
        }
    }
}
