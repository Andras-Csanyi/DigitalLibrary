namespace DigitalLibrary.Ui.WebUi.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
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
                Console.WriteLine($"{nameof(SourceFormatBuilderService)}.{nameof(Update)}");
            }
        }

        public async Task ReplaceDimensionStructureInTheTree(long oldDimensionStructureId, long newDimensionStructureId)
        {
            throw new NotImplementedException();
        }

        public async Task OnUpdate(long sourceFormatId)
        {
            Check.AreNotEqual(sourceFormatId, 0);
            SourceFormat querySourceFormat = new SourceFormat { Id = sourceFormatId };
            _sourceFormat = await _masterDataHttpClient.GetSourceFormatWithFullDimensionStructureTreeAsync(
                    querySourceFormat)
               .ConfigureAwait(false);
            await Update().ConfigureAwait(false);
        }

        public async Task DeleteDimensionStructureRootAsync(DimensionStructure dimensionStructure)
        {
            Check.IsNotNull(dimensionStructure);
            await CheckIfSourceFormatIsNull().ConfigureAwait(false);

            _sourceFormat.RootDimensionStructure = null;
            _sourceFormat.RootDimensionStructureId = null;
        }

        public async Task AddDimensionStructureRootAsync(long dimensionStructureId)
        {
            Check.AreNotEqual(dimensionStructureId, 0);
            DimensionStructure result = await GetDimensionStructureByIdAsync(dimensionStructureId)
               .ConfigureAwait(false);
            await AddDimensionStructureRootAsync(result).ConfigureAwait(false);
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

        public async Task<DimensionStructure> GetDimensionStructureByIdAsync(long dimensionStructureId)
        {
            Check.AreNotEqual(dimensionStructureId, 0);
            DimensionStructure query = new DimensionStructure { Id = dimensionStructureId };
            DimensionStructure result = await _masterDataHttpClient.GetDimensionStructureByIdAsync(query)
               .ConfigureAwait(false);
            return result;
        }

        public async Task AddDocumentStructureToTreeAsync(
            long dimensionStructureId,
            long parentDimensionStructureId)
        {
            Check.AreNotEqual(dimensionStructureId, 0);
            Check.AreNotEqual(parentDimensionStructureId, 0);

            DimensionStructure dimensionStructureToBeAdded = await GetDimensionStructureByIdAsync(
                dimensionStructureId).ConfigureAwait(false);

            if (_sourceFormat.RootDimensionStructureId == parentDimensionStructureId)
            {
                _sourceFormat.RootDimensionStructure.ChildDimensionStructures.Add(dimensionStructureToBeAdded);
            }
            else
            {
                if (_sourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
                {
                    await IterateThroughTheTreeForAdding(
                        dimensionStructureToBeAdded,
                        _sourceFormat.RootDimensionStructure.ChildDimensionStructures,
                        parentDimensionStructureId).ConfigureAwait(false);
                }
            }
        }

        private async Task IterateThroughTheTreeForAdding(
            DimensionStructure dimensionStructureToBeAdded,
            ICollection<DimensionStructure> dimensionStructures,
            long parentDimensionStructureId)
        {
            Check.IsNotNull(dimensionStructureToBeAdded);
            Check.AreNotEqual(parentDimensionStructureId, 0);

            if (dimensionStructures.Any())
            {
                foreach (DimensionStructure dimensionStructure in dimensionStructures)
                {
                    if (dimensionStructure.Id == parentDimensionStructureId)
                    {
                        dimensionStructure.ChildDimensionStructures.Add(dimensionStructureToBeAdded);
                    }
                    else
                    {
                        await IterateThroughTheTreeForAdding(
                                dimensionStructureToBeAdded,
                                dimensionStructure.ChildDimensionStructures,
                                parentDimensionStructureId)
                           .ConfigureAwait(false);
                    }
                }
            }
        }

        public async Task DeleteDocumentStructureFromTreeAsync(long documentStructureId)
        {
            Check.AreNotEqual(documentStructureId, 0);

            await RemoveItemFromTreeAsync(documentStructureId).ConfigureAwait(false);
            await Update().ConfigureAwait(false);
        }

        private async Task RemoveItemFromTreeAsync(long documentStructureId)
        {
            Check.AreNotEqual(documentStructureId, 0);
            if (_sourceFormat.RootDimensionStructure.Id == documentStructureId)
            {
                _sourceFormat.RootDimensionStructure = null;
                _sourceFormat.RootDimensionStructureId = 0;
            }
            else
            {
                if (_sourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
                {
                    await RemoveItemRecursivelyAsync(_sourceFormat.RootDimensionStructure, documentStructureId)
                       .ConfigureAwait(false);
                }
            }
        }

        private async Task RemoveItemRecursivelyAsync(
            DimensionStructure dimensionStructure,
            long documentStructureId)
        {
            Check.IsNotNull(dimensionStructure);

            if (dimensionStructure.ChildDimensionStructures != null)
            {
                if (dimensionStructure.ChildDimensionStructures.Any())
                {
                    for (int i = 0; i < dimensionStructure.ChildDimensionStructures.Count; i++)
                    {
                        if (dimensionStructure.ChildDimensionStructures.ElementAt(i).Id == documentStructureId)
                        {
                            dimensionStructure.ChildDimensionStructures.Remove(
                                dimensionStructure.ChildDimensionStructures.ElementAt(i)
                            );
                            break;
                        }

                        await RemoveItemRecursivelyAsync(
                                dimensionStructure.ChildDimensionStructures.ElementAt(i),
                                documentStructureId)
                           .ConfigureAwait(false);
                    }
                }
            }
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
        Task OnUpdate(long sourceFormatId);

        Task DeleteDocumentStructureFromTreeAsync(long documentStructureId);

        Task<DimensionStructure> GetDimensionStructureFromTreeByIdAsync(long dimensionStructureId);

        Task DeleteDimensionStructureRootAsync(DimensionStructure dimensionStructure);

        Task AddDimensionStructureRootAsync(DimensionStructure dimensionStructure);

        Task AddDimensionStructureRootAsync(long dimensionStructureId);

        SourceFormat SourceFormat { get; }

        event Func<Task> Notify;

        Task AddDimensionStructureAsync(
            long parentDimensionStructureId,
            DimensionStructure dimensionStructure);

        Task AddDocumentStructureToTreeAsync(
            long documentStructureId,
            long parentDimensionStructureId);

        Task<DimensionStructure> GetDimensionStructureByIdAsync(long dimensionStructureId);

        Task Update();

        Task ReplaceDimensionStructureInTheTree(long oldDimensionStructureId, long newDimensionStructureId);
    }
}