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
        /// The SourceFormat data structure which is going to be built.
        /// </summary>
        SourceFormat SourceFormat { get; set; }

        DimensionStructure UpdateNodeNewDimensionStructure { get; set; }

        DimensionStructure UpdateNodeOldDimensionStructure { get; set; }

        Task AddDimensionStructureAsync(
            long parentDimensionStructureId,
            DimensionStructure dimensionStructure);

        /// <summary>
        /// Adds <see cref="DimensionStructure">DimensionStructure</see> to <see cref="SourceFormat">SourceFormat</see>
        /// ass root DimensionStructure.
        /// </summary>
        /// <param name="dimensionStructureId">The id of the selected DimensionStructure.</param>
        /// <returns>Task.</returns>
        Task AddDimensionStructureRootAsync(DimensionStructure dimensionStructure);

        /// <summary>
        /// Adds <see cref="DimensionStructure">DimensionStructure</see> to <see cref="SourceFormat">SourceFormat</see>
        /// ass root DimensionStructure by Id.
        /// </summary>
        /// <param name="dimensionStructureId">The id of the selected DimensionStructure.</param>
        /// <returns>Task.</returns>
        Task AddDimensionStructureRootAsync(long dimensionStructureId);

        Task AddOrUpdateDocumentStructureToTreeAsync(
            DimensionStructure dimensionStructure,
            Guid parentDimensionStructureGuid);

        Task DeleteDimensionStructureRootAsync(DimensionStructure dimensionStructure);

        Task DeleteDocumentStructureFromTreeAsync();

        Task<bool> FindDimensionStructureInTreeAsync(
            DimensionStructure dimensionStructure,
            ICollection<DimensionStructure> dimensionStructures);

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

        Task UpdateSourceFormatBuilder();
    }
}