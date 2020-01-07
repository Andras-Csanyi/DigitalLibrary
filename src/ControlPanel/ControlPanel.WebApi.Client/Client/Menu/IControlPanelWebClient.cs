namespace DigitalLibrary.IaC.ControlPanel.WebApi.Client.Client.Menu
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface IControlPanelWebClient
    {
        Task<List<Menu>> GetAllMenusAsync();

        Task<List<Menu>> GetAllActiveMenusAsync();

        Task<Menu> FindMenuAsync(Menu menu);

        Task<Menu> AddMenuAsync(Menu menu);

        Task<Menu> ModifyMenuAsync(Menu menu);

        Task DeleteMenuAsync(Menu menu);

        Task<List<Module>> GetAllModulesAsync();

        Task<List<Module>> GetAllActiveModulesAsync();

        Task<Module> FindModuleAsync(Module module);

        Task<Module> AddModuleAsync(Module module);

        Task<Module> ModifyModuleAsync(Module module);

        Task DeleteModuleAsync(Module module);
    }
}