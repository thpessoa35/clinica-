using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalSolution.Application.UseCase.Authentication.Common;
using MediatR;

namespace HospitalSolution.Application.UseCase.Authentication.Queries.LoginEmployee;

public record LoginCommand
(
    string Email,
    string Password
): IRequest<AuthenticationResult>;
