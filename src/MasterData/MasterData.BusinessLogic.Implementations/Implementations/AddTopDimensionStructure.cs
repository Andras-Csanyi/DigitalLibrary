namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using DomainModel.DomainModel;

    using Exceptions.Exceptions;

    using FluentValidation;

    using Validators.Validators;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> AddTopDimensionStructureAsync(
            DimensionStructure dimensionStructure)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                using (var transaction = await ctx.Database.BeginTransactionAsync().ConfigureAwait(false))
                {
                    try
                    {
                        if (dimensionStructure == null)
                        {
                            throw new MasterDataBusinessLogicArgumentNullException();
                        }

                        await _masterDataValidators.TopDimensionStructureValidator.ValidateAndThrowAsync(
                                dimensionStructure,
                                ruleSet: ValidatorRulesets.AddNewTopDimensionStructure)
                            .ConfigureAwait(false);

                        dimensionStructure.ParentDimensionStructureId = null;
                        await ctx.DimensionStructures.AddAsync(dimensionStructure)
                            .ConfigureAwait(false);
                        await ctx.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync().ConfigureAwait(false);

                        return dimensionStructure;
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync().ConfigureAwait(false);
                        throw new MasterDataBusinessLogicAddTopDimensionStructureAsyncOperationException(e.Message, e);
                    }
                }
            }
        }
    }
}