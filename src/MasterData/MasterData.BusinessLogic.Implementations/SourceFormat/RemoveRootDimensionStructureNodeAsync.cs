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
        /// <inheritdoc/>
        public async Task RemoveRootDimensionStructureNodeAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.IsNotNull(sourceFormat);
                await _masterDataValidators.SourceFormatValidator.ValidateAsync(sourceFormat, o =>
                        {
                            o.IncludeProperties(SourceFormatValidatorRulesets.RemoveRootDimensionStructureNode);
                            o.ThrowOnFailures();
                        },
                        cancellationToken)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new(_dbContextOptions))
                {
                    SourceFormat targetSourceFormat = await ctx
                       .SourceFormats
                       .Include(i => i.SourceFormatDimensionStructureNode)
                       .FirstOrDefaultAsync(k => k.Id == sourceFormat.Id, cancellationToken)
                       .ConfigureAwait(false);
                    if (targetSourceFormat == null)
                    {
                        string msg = $"No {nameof(DimensionStructureNode)} with id: {sourceFormat.Id}.";
                        throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                    }

                    targetSourceFormat.SourceFormatDimensionStructureNode = null;
                    ctx.Entry(targetSourceFormat).State = EntityState.Modified;
                    await ctx.SaveChangesAsync(cancellationToken)
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(RemoveRootDimensionStructureNodeAsync)} operation failed! " +
                             $"For further info see inner exception!";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }
    }
}
