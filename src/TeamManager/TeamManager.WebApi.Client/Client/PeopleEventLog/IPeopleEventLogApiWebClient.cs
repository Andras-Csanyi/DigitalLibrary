namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.PeopleEventLog
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface IPeopleEventLogApiWebClient
    {
        Task<PeopleEventLog> AddAsync(PeopleEventLog peopleEventLog);

        Task DeleteAsync(PeopleEventLog peopleEventLog);

        Task<PeopleEventLog> FindAsync(PeopleEventLog peopleEventLog);

        Task<List<PeopleEventLog>> GetAllAsync();

        Task<List<PeopleEventLog>> GetAllActiveAsync();

        Task<PeopleEventLog> ModifyAsync(PeopleEventLog peopleEventLog);
    }
}