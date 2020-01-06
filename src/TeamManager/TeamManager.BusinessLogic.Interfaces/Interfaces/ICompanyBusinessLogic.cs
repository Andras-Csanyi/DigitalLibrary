namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Interfaces.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface ICompanyBusinessLogic
    {
        Task<Company> AddAsync(Company newCompany);

        Task<Company> ModifyAsync(Company modifiedCompany);

        Task DeleteAsync(Company company);

        Task<List<Company>> GetAllAsync();

        Task<List<Company>> GetAllActiveAsync();

        Task<Company> FindAsync(Company company);
    }
}