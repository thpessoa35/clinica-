using HospitalSolution.Application.Common.Persistence.Queries;
using HospitalSolution.Application.NotificationEvent;
using HospitalSolution.Application.UseCase.appointment.Queries;
using HospitalSolution.Application.UseCase.appointments.Queries;
using HospitalSolution.Application.UseCase.Authentication.Medics.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace dependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(LibraryEntrypoint).Assembly));
            services.AddSingleton<RegisterMedicCommandHandler>();
            services.AddSingleton<GetByAppointment>();
            services.AddSingleton<GetManyAppointmentByIdMedic>();
            services.AddSingleton<BackgroundService, SendNotification>();
            
            return services;
        }
    }

    internal class LibraryEntrypoint
    {
    }
}
