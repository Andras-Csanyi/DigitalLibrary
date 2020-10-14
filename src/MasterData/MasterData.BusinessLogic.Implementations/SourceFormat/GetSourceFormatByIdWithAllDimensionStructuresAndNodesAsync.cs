namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc />
        public async Task<SourceFormat> GetSourceFormatByIdWithAllDimensionStructuresAndNodesAsync(
            SourceFormat sourceFormat)
        {
            try
            {
                Check.IsNotNull(sourceFormat);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    SourceFormat result = await ctx.SourceFormats
                       .AsNoTracking()
                       .Include(i => i.DimensionStructureNodes).ThenInclude(ii => ii.DimensionStructure)
                       .FirstOrDefaultAsync(w => w.Id == sourceFormat.Id)
                       .ConfigureAwait(false);

                    return result;
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                    $"{nameof(GetSourceFormatByIdWithAllDimensionStructuresAndNodesAsync)} " +
                    $"operation failed. For further info see inner exception.";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }
    }
}