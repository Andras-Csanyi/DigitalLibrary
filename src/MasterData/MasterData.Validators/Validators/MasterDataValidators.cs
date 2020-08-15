// <copyright file="MasterDataValidators.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators
{
    using DigitalLibrary.Utils.Guards;

    public class MasterDataValidators : IMasterDataValidators
    {
        public MasterDataValidators(
            DimensionValidator dimensionValidator,
            MasterDataDimensionValueValidator dimensionValueValidator,
            SourceFormatValidator sourceFormatValidator,
            DimensionStructureValidator dimensionStructureValidator,
            DimensionStructureDimensionStructureValidator dimensionStructureDimensionStructureValidator,
            DimensionStructureQueryObjectValidator dimensionStructureQueryObjectValidator)
        {
            Check.IsNotNull(dimensionValidator);
            Check.IsNotNull(dimensionValueValidator);
            Check.IsNotNull(sourceFormatValidator);
            Check.IsNotNull(dimensionStructureValidator);
            Check.IsNotNull(dimensionStructureDimensionStructureValidator);
            Check.IsNotNull(dimensionStructureQueryObjectValidator);

            DimensionValidator = dimensionValidator;
            DimensionValueValidator = dimensionValueValidator;
            SourceFormatValidator = sourceFormatValidator;
            DimensionStructureValidator = dimensionStructureValidator;
            DimensionStructureDimensionStructureValidator = dimensionStructureDimensionStructureValidator;
            DimensionStructureQueryObjectValidator = dimensionStructureQueryObjectValidator;
        }

        public DimensionStructureDimensionStructureValidator DimensionStructureDimensionStructureValidator { get; }

        public DimensionStructureQueryObjectValidator DimensionStructureQueryObjectValidator { get; }

        public DimensionStructureValidator DimensionStructureValidator { get; }

        public DimensionValidator DimensionValidator { get; }

        public MasterDataDimensionValueValidator DimensionValueValidator { get; }

        public SourceFormatValidator SourceFormatValidator { get; }
    }
}