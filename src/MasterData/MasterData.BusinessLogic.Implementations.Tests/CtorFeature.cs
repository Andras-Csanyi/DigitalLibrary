// <copyright file="Ctor_Validation_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xbehave;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class CtorFeature : MasterDataBusinessLogicFeature
    {
        public CtorFeature(ITestOutputHelper testOutputHelper)
            : base(nameof(CtorFeature), testOutputHelper)
        {
        }

        [Scenario]
        public void ThrowException_WhenCtorInputIsNull()
        {
            Func<Task> action = null;
            "When it is instantiated with null parameters"
               .x(() => action = async () => { new MasterDataBusinessLogic(null, null); });

            "Then it throws exception"
               .x(() => action.Should().ThrowExactly<GuardException>());
        }
    }
}