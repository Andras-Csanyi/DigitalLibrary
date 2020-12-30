namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormatDimensionStructureNode
{
    using System;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatDimensionStructureNodeBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<SourceFormatDimensionStructureNode> UpdateAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    Check.IsNotNull(sourceFormatDimensionStructureNode);
                    await _masterDataValidators
                       .SourceFormatDimensionStructureNodeValidator.ValidateAndThrowAsync(
                            sourceFormatDimensionStructureNode,
                            ruleSet: SourceFormatDimensionStructureNodeValidatorRulesets.Update,
                            cancellationToken)
                       .ConfigureAwait(false);

                    SourceFormatDimensionStructureNode node = await ctx.SourceFormatDimensionStructureNodes
                       .FirstOrDefaultAsync(
                            o => o.Id == sourceFormatDimensionStructureNode.Id,
                            cancellationToken)
                       .ConfigureAwait(false);

                    if (node == null)
                    {
                        string msg = $"There is no {nameof(SourceFormatDimensionStructureNode)} " +
                                     $"with id: {sourceFormatDimensionStructureNode.Id}.";
                        throw new MasterDataSourceFormatDimensionStructureNodeBusinessLogicException(msg);
                    }

                    node.SourceFormatId = sourceFormatDimensionStructureNode.SourceFormatId;
                    node.DimensionStructureNodeId = sourceFormatDimensionStructureNode.DimensionStructureNodeId;
                    ctx.Entry(node).State = EntityState.Modified;
                    await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                    return node;
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataSourceFormatDimensionStructureNodeBusinessLogic)}." +
                                 $"{nameof(UpdateAsync)} operation failed. " +
                                 $"For further information see inner exception!";
                    throw new MasterDataSourceFormatDimensionStructureNodeBusinessLogicException(msg, e);
                }
            }
        }
    }
}