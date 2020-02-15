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
            Check.IsNotNull(masterDataHttpClient);
            _masterDataHttpClient = masterDataHttpClient;
        }

        public event Func<Task> Notify;

        private SourceFormat _sourceFormat;

        public SourceFormat SourceFormat
        {
            get => _sourceFormat;
        }

        public async Task Update()
        {
            if (Notify != null)
            {
                await Notify.Invoke().ConfigureAwait(false);
            }
        }

        public async Task Init(long sourceFormatId)
        {
            Check.AreNotEqual(sourceFormatId, 0);
            SourceFormat querySourceFormat = new SourceFormat { Id = sourceFormatId };
            _sourceFormat = await _masterDataHttpClient.GetSourceFormatWithFullDimensionStructureTreeAsync(
                    querySourceFormat)
               .ConfigureAwait(false);
        }

        public async Task DeleteDimensionStructureRootAsync(DimensionStructure dimensionStructure)
        {
            Check.IsNotNull(dimensionStructure);
            await CheckIfSourceFormatIsNull().ConfigureAwait(false);

            _sourceFormat.RootDimensionStructure = null;
            _sourceFormat.RootDimensionStructureId = null;
            await Update().ConfigureAwait(false);
        }

        public async Task AddDimensionStructureRootAsync(DimensionStructure dimensionStructure)
        {
            Check.IsNotNull(dimensionStructure);

            if (_sourceFormat.RootDimensionStructure != null)
            {
                string msg = "DimensionStructure in SourceFormat is not null.";
                throw new SourceFormatBuilderServiceException(msg);
            }

            _sourceFormat.RootDimensionStructure = dimensionStructure;
        }

        public async Task AddDimensionStructureAsync(
            long parentDimensionStructureId,
            DimensionStructure dimensionStructure)
        {
            Check.AreNotEqual(parentDimensionStructureId, 0);
            Check.IsNotNull(dimensionStructure);
        }

        public async Task DeleteDocumentStructureFromTreeAsync(long documentStructureId)
        {
            throw new NotImplementedException();
        }

        public async Task<DimensionStructure> GetDimensionStructureFromTreeByIdAsync(long dimensionStructureId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveSourceFormat()
        {
            // check whether all dimension structure has id, if not then create them before save
        }

        private async Task CheckIfSourceFormatIsNull()
        {
            if (_sourceFormat == null)
            {
                string msg = $"There is no SourceFormat set up.";
                throw new SourceFormatBuilderServiceException(msg);
            }
        }

        private async Task CheckDimensionStructureUniquenessInTree(DimensionStructure dimensionStructure)
        {
            throw new NotImplementedException();
        }
    }

    public interface ISourceFormatBuilderService
    {
        Task Init(long sourceFormatId);

        Task DeleteDocumentStructureFromTreeAsync(long documentStructureId);

        Task<DimensionStructure> GetDimensionStructureFromTreeByIdAsync(long dimensionStructureId);

        Task DeleteDimensionStructureRootAsync(DimensionStructure dimensionStructure);

        Task AddDimensionStructureRootAsync(DimensionStructure dimensionStructure);

        SourceFormat SourceFormat { get; }

        Task AddDimensionStructureAsync(
            long parentDimensionStructureId,
            DimensionStructure dimensionStructure);
    }
}