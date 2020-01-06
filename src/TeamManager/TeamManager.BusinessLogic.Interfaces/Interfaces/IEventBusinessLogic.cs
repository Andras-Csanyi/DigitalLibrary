namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Interfaces.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface IEventBusinessLogic
    {
        Task<Event> AddAsync(Event newEvent);

        Task<Event> ModifyAsync(Event modifiedEvent);

        Task DeleteAsync(Event eventToBeDelete);

        Task<List<Event>> GetAllAsync();

        Task<List<Event>> GetAllActiveAsync();

        Task<Event> Find(Event toBeFound);
    }
}