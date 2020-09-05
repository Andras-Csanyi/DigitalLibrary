// <copyright file="MasterData_DimensionValue_TestData.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators.TestData
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    ///     Test data for operations concerning <see cref="DimensionValue" /> entity.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1806", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1401", Justification = "Reviewed.")]
    public static class MasterData_DimensionValue_TestData
    {
        /// <summary>
        ///     Test data for validating input for <see cref="DimensionValue" /> entity.
        /// </summary>
        public static IEnumerable<object[]> DimensionValue_Modify_TestData = new List<object[]>
        {
            new object[]
            {
                0,
                new DimensionValue(),
                new DimensionValue(),
            },
            new object[]
            {
                1,
                null,
                new DimensionValue(),
            },
            new object[]
            {
                1,
                new DimensionValue(),
                null,
            },
        };
    }
}