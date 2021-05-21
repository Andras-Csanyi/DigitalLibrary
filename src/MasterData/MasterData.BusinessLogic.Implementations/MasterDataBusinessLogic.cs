namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.Utils.Guards;

    public class MasterDataBusinessLogic : IMasterDataBusinessLogic
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MasterDataBusinessLogic"/> class.
        /// </summary>
        /// <param name="masterDataDimensionBusinessLogic">
        ///     <see cref="Dimension"/> entity related available operations in Master Data context.
        /// </param>
        /// <param name="masterDataDimensionStructureBusinessLogic">
        ///     <see cref="DimensionStructure"/> entity related available operations in Master Data context.
        /// </param>
        /// <param name="masterDataDimensionValueBusinessLogic">
        ///     <see cref="MasterDataDimensionValueBusinessLogic"/> entity related available operations
        ///     in Master Data context.
        /// </param>
        /// <param name="masterDataSourceFormatBusinessLogic">
        ///     <see cref="SourceFormat"/> entity related available operations in Master Data context.
        /// </param>
        /// <param name="masterDataDimensionStructureNodeBusinessLogic">
        ///     <see cref="DimensionStructureNode"/> entity related available operations in Master Data context.
        /// </param>
        /// <param name="masterDataSourceFormatDimensionStructureNodeBusinessLogic">
        ///     <see cref="SourceFormatDimensionStructureNode"/> entity related available opertions in
        ///     Master Data context.
        /// </param>
        public MasterDataBusinessLogic(
            IMasterDataDimensionBusinessLogic masterDataDimensionBusinessLogic,
            IMasterDataDimensionStructureBusinessLogic
                masterDataDimensionStructureBusinessLogic,
            IMasterDataDimensionValueBusinessLogic masterDataDimensionValueBusinessLogic,
            IMasterDataSourceFormatBusinessLogic masterDataSourceFormatBusinessLogic,
            IMasterDataDimensionStructureNodeBusinessLogic masterDataDimensionStructureNodeBusinessLogic)
        {
            Check.IsNotNull(masterDataDimensionBusinessLogic);
            MasterDataDimensionBusinessLogic = masterDataDimensionBusinessLogic;

            Check.IsNotNull(masterDataDimensionStructureBusinessLogic);
            MasterDataDimensionStructureBusinessLogic = masterDataDimensionStructureBusinessLogic;

            Check.IsNotNull(masterDataDimensionValueBusinessLogic);
            MasterDataDimensionValueBusinessLogic = masterDataDimensionValueBusinessLogic;

            Check.IsNotNull(masterDataSourceFormatBusinessLogic);
            MasterDataSourceFormatBusinessLogic = masterDataSourceFormatBusinessLogic;

            Check.IsNotNull(masterDataDimensionStructureNodeBusinessLogic);
            MasterDataDimensionStructureNodeBusinessLogic = masterDataDimensionStructureNodeBusinessLogic;
        }

        /// <inheritdoc/>
        public IMasterDataDimensionBusinessLogic MasterDataDimensionBusinessLogic { get; set; }

        /// <inheritdoc/>
        public IMasterDataDimensionStructureBusinessLogic MasterDataDimensionStructureBusinessLogic { get; set; }

        /// <inheritdoc/>
        public IMasterDataDimensionValueBusinessLogic MasterDataDimensionValueBusinessLogic { get; set; }

        /// <inheritdoc/>
        public IMasterDataSourceFormatBusinessLogic MasterDataSourceFormatBusinessLogic { get; set; }

        /// <inheritdoc/>
        public IMasterDataDimensionStructureNodeBusinessLogic MasterDataDimensionStructureNodeBusinessLogic
        {
            get;
            set;
        }
    }
}
