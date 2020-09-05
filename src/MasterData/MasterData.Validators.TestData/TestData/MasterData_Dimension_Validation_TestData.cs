// <copyright file="MasterData_Dimension_Validation_TestData.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators.TestData
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Validation test data for operations concerning <see cref="Dimension"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA2211", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1401", Justification = "Reviewed.")]
    public static class MasterData_Dimension_Validation_TestData
    {
        /// <summary>
        /// Input validation test data for operation when adding new <see cref="Dimension"/>.
        /// </summary>
        public static IEnumerable<object[]> AddDimensionAsync_Validation = new List<object[]>
        {
            new object[] { 1, "name", "desc", 1 },

            new object[] { 0, null, "desc", 1 },
            new object[] { 0, string.Empty, "desc", 1 },
            new object[] { 0, "as", "desc", 1 },

            new object[] { 0, "name", null, 1 },
            new object[] { 0, "name", string.Empty, 1 },
            new object[] { 0, "name", "as", 1 },

            new object[] { 0, "name", "desc", 2 },
        };

        /// <summary>
        /// Input validation test data for operation when updating <see cref="Dimension"/>.
        /// </summary>
        public static IEnumerable<object[]> UpdateDimensionAsync_Validation = new List<object[]>
        {
            new object[] { 0, "name", "desc", 1 },

            new object[] { 1, null, "desc", 1 },
            new object[] { 1, string.Empty, "desc", 1 },
            new object[] { 1, "as", "desc", 1 },

            new object[] { 1, "name", null, 1 },
            new object[] { 1, "name", string.Empty, 1 },
            new object[] { 1, "name", "as", 1 },

            new object[] { 1, "name", "desc", 2 },
        };
    }
}