using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;

namespace dapper;

public class DbContext
{
    private readonly string _connectionString;

    public DbContext(IConfiguration configuration)
    {
        _connectionString = "Host=localhost;Port=5432;Username=hospital;Password=tmp701226;Database=hospital;";
    }

    public NpgsqlConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}