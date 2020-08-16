// <copyright file="SourceFormatBuilderService.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.MasterData.WebApi.Client;
    using DigitalLibrary.Ui.WebUi.Services;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    /// <inheritdoc />
    public class SourceFormatBuilderService : ISourceFormatBuilderService
    {
        private readonly IDomainEntityHelperService _domainEntityHelperService;

        private readonly IMasterDataHttpClient _masterDataHttpClient;

        private List<Dimension> _alreadyUsedDimensions = new List<Dimension>();

        private List<Dimension> _availableDimensions = new List<Dimension>();

        private IDimensionDomainEntityHelperService _dimensionDomainEntityHelperService;

        private List<Dimension> _dimensions = new List<Dimension>();

        /// <summary>
        ///     This field is used when we are executing either adding or replacing operation
        ///     against a node in the <see cref="DocumentStructure" /> tree.
        ///     This marks that we found the target in the tree.
        /// </summary>
        private bool _documentStructureIsFoundInTheTree;

        private bool _foundDuringDimensionStructureReplaceInTheTree;


        /// <summary>
        ///     Initializes a new instance of the <see cref="SourceFormatBuilderService" /> class.
        /// </summary>
        /// <param name="masterDataHttpClient">IMasterDataHttpClient</param>
        /// <param name="masterDataValidators">IMasterDataValidators</param>
        /// <param name="domainEntityHelperService">IDomainEntityHelperService</param>
        public SourceFormatBuilderService(
            IMasterDataHttpClient masterDataHttpClient,
            IMasterDataValidators masterDataValidators,
            IDomainEntityHelperService domainEntityHelperService)
        {
            Check.IsNotNull(masterDataHttpClient);
            Check.IsNotNull(masterDataValidators);
            Check.IsNotNull(domainEntityHelperService);

            _masterDataHttpClient = masterDataHttpClient;
            MasterDataValidators = masterDataValidators;
            _domainEntityHelperService = domainEntityHelperService;
        }

        /// <inheritdoc />
        public async Task AddDimensionStructureAsync(
            long parentDimensionStructureId,
            DimensionStructure dimensionStructure)
        {
            Check.AreNotEqual(parentDimensionStructureId, 0);
            Check.IsNotNull(dimensionStructure);
        }

        /// <inheritdoc />
        public async Task AddDimensionStructureRootAsync(long dimensionStructureId)
        {
            Check.AreNotEqual(dimensionStructureId, 0);
            DimensionStructure result = await GetDimensionStructureByIdAsync(dimensionStructureId)
               .ConfigureAwait(false);
            await AddDimensionStructureRootAsync(result).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task AddDimensionStructureRootAsync(DimensionStructure dimensionStructure)
        {
            Check.IsNotNull(dimensionStructure);

            if (SourceFormat.RootDimensionStructure != null)
            {
                string msg = "DimensionStructure in SourceFormat is not null.";
                throw new SourceFormatBuilderServiceException(msg);
            }

            SourceFormat.RootDimensionStructure = dimensionStructure;
            SourceFormat.RootDimensionStructureId = dimensionStructure.Id;
        }

        /// <inheritdoc />
        [SuppressMessage("ReSharper", "CA1062", Justification = "Checked.")]
        public async Task AddOrReplaceDocumentStructureToTreeAsync(
            DimensionStructure dimensionStructure,
            Guid parentDocumentStructureGuid)
        {
            Check.IsNotNull(dimensionStructure);
            Check.AreNotEqual(parentDocumentStructureGuid, Guid.Empty);


            if (SourceFormat.RootDimensionStructure.Guid == parentDocumentStructureGuid)
            {
                SourceFormat.RootDimensionStructure.ChildDimensionStructures.Add(dimensionStructure);
                return;
            }

            if (SourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
            {
                await IterateThroughTheTreeForAdding(
                        dimensionStructure,
                        SourceFormat.RootDimensionStructure.ChildDimensionStructures,
                        parentDocumentStructureGuid)
                   .ConfigureAwait(false);
            }
        }

        /// <inheritdoc />
        public void DeleteDimensionStructureRootAsync()
        {
            CheckIfSourceFormatIsNull();

            SourceFormat.RootDimensionStructure = null;
            SourceFormat.RootDimensionStructureId = null;
        }

        /// <inheritdoc />
        public async Task DeleteDocumentStructureFromTreeAsync()
        {
            await RemoveItemFromTreeAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public DimensionStructure DimensionStructureToBeDeletedFromTree { get; set; }

        /// <inheritdoc />
        public async Task<List<Dimension>> GetAllDimensionsFromServer()
        {
            return await _masterDataHttpClient.GetDimensionsAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public async Task<DimensionStructure> GetDimensionStructureFromTreeByIdAsync(long dimensionStructureId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<List<DimensionStructure>> GetDimensionStructuresAsync()
        {
            return await _masterDataHttpClient.GetDimensionStructuresAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<List<Dimension>> GetDimensionsWithNulloAsync()
        {
            try
            {
                List<Dimension> availableDimensions = await GetAllDimensionsFromServer().ConfigureAwait(false);
                List<Dimension> availableDimensionsWithNullo = await _domainEntityHelperService
                   .AddNulloToListAsFirstItem(availableDimensions)
                   .ConfigureAwait(false);
                return availableDimensionsWithNullo;
            }
            catch (Exception e)
            {
                string msg = "source format builder";
                throw new SourceFormatBuilderServiceException(msg, e);
            }
        }

        /// <inheritdoc />
        public async Task<List<SourceFormat>> GetSourceFormatsAsync()
        {
            return await _masterDataHttpClient.GetSourceFormatsAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public bool IsEditSourceFormatDetailsButtonDisabled { get; set; }

        /// <inheritdoc />
        public bool IsLoadSourceFormatsButtonDisabled { get; set; }

        /// <inheritdoc />
        public bool IsNewSourceFormatButtonDisabled { get; set; }

        /// <inheritdoc />
        public bool IsSourceFormatCancelButtonDisabled { get; set; }

        /// <inheritdoc />
        public bool IsSourceFormatDropDownlistDisabled { get; set; }

        /// <inheritdoc />
        public bool IsSourceFormatSaveButtonDisabled { get; set; }

        /// <inheritdoc />
        public long LoadedSourceFormatId { get; set; }

        /// <inheritdoc />
        public IMasterDataValidators MasterDataValidators { get; }


        /// <inheritdoc />
        public async Task OnUpdate(long sourceFormatId)
        {
            Check.AreNotEqual(0, sourceFormatId);
            SourceFormat querySourceFormat = new SourceFormat { Id = sourceFormatId };
            SourceFormat = await _masterDataHttpClient.GetSourceFormatWithFullDimensionStructureTreeAsync(
                    querySourceFormat)
               .ConfigureAwait(false);
        }

        /// <inheritdoc />
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
                                     "in the tree.";
                        throw new SourceFormatBuilderServiceException(msg);
                    }
                }
            }
        }

        /// <inheritdoc />
        public async Task SaveNewRootDimensionStructureAsync(DimensionStructure newRootDimensionStructure)
        {
            await MasterDataValidators.DimensionStructureValidator
               .ValidateAndThrowAsync(newRootDimensionStructure)
               .ConfigureAwait(false);
            await _masterDataHttpClient.AddDimensionStructureAsync(newRootDimensionStructure)
               .ConfigureAwait(false);
        }

        /// <summary>
        ///     Saves the new RootDimensionStructure for DocumentStructure. Saving means it setups the properties
        ///     of the service accordingly.
        /// </summary>
        /// <param name="newRootDimensionStructure">The new RootDimensionStructure</param>
        /// <returns>Task</returns>
        /// <exception cref="SourceFormatBuilderServiceException">General exception wrapping other exception.</exception>
        [SuppressMessage("ReSharper", "CA1062", Justification = "Checked.")]
        public async Task SaveNewRootDimensionStructureHandlerAsync(
            DimensionStructure newRootDimensionStructure)
        {
            try
            {
                Check.IsNotNull(newRootDimensionStructure);

                await MasterDataValidators.DimensionStructureValidator
                   .ValidateAndThrowAsync(
                        newRootDimensionStructure,
                        DimensionStructureValidatorRulesets.Add)
                   .ConfigureAwait(false);

                if (newRootDimensionStructure.Dimension != null)
                {
                    await MasterDataValidators.DimensionValidator.ValidateAndThrowAsync(
                            newRootDimensionStructure.Dimension,
                            ValidatorRulesets.UpdateDimension)
                       .ConfigureAwait(false);
                }

                // ReSharper disable once CA1062
                newRootDimensionStructure.Guid = Guid.NewGuid();

                SourceFormat.RootDimensionStructure = newRootDimensionStructure;

                if (newRootDimensionStructure.DimensionId != null)
                {
                    SourceFormat.RootDimensionStructure.DimensionId = newRootDimensionStructure.DimensionId;

                    long id = newRootDimensionStructure.DimensionId ?? default(int);
                    Dimension selectedDimension = await _masterDataHttpClient.GetDimensionByIdAsync(id)
                       .ConfigureAwait(false);

                    SourceFormat.RootDimensionStructure.Dimension = selectedDimension;
                }
            }
            catch (Exception e)
            {
                string msg = string.Empty;
                if (newRootDimensionStructure != null)
                {
                    if (string.IsNullOrEmpty(newRootDimensionStructure.Name))
                    {
                        msg = "Something went wrong during saving " +
                              $"{newRootDimensionStructure.Name}";
                    }
                }
                else
                {
                    msg = "Null input";
                }

                throw new SourceFormatBuilderServiceException(msg, e);
            }
        }

        /// <inheritdoc />
        public void SetDefaultStateForReplacementOfDimensionStructureInTree()
        {
            UpdateNodeNewDimensionStructure = null;
            UpdateNodeOldDimensionStructure = null;
        }

        /// <inheritdoc />
        public SourceFormat SourceFormat { get; set; } = new SourceFormat();

        /// <inheritdoc />
        [SuppressMessage("ReSharper", "CA1062", Justification = "Checked.")]
        public async Task UpdateDocumentStructureInTheTreeAsync(
            DimensionStructure newDimensionStructure,
            Guid dimensionStructureToBeUpdated)
        {
            Check.IsNotNull(newDimensionStructure);
            Check.AreNotEqual(dimensionStructureToBeUpdated, Guid.Empty);

            if (SourceFormat.RootDimensionStructure.Guid == dimensionStructureToBeUpdated)
            {
                SourceFormat.RootDimensionStructure = newDimensionStructure;
                return;
            }

            if (SourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
            {
                await IterateThroughTheTreeAndReplace(
                        newDimensionStructure,
                        dimensionStructureToBeUpdated,
                        SourceFormat.RootDimensionStructure.ChildDimensionStructures)
                   .ConfigureAwait(false);
            }
        }

        /// <inheritdoc />
        public DimensionStructure UpdateNodeNewDimensionStructure { get; set; }

        /// <inheritdoc />
        public DimensionStructure UpdateNodeOldDimensionStructure { get; set; }


        /// <inheritdoc />
        public async Task UpdateSourceFormatBuilder()
        {
            throw new NotImplementedException();
        }

        private async Task CheckDimensionStructureUniquenessInTree(DimensionStructure dimensionStructure)
        {
            throw new NotImplementedException();
        }

        private void CheckIfSourceFormatIsNull()
        {
            if (SourceFormat == null)
            {
                string msg = "There is no SourceFormat set up.";
                throw new SourceFormatBuilderServiceException(msg);
            }
        }

        private async Task<List<Dimension>> GetDimensions()
        {
            return await _masterDataHttpClient.GetDimensionsAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     Finds <see cref="DimensionStructure" /> node in the tree based on its <see cref="Guid" /> value
        ///     and removes from the tree.
        ///     It adds another <see cref="DimensionStructure" /> to the same node.
        /// </summary>
        /// <param name="dimensionStructure">To be added.</param>
        /// <param name="toBeReplacedDimensionStructureGuid">To be removed.</param>
        /// <param name="childDimensionStructures">The node.</param>
        /// <returns>Task.</returns>
        private async Task IterateThroughTheTreeAndReplace(
            DimensionStructure dimensionStructure,
            Guid toBeReplacedDimensionStructureGuid,
            ICollection<DimensionStructure> childDimensionStructures)
        {
            Check.IsNotNull(dimensionStructure);
            Check.AreNotEqual(toBeReplacedDimensionStructureGuid, Guid.Empty);

            if (childDimensionStructures.Any())
            {
                foreach (DimensionStructure childDimensionStructure in childDimensionStructures)
                {
                    if (childDimensionStructure.Guid == toBeReplacedDimensionStructureGuid)
                    {
                        childDimensionStructures.Remove(childDimensionStructure);
                        childDimensionStructures.Add(dimensionStructure);
                        return;
                    }

                    await IterateThroughTheTreeAndReplace(
                            dimensionStructure,
                            toBeReplacedDimensionStructureGuid,
                            childDimensionStructure.ChildDimensionStructures)
                       .ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        ///     Finds the <see cref="DocumentStructure" /> node in the tree based on its <see cref="Guid" />
        ///     value and adds the given <see cref="DocumentStructure" /> to it.
        /// </summary>
        /// <param name="dimensionStructureToBeAdded">To be added.</param>
        /// <param name="dimensionStructures">The nodes.</param>
        /// <param name="parentDimensionStructureGuid">The guid of the searched node.</param>
        /// <returns>Task.</returns>
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
                        return;
                    }

                    await IterateThroughTheTreeForAdding(
                            dimensionStructureToBeAdded,
                            dimensionStructure.ChildDimensionStructures,
                            parentDimensionStructureGuid)
                       .ConfigureAwait(false);
                }
            }
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
                    if (_foundDuringDimensionStructureReplaceInTheTree) break;

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

        private async Task RemoveItemFromTreeAsync()
        {
            Check.IsNotNull(DimensionStructureToBeDeletedFromTree);
            if (SourceFormat.RootDimensionStructure.Guid == DimensionStructureToBeDeletedFromTree.Guid)
            {
                SourceFormat.RootDimensionStructure = null;
                SourceFormat.RootDimensionStructureId = 0;
            }
            else
            {
                if (SourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
                {
                    await RemoveItemRecursivelyAsync(
                            SourceFormat.RootDimensionStructure,
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
                                dimensionStructure.ChildDimensionStructures.ElementAt(i));
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

        private async Task ReplaceRootDimensionStructureAsync(DimensionStructure newRootDimensionStructure)
        {
            Check.IsNotNull(newRootDimensionStructure);
            SourceFormat.RootDimensionStructureId = newRootDimensionStructure.Id;
            DimensionStructure newRootDimensionStructureFromServer =
                await GetDimensionStructureByIdAsync(newRootDimensionStructure.Id)
                   .ConfigureAwait(false);
            SourceFormat.RootDimensionStructure = newRootDimensionStructureFromServer;
        }


        public async Task SaveSourceFormat()
        {
            // check whether all dimension structure has id, if not then create them before save
        }
    }
}