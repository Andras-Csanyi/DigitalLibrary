// <copyright file="IMasterDataValidators.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators
{
    /// <summary>
    ///     MasterDataValidators facade.
    /// </summary>
    public interface IMasterDataValidators
    {
        public DimensionStructureDimensionStructureValidator DimensionStructureDimensionStructureValidator { get; }

        public DimensionStructureQueryObjectValidator DimensionStructureQueryObjectValidator { get; }

        /// <summary>
        ///     Gets <see cref="DimensionStructureValidator" />.
        /// </summary>
        public DimensionStructureValidator DimensionStructureValidator { get; }

        public DimensionValidator DimensionValidator { get; }

        public MasterDataDimensionValueValidator DimensionValueValidator { get; }

        /// <summary>
        ///     Gets <see cref="SourceFormatValidator" />.
        /// </summary>
        public SourceFormatValidator SourceFormatValidator { get; }
    }
}