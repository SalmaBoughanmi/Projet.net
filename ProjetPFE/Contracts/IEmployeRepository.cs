using ProjetPFE.Dto;
using ProjetPFE.Entities;

namespace ProjetPFE.Contracts
{
    public interface IEmployeRepository
    {
        Task<ICollection<employe>> Getemployes();
        Task<employe> GetEmployeByIdAsync(int id);
        Task<IEnumerable<employe>> Getemp(string matricule);
        //Task<int> AddEmploye(employe employe);
        //Task<int> UpdateEmployeAsync(employe employe);
        Task<int> DeleteEmployeAsync(int id);
        Task<employe?> Login(string email, string password);
        Task<int> AddEmploye(EmployeForCreationDto employe);
        Task<int> UpdateEmployeAsync(Empl employe);
        employe GetEmployeByIdDemande(int id);
        Task<IEnumerable<employe>> SearchempAsync(string search);
        //public Task DeleteEmploye(int employe_id);

        //public Task<employe> CreateEmploye(EmployeForCreationDto employe);

    }
}
