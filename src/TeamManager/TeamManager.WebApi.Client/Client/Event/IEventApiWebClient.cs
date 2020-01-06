namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Event
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface IEventApiWebClient
    {
        Task<Event> AddAsync(Event newEvent);

        Task DeleteAsync(Event toBeDeletedEvent);

        Task<Event> FindAsync(Event eventToBeFound);

        Task<List<Event>> GetAllAsync();

        Task<List<Event>> GetAllActiveAsync();

        Task<Event> ModifyAsync(Event eventToBeModified);
    }
}