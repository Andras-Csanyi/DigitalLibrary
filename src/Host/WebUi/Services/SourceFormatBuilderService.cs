namespace DigitalLibrary.Ui.WebUi.Services
{
    using System;
    using System.Threading.Tasks;

    using MasterData.DomainModel;
    using MasterData.WebApi.Client;

    using Utils.Guards;

    public class SourceFormatBuilderService : ISourceFormatBuilderService
    {
        private IMasterDataHttpClient _masterDataHttpClient;

        public SourceFormatBuilderService(IMasterDataHttpClient masterDataHttpClient)
        {
            _masterDataHttpClient = masterDataHttpClient;
        }

        public event Func<Task> Notify;

        private SourceFormat _sourceFormat;

        public SourceFormat SourceFormat
        {
            get => _sourceFormat;
            set => _sourceFormat = value;
        }

        public async Task Update()
        {
            await Notify.Invoke().ConfigureAwait(false);
        }

        public async Task Init(long sourceFormatId)
        {
            Check.AreNotEqual(sourceFormatId, 0);
            SourceFormat querySourceFormat = new SourceFormat { Id = sourceFormatId };
            _sourceFormat = await _masterDataHttpClient.GetSourceFormatWithFullDimensionStructureTreeAsync(
                    querySourceFormat)
               .ConfigureAwait(false);
        }

        public async Task DeleteDocumentStructureFromTreeAsync(long documentStructureId)
        {
        }
    }

    public interface ISourceFormatBuilderService
    {
        Task Init(long sourceFormatId);

        Task DeleteDocumentStructureFromTreeAsync(long documentStructureId);

        Task<DimensionStructure> GetDimensionStructureFromTreeByIdAsync(in long dimensionStructureId);
    }
}