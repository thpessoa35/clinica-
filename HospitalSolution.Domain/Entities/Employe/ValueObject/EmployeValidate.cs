using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSolution.Domain.Entities.Employe.ValueObject;

public sealed class EmployeValidate
{
    internal static void IsNameNotNull(string firstName)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentException("Firstname cannot be null or empty", nameof(firstName));
        }
    }

    internal static void IsLastNotNull(string lastName)
    {
        if (string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentException("LastName cannot be null or empty", nameof(lastName));
        }
    }

    internal static void IsPhoneNumberNotNull(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length > 13)
        {
            throw new ArgumentException("LastName cannot be null or empty", nameof(phoneNumber));
        }
    }

};