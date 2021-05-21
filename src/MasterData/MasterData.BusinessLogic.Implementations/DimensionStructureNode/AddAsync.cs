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

    public partial class MasterDataDimensionStructureNodeBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<DimensionStructureNode> AddAsync(
            DimensionStructureNode dimensionStructureNode,
            CancellationToken cancellationToken = default)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    Check.IsNotNull(dimensionStructureNode);

                    await _masterDataValidators
                       .DimensionStructureNodeValidator.ValidateAsync(dimensionStructureNode, o =>
                        {
                            o.IncludeRuleSets(DimensionStructureNodeValidatorRulesets.Add);
                            o.ThrowOnFailures();
                        }, cancellationToken).ConfigureAwait(false);

                    DimensionStructureNode newNode = new DimensionStructureNode
                    {
                        IsActive = dimensionStructureNode.IsActive,
                    };

                    await ctx.DimensionStructureNodes.AddAsync(
                            newNode,
                            cancellationToken)
                       .ConfigureAwait(false);
                    await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                    return newNode;
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataDimensionStructureNodeBusinessLogic)}." +
                                 $"{nameof(AddAsync)} operation has failed. " +
                                 $"For further info see inner exception.";
                    throw new MasterDataDimensionStructureNodeBusinessLogicException(msg, e);
                }
            }
        }
    }
}
