
using HospitalSolution.Domain.Entities;
using HospitalSolution.Domain.Entities.Medic;

namespace HospitalSolution.Infrastructure.Persistence;

public interface IMedicRepository
{
    Task Add(Medic medic);
    Task<IEnumerable<Medic?>> FindByEmail(string email);
    Task<Medic> FindById(string id);
    Task<IEnumerable<Medic>> FindAll();

}
