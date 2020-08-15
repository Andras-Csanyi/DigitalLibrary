// <copyright file="ReplaceDimensionStructureInTheTreeAsync_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System.Diagnostics.CodeAnalysis;

    using Xunit;
    using Xunit.Abstractions;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class ReplaceDimensionStructureInTheTreeAsync_Should : TestBase
    {
        public ReplaceDimensionStructureInTheTreeAsync_Should(ITestOutputHelper outputHelper)
            : base(outputHelper)
        {
        }

        [Fact]
        public void ReplaceDimensionStructure_AtFirstLevel()
        {
        }

        [Fact]
        public void ReplaceDimensionStructure_AtSecondLevel()
        {
        }

        [Fact]
        public void ReplaceDimensionStructure_AtThirdLevel()
        {
        }

        [Fact]
        public void ReplaceRootDimension()
        {
        }

        [Fact]
        public void ReplaceRootDimensionStructure_AndIncludeAllChildDimensionsOfTheAddedOne()
        {
        }

        [Fact]
        public void ThrowException_WhenDimensionStructureIs_NotInTheTree()
        {
        }
    }
}