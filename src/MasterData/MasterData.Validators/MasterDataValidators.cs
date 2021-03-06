// <copyright file="MasterDataValidators.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.Utils.Guards;

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public class MasterDataValidators : IMasterDataValidators
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MasterDataValidators"/> class.
        /// </summary>
        /// <param name="dimensionValidator"> DimensionValidator. </param>
        /// <param name="dimensionValueValidator"> DimensionValueValidator. </param>
        /// <param name="sourceFormatValidator"> SourceFormat validator. </param>
        /// <param name="dimensionStructureValidator"> DimensionStructure validator. </param>
        /// <param name="dimensionStructureDimensionStructureValidator">
        ///     DimensionStructureDimensionStructure validator.
        /// </param>
        /// <param name="dimensionStructureQueryObjectValidator"> DimensionStructureQueryObject validator. </param>
        /// <param name="dimensionStructureNodeValidator"> DimensionStructureNode validator. </param>
        /// <param name="sourceFormatDimensionStructureNodeValidator"> SourceFormatDimensionStructureNodeValidator validator. </param>
        public MasterDataValidators(
            DimensionValidator dimensionValidator,
            MasterDataDimensionValueValidator dimensionValueValidator,
            SourceFormatValidator sourceFormatValidator,
            DimensionStructureValidator dimensionStructureValidator,
            DimensionStructureDimensionStructureValidator dimensionStructureDimensionStructureValidator,
            DimensionStructureQueryObjectValidator dimensionStructureQueryObjectValidator,
            DimensionStructureNodeValidator dimensionStructureNodeValidator,
            SourceFormatDimensionStructureNodeValidator sourceFormatDimensionStructureNodeValidator)
        {
            Check.IsNotNull(dimensionValidator);
            Check.IsNotNull(dimensionValueValidator);
            Check.IsNotNull(sourceFormatValidator);
            Check.IsNotNull(dimensionStructureValidator);
            Check.IsNotNull(dimensionStructureDimensionStructureValidator);
            Check.IsNotNull(dimensionStructureQueryObjectValidator);
            Check.IsNotNull(dimensionStructureNodeValidator);
            Check.IsNotNull(sourceFormatDimensionStructureNodeValidator);

            DimensionValidator = dimensionValidator;
            DimensionValueValidator = dimensionValueValidator;
            SourceFormatValidator = sourceFormatValidator;
            DimensionStructureValidator = dimensionStructureValidator;
            DimensionStructureDimensionStructureValidator = dimensionStructureDimensionStructureValidator;
            DimensionStructureQueryObjectValidator = dimensionStructureQueryObjectValidator;
            DimensionStructureNodeValidator = dimensionStructureNodeValidator;
            SourceFormatDimensionStructureNodeValidator = sourceFormatDimensionStructureNodeValidator;
        }

        public DimensionStructureDimensionStructureValidator DimensionStructureDimensionStructureValidator { get; }

        public DimensionStructureQueryObjectValidator DimensionStructureQueryObjectValidator { get; }

        /// <inheritdoc/>
        public DimensionStructureValidator DimensionStructureValidator { get; }

        /// <inheritdoc/>
        public DimensionValidator DimensionValidator { get; }

        /// <inheritdoc/>
        public MasterDataDimensionValueValidator DimensionValueValidator { get; }

        /// <inheritdoc/>
        public SourceFormatValidator SourceFormatValidator { get; }

        /// <inheritdoc/>
        public DimensionStructureNodeValidator DimensionStructureNodeValidator { get; }

        /// <inheritdoc/>
        public SourceFormatDimensionStructureNodeValidator SourceFormatDimensionStructureNodeValidator { get; }
    }
}
