namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    using Validators;

    public partial class MasterDataBusinessLogic
    {
        public async Task<SourceFormat> GetSourceFormatByIdAsync(SourceFormat sourceFormat)
        {
            try
            {
                await _masterDataValidators.SourceFormatValidator.ValidateAndThrowAsync(
                        sourceFormat,
                        SourceFormatValidatorRulesets.GetById)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    SourceFormat result = await ctx.SourceFormats
                       .AsNoTracking()
                       .Include(p => p.RootDimensionStructure)
                       .FirstOrDefaultAsync(id => id.Id == sourceFormat.Id)
                       .ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicGetSourceFormatByIdAsyncOperationException(e.Message, e);
            }
        }
    }
}