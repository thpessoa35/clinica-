

using employe;
using HospitalSolution.Domain.Entities;

namespace HospitalSolution.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Employe employe);
}
