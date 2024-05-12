using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalSolution.Application.UseCase.Authentication.Queries.LoginEmployee;
using HospitalSolution.Contracts.Authentication.Employee;

namespace HospitalSolution.Api.Mapping.Employe
{
    public static class MappingLoginRequest
    {
        public static LoginCommand MapperRequest(LoginEmployeeRequest request)
        {
            return new LoginCommand(request.Email, request.Password);
        }
    }
}