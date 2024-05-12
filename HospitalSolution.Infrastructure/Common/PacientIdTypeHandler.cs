using System;
using System.Data;
using Dapper;
using HospitalSolution.Domain.entities.Pacient;

public class PacientIdTypeHandler : SqlMapper.TypeHandler<PacientId>
{
    public override void SetValue(IDbDataParameter parameter, PacientId value)
    {
        parameter.Value = value?.Id;
    }

    public override PacientId Parse(object value)
    {
        if (value == null || value == DBNull.Value)
            return null;

        return PacientId.GetId((string)value);
    }
}
