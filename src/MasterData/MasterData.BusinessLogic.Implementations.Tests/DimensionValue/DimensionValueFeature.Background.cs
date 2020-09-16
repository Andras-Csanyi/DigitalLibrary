// <copyright file="DimensionValueFeature.Background.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionValue
{
    using System.Diagnostics.CodeAnalysis;

    using Xunit.Abstractions;

    /// <summary>
    /// Tests covering <see cref="DimensionValue"/> related operations.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public partial class DimensionValueFeature : MasterDataBusinessLogicFeature
    {
        public DimensionValueFeature(ITestOutputHelper testOutputHelper)
            : base(nameof(DimensionValueFeature), testOutputHelper)
        {
        }
    }
}