using HospitalSolution.Application.Common.Interfaces.Kafka;
using HospitalSolution.Application.Common.Persistence.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HospitalSolution.Application.NotificationEvent
{
    public class SendNotification : BackgroundService
    {
        private readonly ILogger<SendNotification> _logger;
        private readonly IServiceProvider _provedorServico;
        private readonly IGetByIdAppointment _getByIdAppointment;
        private readonly IProducerKafka _producerKafka;

        public SendNotification(ILogger<SendNotification> logger, IServiceProvider provedorServico, IGetByIdAppointment getByIdAppointment, IProducerKafka producerKafka)
        {
            _logger = logger;
            _provedorServico = provedorServico;
            _getByIdAppointment = getByIdAppointment;
            _producerKafka = producerKafka;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Serviço de Envio de Notificação iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                var amanha = DateTime.Today.AddDays(1);

                _logger.LogInformation($"Verificando consultas para {amanha.ToShortDateString()}.");

                using (var escopo = _provedorServico.CreateScope())
                {
                    var getDate = await _getByIdAppointment.GetDateAppointment(amanha);

                    foreach (var consulta in getDate)
                    {
                        string message = @$"Consulta Marcada: {consulta.Id.Id}, Date: {consulta.Date} para o paciente {consulta.Pacient.FirstName} {consulta.Pacient.LastName} number: {consulta.Pacient.PhoneNumber}.";

                        await _producerKafka.Producer("AgendNotification", message);
                    }
                }
                Console.WriteLine($"Notificação enviada");

                await Task.Delay(TimeSpan.FromSeconds(24), stoppingToken);
            }

            _logger.LogInformation("Serviço de Envio de Notificação parado.");
        }
    }
}
