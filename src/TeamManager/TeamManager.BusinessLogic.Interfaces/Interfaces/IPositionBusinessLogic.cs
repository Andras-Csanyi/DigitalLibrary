namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Interfaces.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface IPositionBusinessLogic
    {
        Task<Position> AddAsync(Position position);

        Task<Position> ModifyAsync(Position position);

        Task<List<Position>> GetAllAsync();

        Task<List<Position>> GetAllActiveAsync();

        Task DeleteAsync(Position position);

        Task<Position> FindAsync(Position position);
    }
}