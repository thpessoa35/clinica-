

using pacient;

namespace HospitalSolution.Application.Common.Persistence;

public interface IPacientRepository
{
     Task Add(Paciente pacient);
     Task<Paciente> Updated(string id, Paciente pacient);

     Task<Paciente?> FindById(string id);
     
}
