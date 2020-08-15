// <copyright file="ISourceFormatBuilderService.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;

    public interface ISourceFormatBuilderService
    {
        DimensionStructure DimensionStructureToBeDeletedFromTree { get; set; }

        bool IsEditSourceFormatDetailsButtonDisabled { get; set; }

        bool IsLoadSourceFormatsButtonDisabled { get; set; }

        bool IsNewSourceFormatButtonDisabled { get; set; }

        bool IsSourceFormatCancelButtonDisabled { get; set; }

        bool IsSourceFormatDropDownlistDisabled { get; set; }

        bool IsSourceFormatSaveButtonDisabled { get; set; }

        long LoadedSourceFormatId { get; set; }

        IMasterDataValidators MasterDataValidators { get; }

        /// <summary>
        ///     The SourceFormat data structure which is going to be built.
        /// </summary>
        SourceFormat SourceFormat { get; set; }

        DimensionStructure UpdateNodeNewDimensionStructure { get; set; }

        DimensionStructure UpdateNodeOldDimensionStructure { get; set; }

        Task AddDimensionStructureAsync(
            long parentDimensionStructureId,
            DimensionStructure dimensionStructure);

        /// <summary>
        ///     Adds <see cref="DimensionStructure">DimensionStructure</see> to <see cref="SourceFormat">SourceFormat</see>
        ///     ass root DimensionStructure.
        /// </summary>
        /// <param name="dimensionStructureId">The id of the selected DimensionStructure.</param>
        /// <returns>Task.</returns>
        Task AddDimensionStructureRootAsync(DimensionStructure dimensionStructure);

        /// <summary>
        ///     Adds <see cref="DimensionStructure">DimensionStructure</see> to <see cref="SourceFormat">SourceFormat</see>
        ///     ass root DimensionStructure by Id.
        /// </summary>
        /// <param name="dimensionStructureId">The id of the selected DimensionStructure.</param>
        /// <returns>Task.</returns>
        Task AddDimensionStructureRootAsync(long dimensionStructureId);

        /// <summary>
        ///     Adds <see cref="DimensionStructure">DocumentStructure</see> to the DimensionStructure node.
        ///     The parent is node Guid also has to be provided.
        /// </summary>
        /// <param name="dimensionStructure">New DimensionStructure.</param>
        /// <param name="parentDocumentStructureGuid">Guid value of the parent node.</param>
        /// <returns>Task</returns>
        Task AddOrReplaceDocumentStructureToTreeAsync(
            DimensionStructure dimensionStructure,
            Guid parentDocumentStructureGuid);

        Task DeleteDimensionStructureRootAsync(DimensionStructure dimensionStructure);

        Task DeleteDocumentStructureFromTreeAsync();

        Task<List<Dimension>> GetAllDimensionsFromServer();

        Task<DimensionStructure> GetDimensionStructureByIdAsync(long dimensionStructureId);

        Task<DimensionStructure> GetDimensionStructureFromTreeByIdAsync(long dimensionStructureId);

        Task<List<DimensionStructure>> GetDimensionStructuresAsync();

        Task<List<Dimension>> GetDimensionsWithNulloAsync();

        Task<List<SourceFormat>> GetSourceFormatsAsync();

        Task OnUpdate(long sourceFormatId);

        Task ReplaceDimensionStructureInTheTree();

        Task SaveNewRootDimensionStructureAsync(DimensionStructure newRootDimensionStructure);

        Task SaveNewRootDimensionStructureHandlerAsync(DimensionStructure newRootDimensionStructure);

        Task SetDefaultStateForReplacementOfDimensionStructureInTree();

        /// <summary>
        ///     Updates <see cref="DimensionStructure" /> node in the DimensionStructure tree.
        ///     The guid marks which node has to be replaced by the provided DimensionStructure.
        /// </summary>
        /// <param name="newDimensionStructure">The new DimensionStructure.</param>
        /// <param name="dimensionStructureToBeUpdated">The one which is going to be replaced.</param>
        /// <returns>Task</returns>
        Task UpdateDocumentStructureInTheTreeAsync(
            DimensionStructure newDimensionStructure,
            Guid dimensionStructureToBeUpdated);

        Task UpdateSourceFormatBuilder();
    }
}