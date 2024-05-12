
using findByIdComand;
using HospitalSolution.Infrastructure.Persistence;
using MediatR;

namespace findByIdCommandHandler;

public class FindByIdCommandHandler : IRequestHandler<FindByIdComand, AuthenticationMedicResult>
{
    private readonly IMedicRepository _MedicRepository;

    public FindByIdCommandHandler(IMedicRepository medicRepository)
    {
        _MedicRepository = medicRepository;
    }

    public async Task<AuthenticationMedicResult> Handle(FindByIdComand request, CancellationToken cancellationToken)
    {
        var find = await _MedicRepository.FindById(request.Id.ToString());

        if(find == null){
            throw new ArgumentException("Id not Found");
        }
      
        return new AuthenticationMedicResult(find);
    }
}