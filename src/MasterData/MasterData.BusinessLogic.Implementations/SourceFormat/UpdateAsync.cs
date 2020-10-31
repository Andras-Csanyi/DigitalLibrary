namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
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

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<SourceFormat> UpdateAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.IsNotNull(sourceFormat);

                await _masterDataValidators.SourceFormatValidator
                   .ValidateAndThrowAsync(sourceFormat, ruleSet: SourceFormatValidatorRulesets.Update)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    SourceFormat target = await ctx
                       .SourceFormats
                       .FirstOrDefaultAsync(w => w.Id == sourceFormat.Id, cancellationToken)
                       .ConfigureAwait(false);

                    if (target != null)
                    {
                        target.Name = sourceFormat.Name;
                        target.Desc = sourceFormat.Desc;
                        target.IsActive = sourceFormat.IsActive;

                        ctx.Entry(target).State = EntityState.Modified;
                        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                        return await ctx.SourceFormats
                           .AsNoTracking()
                           .FirstOrDefaultAsync(w => w.Id == sourceFormat.Id, cancellationToken)
                           .ConfigureAwait(false);
                    }

                    string msg = $"There is no {nameof(SourceFormat)} entity in the system with " +
                                 $"id: {sourceFormat.Id}.";
                    throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                             $"{nameof(UpdateAsync)} operation failed! " +
                             $"For further information see inner exception!";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }
    }
}