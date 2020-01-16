using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalLibrary.ControlPanel.DomainModel.Entities;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Interfaces.Interfaces
{
    public interface IModuleBusinessLogic
    {
        Task<Module> AddAsync(Module module);

        Task DeleteAsync(Module toBeDelete);

        Task<Module> ModifyAsync(Module modify);

        Task<Module> FindAsync(Module module);

        Task<List<Module>> GetAllAsync();

        Task<List<Module>> GetAllActiveAsync();
    }
}