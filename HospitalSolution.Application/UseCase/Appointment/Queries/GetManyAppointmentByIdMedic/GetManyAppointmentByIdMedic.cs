
using HospitalSolution.Application.Common.Persistence.Queries;
using HospitalSolution.Application.UseCase.appointment.Queries.GetManyAppointmentByIdMedic;
using HospitalSolution.Domain.Appointment;
using MediatR;

namespace HospitalSolution.Application.UseCase.appointments.Queries;

public class GetManyAppointmentByIdMedic : IRequestHandler<GetMedicIdCommand, IEnumerable<Appointment>>
{
    private readonly IGetByIdAppointment _iGetByIdAppointment;

    public GetManyAppointmentByIdMedic(IGetByIdAppointment iGetByIdAppointment)
    {
        _iGetByIdAppointment = iGetByIdAppointment;
    }

    public async Task<IEnumerable<Appointment>> Handle(GetMedicIdCommand request, CancellationToken cancellationToken)
    {
        var medic = await _iGetByIdAppointment.GetManyAppointmentByIdMedic(request.MedicId.ToString());

        return medic;
    }
}
