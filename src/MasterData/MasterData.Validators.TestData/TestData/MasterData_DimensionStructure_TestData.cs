// <copyright file="MasterData_DimensionStructure_TestData.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators.TestData
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    ///     Input validation data for operations concerning <see cref="DimensionStructure" />.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA2211", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1401", Justification = "Reviewed.")]
    public static class MasterData_DimensionStructure_TestData
    {
        public static IEnumerable<object[]> ModifyTopDimensionStructure_TestData = new List<object[]>
        {
            new object[] { "modif", "asdasd", 1 },
            new object[] { "asdasd", "modif", 1 },
            new object[] { "asdasd", "asdasd", 0 },
        };
    }
}