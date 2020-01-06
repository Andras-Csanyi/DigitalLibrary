namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.People
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface IPeopleApiWebClient
    {
        Task<People> AddAsync(People people);

        Task DeleteAsync(People people);

        Task<People> FindAsync(People people);

        Task<List<People>> GetAllAsync();

        Task<List<People>> GetAllActiveAsync();

        Task<People> ModifyAsync(People people);
    }
}