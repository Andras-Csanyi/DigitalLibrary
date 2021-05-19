// <copyright file="DimensionDomainEntityHelperService.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUi.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    ///     Helper service for manipulating Dimension domain entities and lists.
    /// </summary>
    public interface IDimensionDomainEntityHelperService
    {
        /// <summary>
        ///     Creates a new list where the original list element except the listed elements
        ///     in the Except list will be listed.
        /// </summary>
        /// <param name="originalList"> The original list </param>
        /// <param name="exceptList"> Except list </param>
        /// <returns> Result </returns>
        Task<List<Dimension>> CreateNewListExceptAnotherList(
            List<Dimension> originalList,
            List<Dimension> exceptList);
    }

    /// <inheritdoc/>
    public class DimensionDomainEntityHelperService : IDimensionDomainEntityHelperService
    {
        /// <inheritdoc/>
        public async Task<List<Dimension>> CreateNewListExceptAnotherList(
            List<Dimension> originalList,
            List<Dimension> exceptList)
        {
            if (originalList.Any() || exceptList.Any())
            {
                List<Dimension> result = new List<Dimension>();

                foreach (Dimension originalDimension in originalList)
                {
                    Dimension hit = exceptList.FirstOrDefault(id => id.Id == originalDimension.Id);

                    if (hit == null)
                    {
                        result.Add(originalDimension);
                    }
                }

                return result;
            }

            return originalList;
        }
    }
}