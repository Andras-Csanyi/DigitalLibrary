namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc/>
        public async Task AddRootDimensionStructureAsync(long sourceFormatId, long dimensionStructureId)
        {
            try
            {
                Check.AreNotEqual(sourceFormatId, 0);
                Check.AreNotEqual(dimensionStructureId, 0);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    SourceFormat sourceFormat = await ctx.SourceFormats.FindAsync(sourceFormatId)
                       .ConfigureAwait(false);
                    DimensionStructure dimensionStructure = await ctx.DimensionStructures
                       .FindAsync(dimensionStructureId)
                       .ConfigureAwait(false);

                    SourceFormatDimensionStructure sourceFormatDimensionStructure =
                        new SourceFormatDimensionStructure
                        {
                            DimensionStructure = dimensionStructure,
                            SourceFormat = sourceFormat,
                        };
                    await ctx.SourceFormatDimensionStructure.AddAsync(sourceFormatDimensionStructure)
                       .ConfigureAwait(false);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(AddRootDimensionStructureAsync)} operation failed!" +
                    $" For further information see inner exception.";
                throw new MasterDataBusinessLogicDatabaseOperationException(msg, e);
            }
        }
    }
}