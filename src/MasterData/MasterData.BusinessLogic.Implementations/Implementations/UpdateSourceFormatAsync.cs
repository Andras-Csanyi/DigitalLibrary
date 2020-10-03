// <copyright file="UpdateSourceFormatAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public partial class MasterDataBusinessLogic
    {
        public async Task<SourceFormat> UpdateSourceFormatAsync(SourceFormat sourceFormat)
        {
            // using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            // {
            //     using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync()
            //        .ConfigureAwait(false))
            //     {
            //         try
            //         {
            //             if (sourceFormat == null)
            //             {
            //                 string msg = $"{nameof(sourceFormat)} is null.";
            //                 throw new MasterDataBusinessLogicArgumentNullException(msg);
            //             }
            //
            //             await _masterDataValidators.SourceFormatValidator.ValidateAndThrowAsync(
            //                     sourceFormat,
            //                     SourceFormatValidatorRulesets.Update)
            //                .ConfigureAwait(false);
            //
            //             SourceFormat toBeModified = await ctx.SourceFormats
            //                .FindAsync(sourceFormat.Id)
            //                .ConfigureAwait(false);
            //
            //             if (toBeModified == null)
            //             {
            //                 string msg =
            //                     $"There is no {nameof(SourceFormat)} entity with id: {sourceFormat.Id}.";
            //                 throw new MasterDataBusinessLogicNoSuchSourceFormatEntityException(msg);
            //             }
            //
            //             toBeModified.Name = sourceFormat.Name;
            //             toBeModified.Desc = sourceFormat.Desc;
            //             toBeModified.IsActive = sourceFormat.IsActive;
            //             toBeModified.DimensionStructureTreeRootId = sourceFormat.DimensionStructureTreeRootId;
            //
            //             ctx.Entry(toBeModified).State = EntityState.Modified;
            //             await ctx.SaveChangesAsync().ConfigureAwait(false);
            //             await transaction.CommitAsync().ConfigureAwait(false);
            //
            //             SourceFormat result = await ctx.SourceFormats
            //                .Include(i => i.DimensionStructureTreeRoot)
            //                .Where(id => id.Id == toBeModified.Id)
            //                .FirstOrDefaultAsync()
            //                .ConfigureAwait(false);
            //
            //             return result;
            //         }
            //         catch (Exception e)
            //         {
            //             await transaction.RollbackAsync().ConfigureAwait(false);
            //             throw new MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException(
            //                 e.Message,
            //                 e);
            //         }
            //     }
            // }
            throw new NotImplementedException();
        }
    }
}