namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Interfaces.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface ITitleBusinessLogic
    {
        Task<Title> AddAsync(Title newTitle);

        Task<Title> ModifyAsync(Title modifiedTitle);

        Task DeleteAsync(Title titleToBeDeleted);

        Task<List<Title>> GetAllAsync();

        Task<List<Title>> GetAllActivesAsync();

        Task<Title> FindAsync(Title title);
    }
}