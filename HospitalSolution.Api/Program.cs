using dependencyInjection;
using HospitalSolution.Api;
using HospitalSolution.Application.NotificationEvent;


var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
var config = builder.Configuration;

// Configuração dos serviços
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApi(config);
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SendNotification>();

builder.Services.AddSingleton<TimeZoneInfo>(provider =>
{
    return TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
});
// Construção da aplicação
var app = builder.Build();

// Obtém o serviço provider
var serviceProvider = app.Services;

// Obtém o serviço SendNotification
var sendNotification = serviceProvider.GetRequiredService<SendNotification>();

// Inicia o serviço SendNotification
await sendNotification.StartAsync(default);

// Mapeamento dos controladores
app.MapControllers();

// Redirecionamento HTTPS
app.UseHttpsRedirection();

// Execução da aplicação
app.Run();
