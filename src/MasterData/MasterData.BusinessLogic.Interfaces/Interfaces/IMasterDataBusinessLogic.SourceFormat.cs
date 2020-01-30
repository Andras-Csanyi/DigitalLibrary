namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataBusinessLogic
    {
        Task<SourceFormat> AddSourceFormatAsync(SourceFormat sourceFormat);

        Task<List<SourceFormat>> GetSourceFormatsAsync();

        Task<long> CountSourceFormatsAsync();

        Task<SourceFormat> UpdateSourceFormatAsync(SourceFormat sourceFormat);

        Task DeleteSourceFormatAsync(SourceFormat secondResult);

        Task<SourceFormat> GetSourceFormatByIdAsync(long sourceFormatId);
    }
}