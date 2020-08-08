namespace DigitalLibrary.ControlPanel.BusinessLogic.Interfaces.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface IModuleBusinessLogic
    {
        Task<Module> AddAsync(Module module);

        Task DeleteAsync(Module toBeDelete);

        Task<Module> FindAsync(Module module);

        Task<List<Module>> GetAllActiveAsync();

        Task<List<Module>> GetAllAsync();

        Task<Module> ModifyAsync(Module modify);
    }
}