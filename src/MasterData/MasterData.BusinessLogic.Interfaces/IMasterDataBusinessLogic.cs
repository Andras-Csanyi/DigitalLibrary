// <copyright file="IMasterDataBusinessLogic.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    ///     MasterDataBusinessLogic interface.
    ///     Describes database operations.
    ///     This interface is split into pieces where a piece concerns a domain model in MasterData domain.
    /// </summary>
    public interface IMasterDataBusinessLogic
    {
        /// <summary>
        ///     Gets or sets <see cref="Dimension"/> entity related operations in Master Data context.
        /// </summary>
        public IMasterDataDimensionBusinessLogic MasterDataDimensionBusinessLogic { get; set; }

        /// <summary>
        ///     Gets or sets <see cref="DimensionStructure"/> entity related operations in Master Data context.
        /// </summary>
        public IMasterDataDimensionStructureBusinessLogic MasterDataDimensionStructureBusinessLogic { get; set; }

        /// <summary>
        ///     Gets or sets <see cref="DimensionValue"/> entity related operations in Master Data context.
        /// </summary>
        public IMasterDataDimensionValueBusinessLogic MasterDataDimensionValueBusinessLogic { get; set; }

        /// <summary>
        ///     Gets or sets <see cref="SourceFormat"/> entity related operations in Master Data context.
        /// </summary>
        public IMasterDataSourceFormatBusinessLogic MasterDataSourceFormatBusinessLogic { get; set; }

        /// <summary>
        ///     Gets or sets <see cref="DimensionStructureNode"/> entity related operations in Master Data context.
        /// </summary>
        public IMasterDataDimensionStructureNodeBusinessLogic MasterDataDimensionStructureNodeBusinessLogic
        {
            get;
            set;
        }
    }
}