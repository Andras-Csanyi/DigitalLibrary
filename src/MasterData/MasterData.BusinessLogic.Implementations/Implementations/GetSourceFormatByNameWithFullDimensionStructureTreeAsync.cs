namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<SourceFormat> GetSourceFormatByNameWithFullDimensionStructureTreeAsync(
            SourceFormat sourceFormat)
        {
            try
            {
                await _masterDataValidators.SourceFormatValidator.ValidateAndThrowAsync(
                        sourceFormat,
                        ruleSet: SourceFormatValidatorRulesets.GetByName)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    SourceFormat result = await ctx.SourceFormats
                       .Include(i => i.RootDimensionStructure)
                       .FirstOrDefaultAsync(p => p.Name.Equals(sourceFormat.Name))
                       .ConfigureAwait(false);

                    result.RootDimensionStructure.ChildDimensionStructures = await GetDimensionStructureTreeAsync(
                            result.RootDimensionStructure.Id,
                            ctx)
                       .ConfigureAwait(false);

                    return result;
                }
            }
            catch (Exception e)
            {
                string message = $"The {nameof(GetSourceFormatByNameWithFullDimensionStructureTreeAsync)} " +
                                 $"operation failed. See details in the inner exception.";
                throw new MasterDataBusinessLogicException(message, e);
            }
        }
    }
}