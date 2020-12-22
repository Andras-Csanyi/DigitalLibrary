namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormatDimensionStructureNode
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructureNode;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatDimensionStructureNodeBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<SourceFormatDimensionStructureNode> GetByIdAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    await _masterDataValidators
                       .SourceFormatDimensionStructureNodeValidator.ValidateAndThrowAsync(
                            sourceFormatDimensionStructureNode,
                            ruleSet: SourceFormatDimensionStructureNodeValidatorRulesets.GetById)
                       .ConfigureAwait(false);

                    SourceFormatDimensionStructureNode node = await ctx.SourceFormatDimensionStructureNodes
                       .FirstOrDefaultAsync(
                            o => o.Id == sourceFormatDimensionStructureNode.Id,
                            cancellationToken)
                       .ConfigureAwait(false);

                    return node;
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataSourceFormatDimensionStructureNodeBusinessLogic)}." +
                                 $"{nameof(GetByIdAsync)} operation failed. " +
                                 $"For further information see inner exception!";
                    throw new MasterDataDimensionStructureNodeBusinessLogicException(msg, e);
                }
            }
        }
    }
}