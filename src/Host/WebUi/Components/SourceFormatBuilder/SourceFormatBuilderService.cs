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
        public DimensionStructure DimensionStructureToBeDeletedFromTree { get; set; }

        public bool IsEditSourceFormatDetailsButtonDisabled { get; set; }

        public bool IsLoadSourceFormatsButtonDisabled { get; set; }

        public bool IsNewSourceFormatButtonDisabled { get; set; }

        public bool IsSourceFormatCancelButtonDisabled { get; set; }

        public bool IsSourceFormatDropDownlistDisabled { get; set; }

        public bool IsSourceFormatSaveButtonDisabled { get; set; }

        public long LoadedSourceFormatId { get; set; }

        public IMasterDataValidators MasterDataValidators { get; }

        public SourceFormat SourceFormat { get; set; }

        public DimensionStructure UpdateNodeNewDimensionStructure { get; set; }

        public DimensionStructure UpdateNodeOldDimensionStructure { get; set; }

        public async Task AddDimensionStructureAsync(long parentDimensionStructureId,
                                                     DimensionStructure dimensionStructure)
        {
            throw new NotImplementedException();
        }

        public async Task AddDimensionStructureRootAsync(DimensionStructure dimensionStructure)
        {
            throw new NotImplementedException();
        }

        public async Task AddDimensionStructureRootAsync(long dimensionStructureId)
        {
            throw new NotImplementedException();
        }

        public async Task AddOrReplaceDocumentStructureToTreeAsync(DimensionStructure dimensionStructure,
                                                                   Guid parentDocumentStructureGuid)
        {
            throw new NotImplementedException();
        }

        public void DeleteDimensionStructureRootAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDocumentStructureFromTreeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Dimension>> GetAllDimensionsFromServer()
        {
            throw new NotImplementedException();
        }

        public async Task<DimensionStructure> GetDimensionStructureByIdAsync(long dimensionStructureId)
        {
            throw new NotImplementedException();
        }

        public async Task<DimensionStructure> GetDimensionStructureFromTreeByIdAsync(long dimensionStructureId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DimensionStructure>> GetDimensionStructuresAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Dimension>> GetDimensionsWithNulloAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<SourceFormat>> GetSourceFormatsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task OnUpdate(long sourceFormatId)
        {
            throw new NotImplementedException();
        }

        public async Task ReplaceDimensionStructureInTheTree()
        {
            throw new NotImplementedException();
        }

        public async Task SaveNewRootDimensionStructureAsync(DimensionStructure newRootDimensionStructure)
        {
            throw new NotImplementedException();
        }

        public async Task SaveNewRootDimensionStructureHandlerAsync(DimensionStructure newRootDimensionStructure)
        {
            throw new NotImplementedException();
        }

        public async Task SaveSourceFormatAsync()
        {
            throw new NotImplementedException();
        }

        public void SetDefaultStateForReplacementOfDimensionStructureInTree()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateDocumentStructureInTheTreeAsync(DimensionStructure newDimensionStructure,
                                                                Guid dimensionStructureToBeUpdated)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateSourceFormatBuilder()
        {
            throw new NotImplementedException();
        }
    }
}