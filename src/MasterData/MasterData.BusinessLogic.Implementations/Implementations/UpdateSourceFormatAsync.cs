namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    using Validators;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> UpdateSourceFormatAsync(DimensionStructure dimensionStructure)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync())
                {
                    try
                    {
                        if (dimensionStructure == null)
                        {
                            string msg = $"{nameof(dimensionStructure)} is null.";
                            throw new MasterDataBusinessLogicArgumentNullException(msg);
                        }

                        await _masterDataValidators.SourceFormatValidator.ValidateAndThrowAsync(
                                dimensionStructure,
                                ValidatorRulesets.UpdateTopDimensionStructure)
                           .ConfigureAwait(false);

                        DimensionStructure toBeModified = await ctx.DimensionStructures
                           .FindAsync(dimensionStructure.Id)
                           .ConfigureAwait(false);

                        if (toBeModified == null)
                        {
                            string msg =
                                $"There is no {nameof(DimensionStructure)} entity with id: {dimensionStructure.Id}.";
                            throw new MasterDataBusinessLogicNoSuchTopDimensionStructureEntity(msg);
                        }

                        toBeModified.Name = dimensionStructure.Name;
                        toBeModified.Desc = dimensionStructure.Desc;
                        toBeModified.DimensionId = dimensionStructure.DimensionId;
                        toBeModified.ParentDimensionStructureId = dimensionStructure.ParentDimensionStructureId;
                        toBeModified.IsActive = dimensionStructure.IsActive;

                        ctx.Entry(toBeModified).State = EntityState.Modified;
                        await ctx.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync();

                        return toBeModified;
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync().ConfigureAwait(false);
                        throw new MasterDataBusinessLogicUpdateTopDimensionStructureAsyncOperationException(e.Message,
                            e);
                    }
                }
            }
        }
    }
}