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
        public async Task<int> GetAmountOfDimensionStructureNodeOfSourceFormatAsync(
            SourceFormat sf,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.IsNotNull(sf);

                await _masterDataValidators.SourceFormatValidator.ValidateAsync(sf, o =>
                        {
                            o.IncludeRuleSets(SourceFormatValidatorRulesets
                               .GetAmountOfDimensionStructureNodeOfSourceFormat);
                            o.ThrowOnFailures();
                        },
                        cancellationToken)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    return await ctx.DimensionStructureNodes.CountAsync(
                            p => p.SourceFormatId == sf.Id,
                            cancellationToken)
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                             $"{nameof(GetAmountOfDimensionStructureNodeOfSourceFormatAsync)} operation failed. " +
                             "For further information see inner exception.";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }
    }
}