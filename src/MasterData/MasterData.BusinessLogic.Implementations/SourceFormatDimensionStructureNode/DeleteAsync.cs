namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormatDimensionStructureNode
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatDimensionStructureNodeBusinessLogic
    {
        /// <inheritdoc/>
        public async Task DeleteAsync(
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
                            ruleSet: SourceFormatDimensionStructureNodeValidatorRulesets.Delete,
                            cancellationToken)
                       .ConfigureAwait(false);

                    SourceFormatDimensionStructureNode node = await ctx.SourceFormatDimensionStructureNodes
                       .FirstOrDefaultAsync(
                            o => o.Id == sourceFormatDimensionStructureNode.Id,
                            cancellationToken)
                       .ConfigureAwait(false);

                    if (node != null)
                    {
                        ctx.Entry(node).State = EntityState.Deleted;
                        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    }
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataSourceFormatDimensionStructureNodeBusinessLogic)}." +
                                 $"{nameof(DeleteAsync)} operation has failed." +
                                 $"For further information see inner exception!";
                    throw new MasterDataSourceFormatDimensionStructureNodeBusinessLogicException(msg, e);
                }
            }
        }
    }
}