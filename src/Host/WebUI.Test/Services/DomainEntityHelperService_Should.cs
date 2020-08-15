// <copyright file="DomainEntityHelperService_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUI.Test.Services
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Ui.WebUi.Services;
    using FluentAssertions;
    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class DomainEntityHelperService_Should
    {
        [Fact]

        // ReSharper disable once IdentifierTypo
        public async Task AddNullo_ToTheList()
        {
            IDomainEntityHelperService service = new DomainEntityHelperService();

            List<Dimension> list = new List<Dimension>
            {
                new Dimension(),
                new Dimension(),
                new Dimension(),
            };

            List<Dimension> result = await service.AddNulloToListAsFirstItem(list)
               .ConfigureAwait(false);

            result.Count.Should().Be(4);
        }
    }
}