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
        public async Task<SourceFormat> UpdateSourceFormatAsync(SourceFormat sourceFormat)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync()
                   .ConfigureAwait(false))
                {
                    try
                    {
                        if (sourceFormat == null)
                        {
                            string msg = $"{nameof(sourceFormat)} is null.";
                            throw new MasterDataBusinessLogicArgumentNullException(msg);
                        }

                        await _masterDataValidators.SourceFormatValidator.ValidateAndThrowAsync(
                                sourceFormat,
                                SourceFormatValidatorRulesets.Update)
                           .ConfigureAwait(false);

                        SourceFormat toBeModified = await ctx.SourceFormats
                           .FindAsync(sourceFormat.Id)
                           .ConfigureAwait(false);

                        if (toBeModified == null)
                        {
                            string msg =
                                $"There is no {nameof(SourceFormat)} entity with id: {sourceFormat.Id}.";
                            throw new MasterDataBusinessLogicNoSuchSourceFormatEntityException(msg);
                        }

                        toBeModified.Name = sourceFormat.Name;
                        toBeModified.Desc = sourceFormat.Desc;
                        toBeModified.IsActive = sourceFormat.IsActive;

                        ctx.Entry(toBeModified).State = EntityState.Modified;
                        await ctx.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync().ConfigureAwait(false);

                        return toBeModified;
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync().ConfigureAwait(false);
                        throw new MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException(
                            e.Message,
                            e);
                    }
                }
            }
        }
    }
}