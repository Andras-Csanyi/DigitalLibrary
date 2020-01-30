namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataHttpClient
    {
        Task<List<SourceFormat>> GetSourceFormatsAsync();

        Task<SourceFormat> UpdateSourceFormatAsync(SourceFormat sourceFormat);

        Task<SourceFormat> AddSourceFormatAsync(SourceFormat sourceFormat);

        Task DeleteSourceFormatAsync(SourceFormat sourceFormat);

        Task<SourceFormat> GetSourceFormatById(SourceFormat sourceFormat);
    }
}