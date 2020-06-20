namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.MasterData.WebApi.Client;
    using DigitalLibrary.Ui.WebUi.Services;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    public interface ISourceFormatBuilderService
    {
        Task OnUpdate(long sourceFormatId);

        Task DeleteDocumentStructureFromTreeAsync();

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

        long LoadedSourceFormatId { get; set; }

        DimensionStructure UpdateNodeOldDimensionStructure { get; set; }

        DimensionStructure UpdateNodeNewDimensionStructure { get; set; }

        DimensionStructure DimensionStructureToBeDeletedFromTree { get; set; }

        Task AddDimensionStructureAsync(
            long parentDimensionStructureId,
            DimensionStructure dimensionStructure);

        Task AddOrUpdateDocumentStructureToTreeAsync(
            DimensionStructure dimensionStructure,
            Guid parentDimensionStructureGuid);

        Task<DimensionStructure> GetDimensionStructureByIdAsync(long dimensionStructureId);

        Task UpdateSourceFormatBuilder();

        Task ReplaceDimensionStructureInTheTree();

        Task<List<SourceFormat>> GetSourceFormatsAsync();

        Task<List<DimensionStructure>> GetDimensionStructuresAsync();

        Task SaveNewRootDimensionStructureAsync(DimensionStructure newRootDimensionStructure);

        Task<List<Dimension>> GetAllDimensionsFromServer();

        Task SetDefaultStateForReplacementOfDimensionStructureInTree();

        Task<List<Dimension>> GetDimensionsWithNulloAsync();

        Task<bool> FindDimensionStructureInTreeAsync(
            DimensionStructure dimensionStructure,
            ICollection<DimensionStructure> dimensionStructures);

        Task SaveNewRootDimensionStructureHandlerAsync(DimensionStructure newRootDimensionStructure);
    }

    public class SourceFormatBuilderService : ISourceFormatBuilderService
    {
        private IMasterDataHttpClient _masterDataHttpClient;

        private bool _foundDuringDimensionStructureReplaceInTheTree;

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

        public DimensionStructure UpdateNodeOldDimensionStructure { get; set; }

        public DimensionStructure UpdateNodeNewDimensionStructure { get; set; }

        public DimensionStructure DimensionStructureToBeDeletedFromTree { get; set; }

        public event Func<Task> Notify;

        private SourceFormat _sourceFormat = new SourceFormat();

        public IMasterDataValidators MasterDataValidators { get; }

        public long LoadedSourceFormatId { get; set; }

        public SourceFormat SourceFormat
        {
            get => _sourceFormat;
            set => _sourceFormat = value;
        }

        public bool IsSourceFormatDropDownlistDisabled { get; set; } = false;

        public bool IsNewSourceFormatButtonDisabled { get; set; } = false;

        private List<Dimension> _dimensions = new List<Dimension>();

        private List<Dimension> _alreadyUsedDimensions = new List<Dimension>();

        private List<Dimension> _availableDimensions = new List<Dimension>();

        private IDomainEntityHelperService _domainEntityHelperService;

        private IDimensionDomainEntityHelperService _dimensionDomainEntityHelperService;

        private async Task<List<Dimension>> GetDimensions()
        {
            return await _masterDataHttpClient.GetDimensionsAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Saves the new RootDimensionStructure for DocumentStructure. Saving means it setups the properties
        /// of the service accordingly.
        /// </summary>
        /// <param name="newRootDimensionStructure">The new RootDimensionStructure</param>
        /// <returns>Task</returns>
        /// <exception cref="SourceFormatBuilderServiceException">General exception wrapping other exception.</exception>
        public async Task SaveNewRootDimensionStructureHandlerAsync(
            DimensionStructure newRootDimensionStructure)
        {
            try
            {
                Check.IsNotNull(newRootDimensionStructure);

                await MasterDataValidators.DimensionStructureValidator
                   .ValidateAndThrowAsync(
                        newRootDimensionStructure,
                        ruleSet: DimensionStructureValidatorRulesets.Add)
                   .ConfigureAwait(false);
                newRootDimensionStructure.Guid = Guid.NewGuid();

                SourceFormat.RootDimensionStructure = newRootDimensionStructure;

                if (newRootDimensionStructure.DimensionId != null)
                {
                    SourceFormat.RootDimensionStructure.DimensionId =
                        newRootDimensionStructure.DimensionId;

                    long id = newRootDimensionStructure.DimensionId ?? default(int);
                    Dimension selectedDimension = await _masterDataHttpClient.GetDimensionByIdAsync(id)
                       .ConfigureAwait(false);

                    SourceFormat.RootDimensionStructure.Dimension = selectedDimension;
                }
            }
            catch (Exception e)
            {
                string msg = $"Something went wrong during saving {newRootDimensionStructure.Name}";
                throw new SourceFormatBuilderServiceException(msg, e);
            }
        }

        public async Task UpdateSourceFormatBuilder()
        {
            throw new NotImplementedException();
        }

        public async Task ReplaceDimensionStructureInTheTree()
        {
            Check.IsNotNull(UpdateNodeOldDimensionStructure);
            Check.IsNotNull(UpdateNodeNewDimensionStructure);

            if (SourceFormat.RootDimensionStructure == UpdateNodeOldDimensionStructure)
            {
                await ReplaceRootDimensionStructureAsync(UpdateNodeNewDimensionStructure).ConfigureAwait(false);
                return;
            }

            if (SourceFormat?.RootDimensionStructure?.ChildDimensionStructures != null)
            {
                if (SourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
                {
                    _foundDuringDimensionStructureReplaceInTheTree = false;

                    await IterateThroughTheTreeForReplacing(
                            UpdateNodeOldDimensionStructure,
                            UpdateNodeNewDimensionStructure,
                            SourceFormat.RootDimensionStructure)
                       .ConfigureAwait(false);

                    if (_foundDuringDimensionStructureReplaceInTheTree == false)
                    {
                        string msg = $"There is no DocumentStructure with id {UpdateNodeOldDimensionStructure} " +
                                     $"in the tree.";
                        throw new SourceFormatBuilderServiceException(msg);
                    }
                }
            }
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

        public async Task<List<Dimension>> GetAllDimensionsFromServer()
        {
            return await _masterDataHttpClient.GetDimensionsAsync().ConfigureAwait(false);
        }

        public async Task<List<Dimension>> GetDimensionsWithNulloAsync()
        {
            List<Dimension> availableDimensions = await GetAllDimensionsFromServer().ConfigureAwait(false);
            List<Dimension> availableDimensionsWithNullo = await _domainEntityHelperService
               .AddNulloToListAsFirstItem(availableDimensions)
               .ConfigureAwait(false);
            return availableDimensionsWithNullo;
        }

        public async Task SetDefaultStateForReplacementOfDimensionStructureInTree()
        {
            UpdateNodeNewDimensionStructure = null;
            UpdateNodeOldDimensionStructure = null;
        }

        private async Task IterateThroughTheTreeForReplacing(
            DimensionStructure oldDimensionStructure,
            DimensionStructure newDimensionStructure,
            DimensionStructure dimensionStructureTree)
        {
            Check.IsNotNull(oldDimensionStructure);
            Check.IsNotNull(newDimensionStructure);
            Check.IsNotNull(dimensionStructureTree);

            if (dimensionStructureTree.ChildDimensionStructures.Any())
            {
                for (int i = 0; i < dimensionStructureTree.ChildDimensionStructures.Count; i++)
                {
                    if (_foundDuringDimensionStructureReplaceInTheTree)
                    {
                        break;
                    }

                    if (dimensionStructureTree.ChildDimensionStructures.ElementAt(i).Guid == oldDimensionStructure.Guid)
                    {
                        DimensionStructure newDimensionStructureFromServer =
                            await GetDimensionStructureByIdAsync(newDimensionStructure.Id)
                               .ConfigureAwait(false);
                        dimensionStructureTree.ChildDimensionStructures.Remove(
                            dimensionStructureTree.ChildDimensionStructures.ElementAt(i));
                        dimensionStructureTree.ChildDimensionStructures.Add(newDimensionStructureFromServer);
                        _foundDuringDimensionStructureReplaceInTheTree = true;
                    }
                    else
                    {
                        await IterateThroughTheTreeForReplacing(
                                oldDimensionStructure,
                                newDimensionStructure,
                                dimensionStructureTree.ChildDimensionStructures.ElementAt(i))
                           .ConfigureAwait(false);
                    }
                }
            }
        }

        private async Task ReplaceRootDimensionStructureAsync(DimensionStructure newRootDimensionStructure)
        {
            Check.IsNotNull(newRootDimensionStructure);
            SourceFormat.RootDimensionStructureId = newRootDimensionStructure.Id;
            DimensionStructure newRootDimensionStructureFromServer =
                await GetDimensionStructureByIdAsync(newRootDimensionStructure.Id)
                   .ConfigureAwait(false);
            SourceFormat.RootDimensionStructure = newRootDimensionStructureFromServer;
        }

        public async Task OnUpdate(long sourceFormatId)
        {
            Check.AreNotEqual(0, sourceFormatId);
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
        }

        public async Task AddDimensionStructureRootAsync(long dimensionStructureId)
        {
            Check.AreNotEqual(dimensionStructureId, 0);
            DimensionStructure result = await GetDimensionStructureByIdAsync(dimensionStructureId)
               .ConfigureAwait(false);
            await AddDimensionStructureRootAsync(result).ConfigureAwait(false);
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
            _sourceFormat.RootDimensionStructureId = dimensionStructure.Id;
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

        public async Task AddOrUpdateDocumentStructureToTreeAsync(
            DimensionStructure dimensionStructure,
            Guid parentDimensionStructureGuid)
        {
            Check.IsNotNull(dimensionStructure);
            Check.AreNotEqual(parentDimensionStructureGuid, Guid.Empty);

            if (dimensionStructure.Guid == _sourceFormat.RootDimensionStructure.Guid)
            {
                _sourceFormat.RootDimensionStructure.Name = dimensionStructure.Name;
                _sourceFormat.RootDimensionStructure.Desc = dimensionStructure.Desc;
                _sourceFormat.RootDimensionStructure.DimensionId = dimensionStructure.DimensionId;
                _sourceFormat.RootDimensionStructure.Dimension = dimensionStructure.Dimension;
                _sourceFormat.RootDimensionStructure.IsActive = dimensionStructure.IsActive;
                return;
            }

            bool isFound = await FindDimensionStructureInTreeAsync(
                dimensionStructure,
                _sourceFormat.RootDimensionStructure.ChildDimensionStructures).ConfigureAwait(false);

            if (isFound)
            {
                if (_sourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
                {
                    await IterateThroughTheTreeForUpdating(
                            dimensionStructure,
                            _sourceFormat.RootDimensionStructure.ChildDimensionStructures)
                       .ConfigureAwait(false);
                }
            }
            else
            {
                if (_sourceFormat.RootDimensionStructure.Guid == parentDimensionStructureGuid)
                {
                    _sourceFormat.RootDimensionStructure.ChildDimensionStructures.Add(dimensionStructure);
                    return;
                }

                if (_sourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
                {
                    await IterateThroughTheTreeForAdding(
                            dimensionStructure,
                            _sourceFormat.RootDimensionStructure.ChildDimensionStructures,
                            parentDimensionStructureGuid)
                       .ConfigureAwait(false);
                }
            }
        }

        private async Task IterateThroughTheTreeForUpdating(
            DimensionStructure dimensionStructure,
            ICollection<DimensionStructure> childDimensionStructures)
        {
            Check.IsNotNull(dimensionStructure);

            if (childDimensionStructures.Any())
            {
                foreach (DimensionStructure childDimensionStructure in childDimensionStructures)
                {
                    if (childDimensionStructure.Guid == dimensionStructure.Guid)
                    {
                        childDimensionStructure.Name = dimensionStructure.Name;
                        childDimensionStructure.Desc = dimensionStructure.Desc;
                        childDimensionStructure.DimensionId = dimensionStructure.DimensionId;
                        childDimensionStructure.Dimension = dimensionStructure.Dimension;
                        childDimensionStructure.IsActive = dimensionStructure.IsActive;
                        return;
                    }

                    await IterateThroughTheTreeForUpdating(
                            dimensionStructure,
                            childDimensionStructure.ChildDimensionStructures)
                       .ConfigureAwait(false);
                }
            }
        }

        public async Task<bool> FindDimensionStructureInTreeAsync(
            DimensionStructure dimensionStructure,
            ICollection<DimensionStructure> dimensionStructures)
        {
            Check.IsNotNull(dimensionStructure);

            if (dimensionStructures.Any())
            {
                foreach (DimensionStructure structure in dimensionStructures)
                {
                    if (structure.Guid == dimensionStructure.Guid)
                    {
                        return true;
                    }

                    if (structure.ChildDimensionStructures.Any())
                    {
                        await FindDimensionStructureInTreeAsync(
                                dimensionStructure,
                                structure.ChildDimensionStructures)
                           .ConfigureAwait(false);
                    }
                }
            }

            return false;
        }

        private async Task IterateThroughTheTreeForAdding(
            DimensionStructure dimensionStructureToBeAdded,
            ICollection<DimensionStructure> dimensionStructures,
            Guid parentDimensionStructureGuid)
        {
            Check.IsNotNull(dimensionStructureToBeAdded);
            Check.AreNotEqual(parentDimensionStructureGuid, Guid.Empty);

            if (dimensionStructures.Any())
            {
                foreach (DimensionStructure dimensionStructure in dimensionStructures)
                {
                    if (dimensionStructure.Guid == parentDimensionStructureGuid)
                    {
                        dimensionStructure.ChildDimensionStructures.Add(dimensionStructureToBeAdded);
                    }
                    else
                    {
                        await IterateThroughTheTreeForAdding(
                                dimensionStructureToBeAdded,
                                dimensionStructure.ChildDimensionStructures,
                                parentDimensionStructureGuid)
                           .ConfigureAwait(false);
                    }
                }
            }
        }

        public async Task DeleteDocumentStructureFromTreeAsync()
        {
            await RemoveItemFromTreeAsync().ConfigureAwait(false);
        }

        private async Task RemoveItemFromTreeAsync()
        {
            Check.IsNotNull(DimensionStructureToBeDeletedFromTree);
            if (_sourceFormat.RootDimensionStructure.Guid == DimensionStructureToBeDeletedFromTree.Guid)
            {
                _sourceFormat.RootDimensionStructure = null;
                _sourceFormat.RootDimensionStructureId = 0;
            }
            else
            {
                if (_sourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
                {
                    await RemoveItemRecursivelyAsync(_sourceFormat.RootDimensionStructure,
                            DimensionStructureToBeDeletedFromTree.Guid)
                       .ConfigureAwait(false);
                }
            }
        }

        private async Task RemoveItemRecursivelyAsync(
            DimensionStructure dimensionStructure,
            Guid documentStructureGuid)
        {
            Check.IsNotNull(dimensionStructure);

            if (dimensionStructure.ChildDimensionStructures != null)
            {
                if (dimensionStructure.ChildDimensionStructures.Any())
                {
                    for (int i = 0; i < dimensionStructure.ChildDimensionStructures.Count; i++)
                    {
                        if (dimensionStructure.ChildDimensionStructures.ElementAt(i).Guid == documentStructureGuid)
                        {
                            dimensionStructure.ChildDimensionStructures.Remove(
                                dimensionStructure.ChildDimensionStructures.ElementAt(i)
                            );
                            break;
                        }

                        await RemoveItemRecursivelyAsync(
                                dimensionStructure.ChildDimensionStructures.ElementAt(i),
                                documentStructureGuid)
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
}