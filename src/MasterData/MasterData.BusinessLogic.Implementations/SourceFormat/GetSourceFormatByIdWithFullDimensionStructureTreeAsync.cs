// <copyright file="GetSourceFormatByIdWithFullDimensionStructureTreeAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Dimension;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        public async Task<SourceFormat> GetSourceFormatByIdWithRootDimensionStructureAsync(
            SourceFormat querySourceFormat)
        {
            try
            {
                Check.IsNotNull(querySourceFormat);
                Check.AreNotEqual(querySourceFormat.Id, 0);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    SourceFormat sourceFormat = await ctx.SourceFormats
                       .Include(i => i.SourceFormatDimensionStructureNode)
                       .ThenInclude(ii => ii.DimensionStructureNode)
                       .ThenInclude(iii => iii.DimensionStructure)
                       .AsNoTracking()
                       .FirstAsync(p => p.Id == querySourceFormat.Id)
                       .ConfigureAwait(false);

                    return sourceFormat;
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataDimensionBusinessLogic)}." +
                             $"{nameof(GetSourceFormatByIdWithRootDimensionStructureAsync)} operation failed. " +
                             $"For further details see inner exception.";
                throw new MasterDataBusinessLogicDatabaseOperationException(msg, e);
            }
        }

        /// <summary>
        ///     Returns tree of DimensionStructure below the given DimensionStructure defined by Id.
        /// </summary>
        /// <param name="dimensionStructureId">The top level DimensionStructure of tree</param>
        /// <param name="ctx">MasterDataContext instance</param>
        /// <returns>Tree of DimensionStructure</returns>
        /// <exception cref="MasterDataBusinessLogicGetSourceFormatByIdWithDimensionStructureTreeAsyncOperationException"></exception>
        private async Task<List<DimensionStructure>> GetDimensionStructureTreeAsync(
            long? dimensionStructureId,
            MasterDataContext ctx)
        {
            // try
            // {
            //     Check.IsNotNull(dimensionStructureId);
            //     Check.AreNotEqual(dimensionStructureId, 0);
            //
            //     List<DimensionStructureDimensionStructure> result = ctx.DimensionStructureDimensionStructures
            //        .AsNoTracking()
            //        .Where(id => id.DimensionStructureId == dimensionStructureId)
            //        .Where(child => child.ChildDimensionStructureId != 0)
            //        .ToList();
            //
            //     if (result.Any())
            //     {
            //         List<DimensionStructure> dimensionStructures = new List<DimensionStructure>();
            //         foreach (DimensionStructureDimensionStructure dimensionStructureDimensionStructure in result)
            //         {
            //             DimensionStructure dimensionStructure = await ctx.DimensionStructures
            //                .AsNoTracking()
            //                .Include(i => i.Dimension)
            //                .Where(p => p.Id == dimensionStructureDimensionStructure.ChildDimensionStructureId)
            //                .AsNoTracking()
            //                .FirstOrDefaultAsync()
            //                .ConfigureAwait(false);
            //
            //             // dimensionStructure.ChildDimensionStructures =
            //             //     await GetDimensionStructureTreeAsync(dimensionStructure.Id, ctx)
            //             //        .ConfigureAwait(false);
            //
            //             dimensionStructures.Add(dimensionStructure);
            //         }
            //
            //         return dimensionStructures;
            //     }
            //
            //     return new List<DimensionStructure>();
            // }
            // catch (Exception e)
            // {
            //     throw new MasterDataBusinessLogicGetSourceFormatByIdWithDimensionStructureTreeAsyncOperationException(
            //         e.Message, e);
            // }
            throw new NotImplementedException();
        }
    }
}