
using appointmentsResult;
using HospitalSolution.Application.Common.Persistence.Queries;
using MediatR;

namespace HospitalSolution.Application.UseCase.appointment.Queries;

public class GetByAppointment : IRequestHandler<GetCommand, AppointmentsResult>
{

    private readonly IGetByIdAppointment _getByIdAppointment;

    public GetByAppointment(IGetByIdAppointment getByIdAppointment)
    {
        _getByIdAppointment = getByIdAppointment;
    }

    public async Task<AppointmentsResult> Handle(GetCommand request, CancellationToken cancellationToken)
    {
        var Id = await _getByIdAppointment.GetById(request.id);

        return new AppointmentsResult(Id);
    }


}

