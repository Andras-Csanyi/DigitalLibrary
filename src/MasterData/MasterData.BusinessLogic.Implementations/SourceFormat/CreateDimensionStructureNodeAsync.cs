namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<DimensionStructureNode> CreateDimensionStructureNodeAsync(
            DimensionStructureNode node,
            CancellationToken cancellationToken = default)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    Check.IsNotNull(node);
                    await _masterDataValidators.DimensionStructureNodeValidator.ValidateAsync(node, o =>
                        {
                            o.IncludeRuleSets(SourceFormatValidatorRulesets.CreateDimensionStructureNode);
                            o.ThrowOnFailures();
                        }, cancellationToken)
                       .ConfigureAwait(false);
                    await ctx.DimensionStructureNodes.AddAsync(node, cancellationToken).ConfigureAwait(false);
                    await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    return node;
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                        $"${nameof(CreateDimensionStructureNodeAsync)} failed. " +
                        $"For further info see inner exception.";
                    throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                }
            }
        }
    }
}
