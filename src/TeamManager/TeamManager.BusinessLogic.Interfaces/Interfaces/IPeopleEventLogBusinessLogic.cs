namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Interfaces.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface IPeopleEventLogBusinessLogic
    {
        Task<PeopleEventLog> AddAsync(PeopleEventLog peopleEventLog);

        Task<PeopleEventLog> ModifyAsync(PeopleEventLog peopleEventLog);

        Task DeleteAsync(PeopleEventLog peopleEventLog);

        Task<List<PeopleEventLog>> GetAllAsync();

        Task<List<PeopleEventLog>> GetAllByPeople(long peopleId);
    }
}