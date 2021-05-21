// <copyright file="IControlPanelWebClient.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.ControlPanel.DomainModel.Entities;

    public interface IControlPanelWebClient
    {
        Task<DomainModel.Entities.Menu> AddMenuAsync(DomainModel.Entities.Menu menu);

        Task<Module> AddModuleAsync(Module module);

        Task DeleteMenuAsync(DomainModel.Entities.Menu menu);

        Task DeleteModuleAsync(Module module);

        Task<DomainModel.Entities.Menu> FindMenuAsync(DomainModel.Entities.Menu menu);

        Task<Module> FindModuleAsync(Module module);

        Task<List<DomainModel.Entities.Menu>> GetAllActiveMenusAsync();

        Task<List<Module>> GetAllActiveModulesAsync();

        Task<List<DomainModel.Entities.Menu>> GetAllMenusAsync();

        Task<List<Module>> GetAllModulesAsync();

        Task<DomainModel.Entities.Menu> ModifyMenuAsync(DomainModel.Entities.Menu menu);

        Task<Module> ModifyModuleAsync(Module module);
    }
}
