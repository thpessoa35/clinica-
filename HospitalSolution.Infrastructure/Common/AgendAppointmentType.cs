using System;
using System.Data;
using Dapper;
using HospitalSolution.Domain.Appointment.valueObject;

public class AgendAppointmentTypeHandler : SqlMapper.TypeHandler<AgendAppointment>
{
    public override void SetValue(IDbDataParameter parameter, AgendAppointment value)
    {
        parameter.Value = value.ConsultationDateTime;
    }

    public override AgendAppointment Parse(object value)
    {
        if (value == null || value.GetType() == typeof(DBNull))
        {
            return null;
        }

        if (value is DateTime date)
        {
            return AgendAppointment.GetAgend(date);
        }

        return AgendAppointment.GetAgend(Convert.ToDateTime(value));
    }
}
