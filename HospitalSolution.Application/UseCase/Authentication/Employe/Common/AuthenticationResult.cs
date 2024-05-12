
using employe;

namespace HospitalSolution.Application.UseCase.Authentication.Common;

public record AuthenticationResult
(
     Employe Employe,
     string Token
);
