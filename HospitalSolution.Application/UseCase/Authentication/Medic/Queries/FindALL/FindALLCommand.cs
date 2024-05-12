

using HospitalSolution.Application.UseCase.Authentication.Medics.Commands.Register;
using HospitalSolution.Domain.Entities.Medic;
using MediatR;

namespace HospitalSolution.Application.UseCase.Authentication.medic.Queries.FindALL;

public record FindALLCommand
(
) : IRequest<IEnumerable<Medic>>;
