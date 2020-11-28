namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructureNode
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public partial class MasterDataDimensionStructureNodeBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<DimensionStructureNode> CreateRootNodeAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _masterDataValidators
                   .SourceFormatValidator
                   .ValidateAndThrowAsync(
                        sourceFormat,
                        SourceFormatValidatorRulesets.AddRootNode,
                        cancellationToken)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                    using (IDbContextTransaction transaction = await ctx.Database
                       .BeginTransactionAsync(cancellationToken)
                       .ConfigureAwait(false))
                    {
                        DimensionStructureNode newNode = new DimensionStructureNode();
                        await ctx.DimensionStructureNodes.AddAsync(newNode, cancellationToken).ConfigureAwait(false);
                        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                        SourceFormat sourceFormatResult = await ctx.SourceFormats
                           .FirstOrDefaultAsync(p => p.Id == sourceFormat.Id, cancellationToken)
                           .ConfigureAwait(false);

                        if (sourceFormatResult == null)
                        {
                            string msg = $"There is no {nameof(SourceFormat)} entity " +
                                $"with id: {sourceFormat.Id}";
                            throw new MasterDataDimensionStructureNodeBusinessLogicException(msg);
                        }

                        SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode =
                            new SourceFormatDimensionStructureNode
                            {
                                DimensionStructureNode = newNode,
                                SourceFormat = sourceFormatResult,
                            };
                        await ctx.SourceFormatDimensionStructureNodes.AddAsync(
                                sourceFormatDimensionStructureNode,
                                cancellationToken)
                           .ConfigureAwait(false);
                        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                        return newNode;
                    }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataDimensionStructureNodeBusinessLogic)}." +
                    $"{nameof(CreateRootNodeAsync)} operation failed. " +
                    $"For further information see inner exception!";
                throw new MasterDataDimensionStructureNodeBusinessLogicException(msg, e);
            }
        }
    }
}