// <copyright file="MasterData_SourceFormat_Validation_TestData.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators.TestData
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Validation test data for validating CRUD operations concerning <see cref="SourceFormat"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1401", Justification = "Reviewed.")]
    public static class MasterData_SourceFormat_Validation_TestData
    {
        /// <summary>
        /// Test data for adding a new <see cref="SourceFormat"/> input validation.
        /// </summary>
        public static IEnumerable<object[]> AddNew = new List<object[]>
        {
            new object[] { 1, "asd", "asd", 1 },

            new object[] { 0, null, "asd", 1 },
            new object[] { 0, string.Empty, "asd", 1 },
            new object[] { 0, "as", "asd", 1 },

            new object[] { 0, "asd", null, 1 },
            new object[] { 0, "asd", string.Empty, 1 },

            new object[] { 0, "asd", "asd", 2 },
        };
    }
}