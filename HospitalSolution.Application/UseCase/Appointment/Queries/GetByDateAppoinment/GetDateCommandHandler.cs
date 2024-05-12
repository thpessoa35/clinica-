
using appointmentsResult;
using HospitalSolution.Application.Common.Persistence.Queries;
using HospitalSolution.Application.UseCase.appointment.Queries.GetByDateAppoinment;
using HospitalSolution.Domain.Appointment;
using MediatR;

namespace getDateCommandHandler;

public class GetDateCommandHandler : IRequestHandler<GetDateCommand, IEnumerable<Appointment>>
{
    private readonly IGetByIdAppointment _iGetByIdAppointment;

    public GetDateCommandHandler(IGetByIdAppointment iGetByIdAppointment)
    {
        _iGetByIdAppointment = iGetByIdAppointment;
    }

    public async Task<IEnumerable<Appointment>> Handle(GetDateCommand request, CancellationToken cancellationToken)
    {
       var date = await _iGetByIdAppointment.GetDateAppointment(request.Date);


       return date;
    }
}