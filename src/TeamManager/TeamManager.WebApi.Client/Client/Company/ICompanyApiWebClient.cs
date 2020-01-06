namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Company
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface ICompanyApiWebClient
    {
        Task<Company> AddAsync(Company company);

        Task DeleteAsync(Company company);

        Task<Company> FindAsync(Company company);

        Task<List<Company>> GetAllAsync();

        Task<List<Company>> GetAllActiveAsync();

        Task<Company> ModifyAsync(Company company);
    }
}