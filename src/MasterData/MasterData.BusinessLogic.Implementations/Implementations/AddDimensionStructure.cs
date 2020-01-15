namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using DomainModel.DomainModel;

    using Exceptions.Exceptions;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    using Validators.Validators;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> AddDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync()
                    .ConfigureAwait(false))
                {
                    try
                    {
                        if (dimensionStructure == null)
                        {
                            throw new MasterDataBusinessLogicArgumentNullException();
                        }

                        await _masterDataValidators.DimensionStructureValidator.ValidateAndThrowAsync(
                                dimensionStructure,
                                ValidatorRulesets.AddNewDimensionStructure)
                            .ConfigureAwait(false);

                        DimensionStructure parent = await ctx.DimensionStructures
                            .FindAsync(dimensionStructure.ParentDimensionStructureId)
                            .ConfigureAwait(false);

                        if (parent == null)
                        {
                            string noSuchErrMsg = $"No dimension structure with id: " +
                                                  $"{dimensionStructure.ParentDimensionStructureId}.";
                            throw new MasterDataBusinessLogicNoSuchTopDimensionStructureEntity(noSuchErrMsg);
                        }

                        if (dimensionStructure.DimensionId != null && dimensionStructure.DimensionId != 0)
                        {
                            Dimension dimension = await ctx.Dimensions.FindAsync(dimensionStructure.DimensionId)
                                .ConfigureAwait(false);

                            if (dimension == null)
                            {
                                string noSuchErrMsg = $"No dimension with id: " +
                                                      $"{dimensionStructure.DimensionId}.";
                                throw new MasterDataBusinessLogicNoSuchTopDimensionStructureEntity(noSuchErrMsg);
                            }
                        }

                        await ctx.DimensionStructures.AddAsync(dimensionStructure)
                            .ConfigureAwait(false);
                        await ctx.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync().ConfigureAwait(false);

                        DimensionStructure result = await ctx.DimensionStructures
                            .Include(i => i.ChildDimensionStructures)
                            .ThenInclude(theni => theni.Dimension)
                            .Include(ii => ii.Dimension)
                            .FirstOrDefaultAsync(w => w.Id == dimensionStructure.Id)
                            .ConfigureAwait(false);

                        return result;
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync().ConfigureAwait(false);
                        throw new MasterDataBusinessLogicAddDimensionStructureAsyncOperationException(e.Message, e);
                    }
                }
            }
        }
    }
}