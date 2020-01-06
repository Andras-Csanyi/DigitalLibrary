namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Interfaces.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface IPeopleBusinessLogic
    {
        Task<People> AddAsync(People people);

        Task<List<People>> GetAllAsync();

        Task<List<People>> GetAllActiveAsync();

        Task<People> FindAsync(People people);

        Task DeleteAsync(People people);

        Task<People> ModifyAsync(People people);
    }
}