namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using FluentValidation;

    using Validators;

    public partial class MasterDataBusinessLogic
    {
        public async Task DeleteSourceFormatAsync(SourceFormat sourceFormat)
        {
            try
            {
                if (sourceFormat == null)
                {
                    throw new MasterDataBusinessLogicArgumentNullException(nameof(sourceFormat));
                }

                await _masterDataValidators.SourceFormatValidator.ValidateAndThrowAsync(
                        sourceFormat,
                        ruleSet: ValidatorRulesets.DeleteSourceFormat)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    SourceFormat result = await ctx.SourceFormats.FindAsync(sourceFormat.Id).ConfigureAwait(false);

                    if (result == null)
                    {
                        string msg = $"Ther is no {nameof(SourceFormat)} with id: {sourceFormat.Id}";
                        throw new MasterDataBusinessLogicNoSuchSourceFormatEntityException(msg);
                    }

                    ctx.SourceFormats.Remove(result);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException(e.Message, e);
            }
        }
    }
}