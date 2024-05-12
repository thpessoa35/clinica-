using System;
using System.Data;
using Dapper;
using HospitalSolution.Domain.Entities.medic;

public class MedicIdTypeHandler : SqlMapper.TypeHandler<MedicId>
{
    public override void SetValue(IDbDataParameter parameter, MedicId value)
    {
        parameter.Value = value?.Id;
    }

    public override MedicId Parse(object value)
    {
        if (value == null || value == DBNull.Value)
            return null;

        if (value is int intValue)
            return MedicId.GetId(intValue.ToString());

        return MedicId.GetId((string)value);
    }
}
