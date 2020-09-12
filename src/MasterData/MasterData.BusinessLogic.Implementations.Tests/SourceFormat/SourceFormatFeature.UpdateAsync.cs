// <copyright file="SourceFormatFeature.UpdateAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators.TestData;

    using FluentAssertions;

    using Xbehave;

    using Xunit;

    /// <summary>
    /// Test cases covering Update method.
    /// </summary>
    public partial class SourceFormatFeature
    {
        [Scenario]
        [MemberData(
            nameof(MasterData_DimensionStructure_TestData.ModifyTopDimensionStructure_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public void UpdateAsync_UpdatesNameDescIsActive(
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            SourceFormat orig = null;
            "Given there is a source format"
               .x(() => orig = new SourceFormat
                {
                    Name = "asdasd",
                    Desc = "asdasd",
                    IsActive = 1,
                });

            SourceFormat origRes = null;
            "And it is stored in the database"
               .x(async () => origRes = await _masterDataBusinessLogic.AddSourceFormatAsync(
                    orig).ConfigureAwait(false));

            SourceFormat mod = null;
            "And there is a the modification for source format"
               .x(() => mod = new SourceFormat
                {
                    Id = origRes.Id,
                    Name = name,
                    Desc = desc,
                    IsActive = isActive,
                });

            SourceFormat res = null;
            "When source format is updated"
               .x(async () => res = await _masterDataBusinessLogic.UpdateSourceFormatAsync(mod)
                   .ConfigureAwait(false));

            "Then the result is not null".x(() => res.Should().NotBeNull());
            "And the result id is the same as the original"
               .x(() => res.Id.Should().Be(origRes.Id));
            "And the result name is equalt to the expected name"
               .x(() => res.Name.Should().Be(name));
            "And the description is the same as the expected description"
               .x(() => res.Desc.Should().Be(desc));
            "And the result is active value is the same as the expected is active value"
               .x(() => res.IsActive.Should().Be(isActive));
        }

        [Scenario]
        public void UpdateAsync_ThrowsWhenThereIsNoSuchSourceFormat()
        {
            SourceFormat sourceFormat = null;
            "Given there is a source format"
               .x(() => sourceFormat = new SourceFormat
                {
                    Id = 100,
                    Name = "asdasd",
                    Desc = "asdasd",
                    IsActive = 1,
                });

            Func<Task> action = null;
            "When a source format is updated which is not in the database"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.UpdateSourceFormatAsync(sourceFormat)
                       .ConfigureAwait(false);
                });

            "Then the operation throws exception"
               .x(() => action.Should().ThrowExactly<MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException>()
                   .WithInnerException<MasterDataBusinessLogicNoSuchSourceFormatEntityException>());
        }

        [Scenario]
        public void UpdateAsync_ThrowsWhenUniqueConstraintIsViolated()
        {
            SourceFormat sourceFormat = null;
            "Given there is a source format"
               .x(() => sourceFormat = new SourceFormat
                {
                    Name = "asdasd",
                    Desc = "asdasd",
                    IsActive = 1,
                });

            "And it is stored in the database"
               .x(async () => await _masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false));

            SourceFormat sourceFormat2 = null;
            "And there is another source format"
               .x(() => sourceFormat2 = new SourceFormat
                {
                    Name = "asdasdqqqqq",
                    Desc = "asdasdqqqqq",
                    IsActive = 1,
                });
            SourceFormat sourceFormat2Result = null;
            "And it is stored in the database"
               .x(async () => sourceFormat2Result = await _masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat2)
                   .ConfigureAwait(false));

            "And the first name is setup to the same as the original one"
               .x(() => sourceFormat2Result.Name = sourceFormat.Name);


            Func<Task> action = null;
            "When the modified source format is updated"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.UpdateSourceFormatAsync(sourceFormat2Result)
                       .ConfigureAwait(false);
                });

            "Then the operation throws exception"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException>());
        }
    }
}