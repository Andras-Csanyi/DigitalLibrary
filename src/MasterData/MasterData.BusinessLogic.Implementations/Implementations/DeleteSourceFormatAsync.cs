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
        public async Task DeleteSourceFormatAsync(SourceFormat secondResult)
        {
            try
            {
                if (secondResult == null)
                {
                    throw new MasterDataBusinessLogicArgumentNullException(nameof(secondResult));
                }

                await _masterDataValidators.SourceFormatValidator.ValidateAndThrowAsync(
                        secondResult,
                        ruleSet: ValidatorRulesets.DeleteSourceFormat)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException(e.Message, e);
            }
        }
    }
}