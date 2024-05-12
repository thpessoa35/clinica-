using Confluent.Kafka;
using dapper;
using HospitalSolution.Application.Common.Interfaces.Authentication;
using HospitalSolution.Application.Common.Interfaces.Kafka;
using HospitalSolution.Application.Common.Persistence;
using HospitalSolution.Application.Common.Persistence.Queries;
using HospitalSolution.Infrastructure.DataBase;
using HospitalSolution.Infrastructure.DataBaseInMemory;
using HospitalSolution.Infrastructure.KafkaConfig;
using HospitalSolution.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using SuaAplicacao.Infraestrutura.Authentication;

namespace dependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IEmployeRepository, DbEmployeContext>();
            services.AddSingleton<IMedicRepository, DbMedicContext>();
            services.AddSingleton<IPacientRepository, DbPacientContext>();
            services.AddSingleton<IAppointmentRepository, DbAppointmentContext>();
            services.AddSingleton<IGetByIdAppointment, DbAppointmentContext>();
            services.AddTransient<IProducerKafka, ProducerConfigKafka>();
            services.AddSingleton<DbContext>();
            

            return services;
        }
    }
}
