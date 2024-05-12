
using addressesEmploye;
using employe;


namespace HospitalSolution.Infrastructure.Persistence;

public interface IEmployeRepository
{
    Task Add(Employe employe);
    

}
