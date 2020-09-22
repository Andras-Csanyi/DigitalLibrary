namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.DomainModel;

    public partial class MasterDataBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<SourceFormat> GetSourceFormatByNameWithRootDimensionStructureAsync(SourceFormat sourceFormat)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                string msg = $"{nameof(GetSourceFormatByNameWithRootDimensionStructureAsync)} have failed." +
                    $"For further details see inner exception.";
                throw new MasterDataBusinessLogicException(msg, e);
            }
        }
    }
}