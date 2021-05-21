namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<SourceFormat> GetSourceFormatByNameWithFullDimensionStructureTreeAsync(
            SourceFormat sourceFormat)
        {
            // try
            // {
            //     await _masterDataValidators.SourceFormatValidator.ValidateAndThrowAsync(
            //             sourceFormat,
            //             ruleSet: SourceFormatValidatorRulesets.GetByName)
            //        .ConfigureAwait(false);
            //
            //     using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            //     {
            //         SourceFormat result = await ctx.SourceFormats
            //            .Include(i => i.DimensionStructureTreeRoot)
            //            .FirstOrDefaultAsync(p => p.Name.Equals(sourceFormat.Name))
            //            .ConfigureAwait(false);
            //
            //         // result.DimensionStructureTreeRoot.ChildDimensionStructureTreeNodes = await GetDimensionStructureTreeAsync(
            //         //         result.DimensionStructureTreeRoot.Id,
            //         //         ctx)
            //         //    .ConfigureAwait(false);
            //
            //         return result;
            //     }
            // }
            // catch (Exception e)
            // {
            //     string message = $"The {nameof(GetSourceFormatByNameWithFullDimensionStructureTreeAsync)} " +
            //                      $"operation failed. See details in the inner exception.";
            //     throw new MasterDataBusinessLogicException(message, e);
            // }
            throw new NotImplementedException();
        }
    }
}
