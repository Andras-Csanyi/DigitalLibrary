// <copyright file="Update_SourceFormat_NameDescIsActive_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using Validators.TestData;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class Update_SourceFormat_NameDescIsActive_Should : TestBase
    {
        public Update_SourceFormat_NameDescIsActive_Should()
            : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Update_SourceFormat_NameDescIsActive_Should);

        [Theory]
        [MemberData(
            nameof(MasterData_DimensionStructure_TestData.ModifyTopDimensionStructure_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public async Task Modify(
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            SourceFormat orig = new SourceFormat
            {
                Name = "asdasd",
                Desc = "asdasd",
                IsActive = 1,
            };

            SourceFormat origRes = await masterDataBusinessLogic.AddSourceFormatAsync(
                orig).ConfigureAwait(false);

            SourceFormat mod = new SourceFormat
            {
                Id = origRes.Id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Act
            SourceFormat res = await masterDataBusinessLogic.UpdateSourceFormatAsync(mod)
               .ConfigureAwait(false);

            // Assert
            res.Should().NotBeNull();
            res.Id.Should().Be(origRes.Id);
            res.Name.Should().Be(name);
            res.Desc.Should().Be(desc);
            res.IsActive.Should().Be(isActive);
        }

        [Fact]
        public void ThrowException_WhenThereIsNoSuchSourceFormat()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat
            {
                Id = 100,
                Name = "asdasd",
                Desc = "asdasd",
                IsActive = 1,
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.UpdateSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException>()
               .WithInnerException<MasterDataBusinessLogicNoSuchSourceFormatEntityException>();
        }

        [Fact]
        public async Task ThrowException_WhenUniqueConstraintIsViolated()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat
            {
                Name = "asdasd",
                Desc = "asdasd",
                IsActive = 1,
            };
            SourceFormat sourceFormatResult = await masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat)
               .ConfigureAwait(false);

            SourceFormat sourceFormat2 = new SourceFormat
            {
                Name = "asdasdqqqqq",
                Desc = "asdasdqqqqq",
                IsActive = 1,
            };
            SourceFormat sourceFormat2Result = await masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat2)
               .ConfigureAwait(false);

            sourceFormat2Result.Name = sourceFormat.Name;

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.UpdateSourceFormatAsync(sourceFormat2Result)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException>();
        }
    }
}