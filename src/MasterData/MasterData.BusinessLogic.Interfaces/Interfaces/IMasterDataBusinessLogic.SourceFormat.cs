// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataBusinessLogic
    {
        Task<SourceFormat> AddSourceFormatAsync(SourceFormat sourceFormat);

        Task<long> CountSourceFormatsAsync();

        Task DeleteSourceFormatAsync(SourceFormat secondResult);

        Task<SourceFormat> GetSourceFormatByIdAsync(SourceFormat sourceFormat);

        Task<SourceFormat> GetSourceFormatByIdWithFullDimensionStructureTreeAsync(SourceFormat querySourceFormat);

        Task<List<SourceFormat>> GetSourceFormatsAsync();

        Task<SourceFormat> UpdateSourceFormatAsync(SourceFormat sourceFormat);
    }
}