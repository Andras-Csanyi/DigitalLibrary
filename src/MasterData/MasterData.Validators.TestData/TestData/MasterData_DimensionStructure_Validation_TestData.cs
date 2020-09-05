// <copyright file="MasterData_DimensionStructure_Validation_TestData.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators.TestData
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    ///     Test data for validation concerning operations related to <see cref="DimensionStructure" />.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1401", Justification = "Reviewed.")]
    public static class MasterData_DimensionStructure_Validation_TestData
    {
        /// <summary>
        ///     Test data for adding new <see cref="DimensionStructure" /> operation.
        /// </summary>
        public static IEnumerable<object[]> AddDimensionStructure_Validation_TestData = new List<object[]>
        {
            new object[] { 0, string.Empty, "desc", 1 },
            new object[] { 0, null, "desc", 1 },
            new object[] { 0, "as", "desc", 1 },

            new object[] { 0, "name", null, 1 },
            new object[] { 0, "name", string.Empty, 1 },
            new object[] { 0, "name", "de", 1 },

            new object[] { 0, "name", "desc", 2 },
        };

        /// <summary>
        ///     Test data for modifying <see cref="DimensionStructure" /> operation.
        /// </summary>
        public static IEnumerable<object[]> ModifyDimensionStructure_Validation_TestData = new List<object[]>
        {
            new object[] { 0, "name", "desc", 1 },

            new object[] { 1, string.Empty, "desc", 1 },
            new object[] { 1, " ", "desc", 1 },
            new object[] { 1, "as", "desc", 1 },
            new object[] { 1, null, "desc", 1 },

            new object[] { 1, "name", string.Empty, 1 },
            new object[] { 1, "name", " ", 1 },
            new object[] { 1, "name", "as", 1 },
            new object[] { 1, "name", null, 1 },

            new object[] { 1, "name", "desc", 2 },
        };

        public static IEnumerable<object[]> ModifyTopDimensionStructure_Validation_TestData = new List<object[]>
        {
            new object[] { 0, "name", "desc", 1 },

            new object[] { 1, null, "desc", 1 },
            new object[] { 1, string.Empty, "desc", 1 },
            new object[] { 1, "as", "desc", 1 },

            new object[] { 1, "name", null, 1 },
            new object[] { 1, "name", string.Empty, 1 },
            new object[] { 1, "name", "de", 1 },

            new object[] { 1, "name", "desc", 2 },
        };
    }
}