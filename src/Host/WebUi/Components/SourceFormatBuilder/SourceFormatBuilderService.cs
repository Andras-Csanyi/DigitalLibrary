namespace DigitalLibrary.Ui.WebUi.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;

    using FluentValidation;

    using MasterData.BusinessLogic.ViewModels;
    using MasterData.DomainModel;
    using MasterData.Validators;
    using MasterData.WebApi.Client;

    using Utils.Guards;

    public class SourceFormatBuilderService : ISourceFormatBuilderService
    {
        private IMasterDataHttpClient _masterDataHttpClient;

        private bool foundDuringDimensionStructureReplaceInTheTree = false;

        public SourceFormatBuilderService(
            IMasterDataHttpClient masterDataHttpClient,
            IMasterDataValidators masterDataValidators)
        {
            Check.IsNotNull(masterDataHttpClient);
            Check.IsNotNull(masterDataValidators);

            _masterDataHttpClient = masterDataHttpClient;
            MasterDataValidators = masterDataValidators;
        }

        public bool IsLoadSourceFormatsButtonDisabled { get; set; } = false;

        public bool IsSourceFormatSaveButtonDisabled { get; set; } = false;

        public bool IsSourceFormatCancelButtonDisabled { get; set; } = false;

        public bool IsEditSourceFormatDetailsButtonDisabled { get; set; } = false;

        public event Func<Task> Notify;

        private SourceFormat _sourceFormat = new SourceFormat();

        public IMasterDataValidators MasterDataValidators { get; }

        public SourceFormat SourceFormat
        {
            get => _sourceFormat;
            set => _sourceFormat = value;
        }

        public bool IsSourceFormatDropDownlistDisabled { get; set; } = false;

        public bool IsNewSourceFormatButtonDisabled { get; set; } = false;

        public async Task Update()
        {
            if (Notify != null)
            {
                await Notify.Invoke().ConfigureAwait(false);
            }
        }

        public async Task ReplaceDimensionStructureInTheTree(
            long oldDimensionStructureId,
            long newDimensionStructureId)
        {
            Check.AreNotEqual(oldDimensionStructureId, 0);
            Check.AreNotEqual(newDimensionStructureId, 0);

            if (SourceFormat.RootDimensionStructureId == oldDimensionStructureId)
            {
                await ReplaceRootDimensionStructureAsync(newDimensionStructureId).ConfigureAwait(false);
                await Update().ConfigureAwait(false);
                return;
            }

            if (SourceFormat?.RootDimensionStructure?.ChildDimensionStructures != null)
            {
                if (SourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
                {
                    foundDuringDimensionStructureReplaceInTheTree = false;

                    await IterateThroughTheTreeForReplacing(
                            oldDimensionStructureId,
                            newDimensionStructureId,
                            SourceFormat.RootDimensionStructure)
                       .ConfigureAwait(false);

                    if (foundDuringDimensionStructureReplaceInTheTree == false)
                    {
                        string msg = $"There is no DocumentStructure with id {oldDimensionStructureId} " +
                                     $"in the tree.";
                        throw new SourceFormatBuilderServiceException(msg);
                    }

                    await Update().ConfigureAwait(false);
                }
            }

            await Update().ConfigureAwait(false);
        }

        public async Task<List<SourceFormat>> GetSourceFormatsAsync()
        {
            return await _masterDataHttpClient.GetSourceFormatsAsync().ConfigureAwait(false);
        }

        public async Task<List<DimensionStructure>> GetDimensionStructuresAsync()
        {
            return await _masterDataHttpClient.GetDimensionStructuresAsync().ConfigureAwait(false);
        }

        public async Task SaveNewRootDimensionStructureAsync(DimensionStructure newRootDimensionStructure)
        {
            await MasterDataValidators.DimensionStructureValidator
               .ValidateAndThrowAsync(newRootDimensionStructure)
               .ConfigureAwait(false);
            await _masterDataHttpClient.AddDimensionStructureAsync(newRootDimensionStructure)
               .ConfigureAwait(false);
        }

        public async Task<List<Dimension>> GetAllDimensions()
        {
            return await _masterDataHttpClient.GetDimensionsAsync().ConfigureAwait(false);
        }

        private async Task IterateThroughTheTreeForReplacing(
            long oldDimensionStructureId,
            long newDimensionStructureId,
            DimensionStructure dimensionStructure)
        {
            Check.AreNotEqual(oldDimensionStructureId, 0);
            Check.AreNotEqual(newDimensionStructureId, 0);
            Check.IsNotNull(dimensionStructure);

            if (dimensionStructure.ChildDimensionStructures.Any())
            {
                for (int i = 0; i < dimensionStructure.ChildDimensionStructures.Count; i++)
                {
                    if (foundDuringDimensionStructureReplaceInTheTree)
                    {
                        break;
                    }

                    if (dimensionStructure.ChildDimensionStructures.ElementAt(i).Id == oldDimensionStructureId)
                    {
                        DimensionStructure newDimensionStructure =
                            await GetDimensionStructureByIdAsync(newDimensionStructureId)
                               .ConfigureAwait(false);
                        dimensionStructure.ChildDimensionStructures.Remove(
                            dimensionStructure.ChildDimensionStructures.ElementAt(i));
                        dimensionStructure.ChildDimensionStructures.Add(newDimensionStructure);
                        foundDuringDimensionStructureReplaceInTheTree = true;
                    }
                    else
                    {
                        await IterateThroughTheTreeForReplacing(
                                oldDimensionStructureId,
                                newDimensionStructureId,
                                dimensionStructure.ChildDimensionStructures.ElementAt(i))
                           .ConfigureAwait(false);
                    }
                }
            }
        }

        private async Task ReplaceRootDimensionStructureAsync(long newRootDimensionStructureId)
        {
            Check.AreNotEqual(newRootDimensionStructureId, 0);
            SourceFormat.RootDimensionStructureId = newRootDimensionStructureId;
            DimensionStructure newRootDimensionStructure =
                await GetDimensionStructureByIdAsync(newRootDimensionStructureId)
                   .ConfigureAwait(false);
            SourceFormat.RootDimensionStructure = newRootDimensionStructure;
            await Update().ConfigureAwait(false);
        }

        public async Task OnUpdate(long sourceFormatId)
        {
            Check.AreNotEqual(0, sourceFormatId);
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
            DimensionStructureQueryObject query = new DimensionStructureQueryObject
            {
                GetDimensionsStructuredById = dimensionStructureId,
                IncludeChildrenWhenGetDimensionStructureById = true,
            };
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
            await RemoveItemFromTreeAsync(documentStructureId).ConfigureAwait(false);
            await Update().ConfigureAwait(false);
        }

        private async Task RemoveItemFromTreeAsync(long documentStructureId)
        {
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

        SourceFormat SourceFormat { get; set; }

        bool IsSourceFormatDropDownlistDisabled { get; set; }

        bool IsNewSourceFormatButtonDisabled { get; set; }

        bool IsLoadSourceFormatsButtonDisabled { get; set; }

        bool IsSourceFormatSaveButtonDisabled { get; set; }

        bool IsSourceFormatCancelButtonDisabled { get; set; }

        bool IsEditSourceFormatDetailsButtonDisabled { get; set; }

        IMasterDataValidators MasterDataValidators { get; }

        event Func<Task> Notify;

        Task AddDimensionStructureAsync(
            long parentDimensionStructureId,
            DimensionStructure dimensionStructure);

        Task AddDocumentStructureToTreeAsync(
            long documentStructureId,
            long parentDimensionStructureId);

        Task<DimensionStructure> GetDimensionStructureByIdAsync(long dimensionStructureId);

        Task Update();

        Task ReplaceDimensionStructureInTheTree(
            long oldDimensionStructureId,
            long newDimensionStructureId);

        Task<List<SourceFormat>> GetSourceFormatsAsync();

        Task<List<DimensionStructure>> GetDimensionStructuresAsync();

        Task SaveNewRootDimensionStructureAsync(DimensionStructure newRootDimensionStructure);

        Task<List<Dimension>> GetAllDimensions();
    }
}