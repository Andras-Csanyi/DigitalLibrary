// <copyright file="DomainEntityHelperService.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUi.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel.Interfaces;
    using DigitalLibrary.Utils.Guards;

    /// <summary>
    ///     Helper service for manipulating domain models.
    /// </summary>
    public interface IDomainEntityHelperService
    {
        /// <summary>
        ///     Adds a nullo object for the list as first item.
        ///     The role of a nullo object is displaying "-- Select-One --" in the drop down, for example.
        /// </summary>
        /// <param name="list"> The list where to the nullo will be added. </param>
        /// <typeparam name="T"> Type in the list </typeparam>
        /// <returns> The same list where the first item is the nullo </returns>
        Task<List<T>> AddNulloToListAsFirstItem<T>(List<T> list)
            where T : IHaveName, new();
    }

    public class DomainEntityHelperService : IDomainEntityHelperService
    {
        public async Task<List<T>> AddNulloToListAsFirstItem<T>(List<T> list)
            where T : IHaveName, new()
        {
            Check.IsNotNull(list);

            T nullo = new T
            {
                Name = "-- Select-One --",
            };

            // ReSharper disable once CA1062
            list.Insert(0, nullo);

            return list;
        }
    }
}
