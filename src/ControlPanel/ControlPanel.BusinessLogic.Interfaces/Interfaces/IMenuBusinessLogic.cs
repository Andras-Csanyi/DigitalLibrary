using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalLibrary.ControlPanel.DomainModel.Entities;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Interfaces.Interfaces
{
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