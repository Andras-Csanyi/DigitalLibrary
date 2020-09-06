// <copyright file="Delete_SourceFormat_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.ControlPanel.DataSample.MasterData;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xbehave;

    using Xunit;

    public partial class SourceFormatFeature
    {
        [Scenario]
        public void Delete()
        {
            SourceFormat first = null;
            SourceFormat second = null;
            SourceFormat secondResult = null;
            List<SourceFormat> result = null;

            "Given there is a source format"
               .x(() => first = new SourceFormat
                {
                    Name = "first",
                    Desc = "first",
                    IsActive = 1,
                });

            "And it is saved int he database"
               .x(async () => await _masterDataBusinessLogic.AddSourceFormatAsync(first)
                   .ConfigureAwait(false));


            "And there is another source format"
               .x(() => second = new SourceFormat
                {
                    Name = "second",
                    Desc = "second",
                    IsActive = 1,
                });
            "And it is also saved in the database"
               .x(async () => secondResult = await _masterDataBusinessLogic.AddSourceFormatAsync(second)
                   .ConfigureAwait(false));

            "When the second one is deleted"
               .x(async () =>
                    await _masterDataBusinessLogic.DeleteSourceFormatAsync(secondResult).ConfigureAwait(false));

            "And list of source formats are requested"
               .x(async () => result = await _masterDataBusinessLogic.GetSourceFormatsAsync()
                   .ConfigureAwait(false));

            int expectedAmount = MasterDataDataSample.GetSourceFormatAmount() + 1;

            "Then the length of the list shows that one of the source formats is missing"
               .x(() => result.Count.Should().Be(expectedAmount));

            "And searching in the list for the not deleted source format list shows 1 result"
               .x(() => result.Where(p => p.Name == first.Name).ToList().Count.Should().Be(1));

            "And filtering for the deleted source format in the list shows 0 result"
               .x(() => result.Where(p => p.Name == second.Name).ToList().Count.Should().Be(0));
        }

        [Scenario]
        public void Delete_ThrowException_WhenEntityDoesntExist()
        {
            Func<Task> action = null;

            "When I want to delete a source format which is not in the database"
               .x(() => action = async () =>
                {
                    SourceFormat sourceFormat = new SourceFormat { Id = 100 };
                    await _masterDataBusinessLogic.DeleteSourceFormatAsync(sourceFormat)
                       .ConfigureAwait(false);
                });

            "Then it throws and exception"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException>()
                   .WithInnerException<GuardException>());
        }
    }
}