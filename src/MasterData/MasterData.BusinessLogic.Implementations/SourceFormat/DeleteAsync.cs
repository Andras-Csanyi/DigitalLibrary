// <copyright file="DeleteSourceFormatAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc />
        public async Task DeleteAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.IsNotNull(sourceFormat);
                await _masterDataValidators.SourceFormatValidator.ValidateAsync(sourceFormat, o =>
                {
                    o.IncludeRuleSets(SourceFormatValidatorRulesets.Delete);
                    o.ThrowOnFailures();
                }, cancellationToken).ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    SourceFormat result = await ctx.SourceFormats
                       .Include(p => p.DimensionStructureNodes)
                       .Include(pp => pp.SourceFormatDimensionStructureNode)
                       .FirstOrDefaultAsync(
                            w => w.Id == sourceFormat.Id,
                            cancellationToken
                        )
                       .ConfigureAwait(false);

                    if (result is null)
                    {
                        string msg = $"There is no {nameof(SourceFormat)} with id: {sourceFormat.Id}";
                        throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                    }

                    if (result.DimensionStructureNodes.Any())
                    {
                        foreach (DimensionStructureNode node in result.DimensionStructureNodes)
                        {
                            ctx.Entry(node).State = EntityState.Deleted;
                        }

                        await ctx.SaveChangesAsync(cancellationToken)
                           .ConfigureAwait(false);
                    }

                    if (result.SourceFormatDimensionStructureNode is not null)
                    {
                        ctx.Entry(result.SourceFormatDimensionStructureNode).State = EntityState.Deleted;
                        await ctx.SaveChangesAsync(cancellationToken)
                           .ConfigureAwait(false);
                    }

                    ctx.Entry(result).State = EntityState.Deleted;
                    await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                             $"{nameof(DeleteAsync)} operation failed! " +
                             "For further information see inner exception!";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }
    }
}