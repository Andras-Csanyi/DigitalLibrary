namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
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

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        /// <inheritdoc/>
        public async Task DeleteAsync(
            DimensionStructure tobeDeleted,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.IsNotNull(tobeDeleted);

                await _masterDataValidators.DimensionStructureValidator.ValidateAndThrowAsync(
                        tobeDeleted,
                        ruleSet: DimensionStructureValidatorRulesets.Delete)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructure res = await ctx.DimensionStructures
                       .FirstOrDefaultAsync(w => w.Id == tobeDeleted.Id, cancellationToken)
                       .ConfigureAwait(false);

                    if (res != null)
                    {
                        ctx.DimensionStructures.Remove(res);
                        await ctx.SaveChangesAsync(cancellationToken)
                           .ConfigureAwait(false);
                    }
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataDimensionStructureBusinessLogic)}." +
                             $"{nameof(DeleteAsync)} operation failed. " +
                             $"For further details see inner exception!";
                throw new MasterDataBusinessLogicDimensionStructureDatabaseOperationException(msg, e);
            }
        }
    }
}