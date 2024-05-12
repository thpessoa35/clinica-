using System;
using System.Data;
using Dapper;
using HospitalSolution.Domain.Appointment.valueObject;


public class AppointmentIdTypeHandler : SqlMapper.TypeHandler<AppointmentId>
{
    public override void SetValue(IDbDataParameter parameter, AppointmentId value)
    {
        parameter.Value = value?.Id;
    }

    public override AppointmentId Parse(object value)
    {
        if (value == null || value == DBNull.Value)
            return null;

        if (value is int intValue)
            return AppointmentId.GetId(intValue.ToString());

        return AppointmentId.GetId((string)value);
    }
}
