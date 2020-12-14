namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;

    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;

    public class MasterDataBusinessLogic : IMasterDataBusinessLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterDataBusinessLogic"/> class.
        /// </summary>
        /// <param name="masterDataDimensionBusinessLogic">
        /// <see cref="Dimension"/> entity related available operations in Master Data context.
        /// </param>
        /// <param name="masterDataDimensionStructureBusinessLogic">
        /// <see cref="DimensionStructure"/> entity related available operations in Master Data context.
        /// </param>
        /// <param name="masterDataDimensionValueBusinessLogic">
        /// <see cref="MasterDataDimensionValueBusinessLogic"/> entity related available operations
        /// in Master Data context.
        /// </param>
        /// <param name="masterDataSourceFormatBusinessLogic">
        /// <see cref="SourceFormat"/> entity related available operations in Master Data context.
        /// </param>
        /// <param name="masterDataDimensionStructureNodeBusinessLogic">
        /// <see cref="DimensionStructureNode"/> entity related available operations in Master Data context.
        /// </param>
        public MasterDataBusinessLogic(
            IMasterDataDimensionBusinessLogic masterDataDimensionBusinessLogic,
            IMasterDataDimensionStructureBusinessLogic masterDataDimensionStructureBusinessLogic,
            IMasterDataDimensionValueBusinessLogic masterDataDimensionValueBusinessLogic,
            IMasterDataSourceFormatBusinessLogic masterDataSourceFormatBusinessLogic,
            IMasterDataDimensionStructureNodeBusinessLogic masterDataDimensionStructureNodeBusinessLogic,
            IMasterDataSourceFormatDimensionStructureNodeBusinessLogic
                masterDataSourceFormatDimensionStructureNodeBusinessLogic)
        {
            MasterDataDimensionBusinessLogic = masterDataDimensionBusinessLogic ??
                                               throw new ArgumentNullException(
                                                   nameof(masterDataDimensionBusinessLogic));
            MasterDataDimensionStructureBusinessLogic = masterDataDimensionStructureBusinessLogic ??
                                                        throw new ArgumentNullException(
                                                            nameof(masterDataDimensionStructureBusinessLogic));
            MasterDataDimensionValueBusinessLogic = masterDataDimensionValueBusinessLogic ??
                                                    throw new ArgumentNullException(
                                                        nameof(masterDataDimensionValueBusinessLogic));
            MasterDataSourceFormatBusinessLogic = masterDataSourceFormatBusinessLogic ??
                                                  throw new ArgumentNullException(
                                                      nameof(masterDataSourceFormatBusinessLogic));
            MasterDataDimensionStructureNodeBusinessLogic = masterDataDimensionStructureNodeBusinessLogic ??
                                                            throw new ArgumentNullException(
                                                                nameof(masterDataDimensionStructureNodeBusinessLogic));
            MasterDataSourceFormatDimensionStructureNodeBusinessLogic =
                masterDataSourceFormatDimensionStructureNodeBusinessLogic ??
                throw new ArgumentNullException(nameof(masterDataSourceFormatDimensionStructureNodeBusinessLogic));
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

        /// <inheritdoc/>
        public IMasterDataSourceFormatDimensionStructureNodeBusinessLogic
            MasterDataSourceFormatDimensionStructureNodeBusinessLogic { get; set; }
    }
}