// <copyright file="IMenuBusinessLogic.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Interfaces.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.ControlPanel.DomainModel.Entities;

    public interface IMenuBusinessLogic
    {
        Task<Menu> AddAsync(Menu newMenu);

        Task DeleteAsync(Menu toBeDeleted);

        Task<Menu> FindAsync(Menu menu);

        Task<List<Menu>> GetAllActiveAsync();

        Task<List<Menu>> GetAllAsync();

        Task<Menu> ModifyAsync(Menu modified);
    }
}
