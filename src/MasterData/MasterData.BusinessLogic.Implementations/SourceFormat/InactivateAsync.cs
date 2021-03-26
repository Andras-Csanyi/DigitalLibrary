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

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc />
        public async Task InactivateAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.IsNotNull(sourceFormat);
                await _masterDataValidators.SourceFormatValidator.ValidateAsync(sourceFormat, o =>
                {
                    o.IncludeRuleSets(SourceFormatValidatorRulesets.Inactivate);
                    o.ThrowOnFailures();
                }, cancellationToken).ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    SourceFormat result = await ctx.SourceFormats.FirstOrDefaultAsync(
                            w => w.Id == sourceFormat.Id,
                            cancellationToken)
                       .ConfigureAwait(false);

                    if (result != null)
                    {
                        result.IsActive = 0;
                        ctx.Entry(result).State = EntityState.Modified;
                        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                    $"{nameof(InactivateAsync)} operation failed! " +
                    $"For further information see inner exception!";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }
    }
}