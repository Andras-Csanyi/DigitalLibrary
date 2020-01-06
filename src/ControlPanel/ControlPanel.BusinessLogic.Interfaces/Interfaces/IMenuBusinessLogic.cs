namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Interfaces.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface IMenuBusinessLogic
    {
        Task<Menu> AddAsync(Menu newMenu);

        Task DeleteAsync(Menu toBeDeleted);

        Task<Menu> ModifyAsync(Menu modified);

        Task<List<Menu>> GetAllAsync();

        Task<List<Menu>> GetAllActiveAsync();

        Task<Menu> FindAsync(Menu menu);
    }
}