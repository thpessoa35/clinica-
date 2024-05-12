using HospitalSolution.Application.UseCase.Authentication.medic.Queries.FindALL;
using HospitalSolution.Domain.Entities.Medic;
using HospitalSolution.Infrastructure.Persistence;
using MediatR;

public class FindALLHandler : IRequestHandler<FindALLCommand, IEnumerable<Medic>>
{
    private readonly IMedicRepository _medicRepository;

    public FindALLHandler(IMedicRepository medicRepository)
    {
        _medicRepository = medicRepository;
    }

    public async Task<IEnumerable<Medic>> Handle(FindALLCommand request, CancellationToken cancellationToken)
    {
        var medicList = await _medicRepository.FindAll();
        return medicList;
    }
}
