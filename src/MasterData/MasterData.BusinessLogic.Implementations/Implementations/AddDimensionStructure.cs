namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Linq;
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

                        long newDimensionStructureId = 0;
                        if (dimensionStructure.SourceFormats.Any())
                        {
                            newDimensionStructureId = await AddDimensionStructureWithSourceFormat(
                                dimensionStructure,
                                ctx).ConfigureAwait(false);
                        }
                        else
                        {
                            newDimensionStructureId = await AddDimensionStructureWithoutSourceFormat(
                                dimensionStructure,
                                ctx).ConfigureAwait(false);
                        }

                        DimensionStructure result = await ctx.DimensionStructures
                           .Include(i => i.ChildDimensionStructures)
                           .Include(ii => ii.SourceFormats)
                           .FirstOrDefaultAsync(w => w.Id == newDimensionStructureId)
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

        private async Task<long> AddDimensionStructureWithoutSourceFormat(
            DimensionStructure dimensionStructure,
            MasterDataContext ctx)
        {
            if (dimensionStructure == null || ctx == null)
            {
                string msg = $"Methodname: {nameof(AddDimensionStructureWithoutSourceFormat)}";
                throw new ArgumentNullException(msg);
            }

            DimensionStructure newDimensionStructure = new DimensionStructure
            {
                Name = dimensionStructure.Name,
                Desc = dimensionStructure.Desc,
                IsActive = dimensionStructure.IsActive,
                DimensionId = dimensionStructure.DimensionId,
            };
            await ctx.DimensionStructures.AddAsync(newDimensionStructure).ConfigureAwait(false);
            await ctx.SaveChangesAsync().ConfigureAwait(false);

            return newDimensionStructure.Id;
        }

        private async Task<long> AddDimensionStructureWithSourceFormat(
            DimensionStructure dimensionStructure,
            MasterDataContext ctx)
        {
            if (dimensionStructure == null || ctx == null)
            {
                string msg = $"Methodname: {nameof(AddDimensionStructureWithSourceFormat)}";
                throw new ArgumentNullException(msg);
            }

            long parentSourceFormatId = dimensionStructure.SourceFormats.FirstOrDefault().Id;

            if (parentSourceFormatId == 0)
            {
                string msg = $"The provided parent ({typeof(SourceFormat)}) id is invalid. " +
                             $"Its value is {parentSourceFormatId}";
                throw new MasterDataBusinessLogicAddDimensionStructureAsyncOperationException(msg);
            }

            SourceFormat parentSourceFormat = await ctx.SourceFormats.FindAsync(parentSourceFormatId)
               .ConfigureAwait(false);

            if (parentSourceFormat == null)
            {
                string msg = $"There is no {typeof(SourceFormat)} entity with id: {parentSourceFormatId}.";
                throw new MasterDataBusinessLogicNoSuchSourceFormatEntityException(msg);
            }

            DimensionStructure newDimensionStructure = new DimensionStructure
            {
                Name = dimensionStructure.Name,
                Desc = dimensionStructure.Desc,
                IsActive = dimensionStructure.IsActive,
                DimensionId = dimensionStructure.DimensionId,
            };
            await ctx.DimensionStructures.AddAsync(newDimensionStructure).ConfigureAwait(false);
            await ctx.SaveChangesAsync().ConfigureAwait(false);

            parentSourceFormat.RootDimensionStructureId = newDimensionStructure.Id;
            ctx.Entry(parentSourceFormat).State = EntityState.Modified;
            await ctx.SaveChangesAsync().ConfigureAwait(false);

            return newDimensionStructure.Id;
        }
    }
}