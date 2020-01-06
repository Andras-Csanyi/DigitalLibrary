namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Position
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface IPositionApiWebClient
    {
        Task<Position> AddAsync(Position position);

        Task DeleteAsync(Position postition);

        Task<Position> FindAsync(Position position);

        Task<List<Position>> GetAllAsync();

        Task<List<Position>> GetAllActiveAsync();

        Task<Position> ModifyAsync(Position peopleEventLog);
    }
}