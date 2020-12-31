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
        DimensionStructureDimensionStructureValidator DimensionStructureDimensionStructureValidator { get; }

        DimensionStructureQueryObjectValidator DimensionStructureQueryObjectValidator { get; }

        /// <summary>
        ///     Gets <see cref="DimensionStructureValidator" />.
        /// </summary>
        DimensionStructureValidator DimensionStructureValidator { get; }

        DimensionValidator DimensionValidator { get; }

        MasterDataDimensionValueValidator DimensionValueValidator { get; }

        /// <summary>
        ///     Gets <see cref="SourceFormatValidator" />.
        /// </summary>
        SourceFormatValidator SourceFormatValidator { get; }


        /// <summary>
        ///     Gets <see cref="DimensionStructureNodeValidator" />.
        /// </summary>
        DimensionStructureNodeValidator DimensionStructureNodeValidator { get; }

        /// <summary>
        ///     Gets <see cref="SourceFormatDimensionStructureNodeValidator" />.
        /// </summary>
        SourceFormatDimensionStructureNodeValidator SourceFormatDimensionStructureNodeValidator { get; }
    }
}