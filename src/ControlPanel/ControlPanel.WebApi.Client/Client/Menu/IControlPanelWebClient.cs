using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalLibrary.ControlPanel.DomainModel.Entities;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu
{
    public interface IControlPanelWebClient
    {
        Task<List<DomainModel.Entities.Menu>> GetAllMenusAsync();

        Task<List<DomainModel.Entities.Menu>> GetAllActiveMenusAsync();

        Task<DomainModel.Entities.Menu> FindMenuAsync(DomainModel.Entities.Menu menu);

        Task<DomainModel.Entities.Menu> AddMenuAsync(DomainModel.Entities.Menu menu);

        Task<DomainModel.Entities.Menu> ModifyMenuAsync(DomainModel.Entities.Menu menu);

        Task DeleteMenuAsync(DomainModel.Entities.Menu menu);

        Task<List<Module>> GetAllModulesAsync();

        Task<List<Module>> GetAllActiveModulesAsync();

        Task<Module> FindModuleAsync(Module module);

        Task<Module> AddModuleAsync(Module module);

        Task<Module> ModifyModuleAsync(Module module);

        Task DeleteModuleAsync(Module module);
    }
}