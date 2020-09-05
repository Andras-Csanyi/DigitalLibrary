namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Validators.TestData;
    using DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Input validation of saving <see cref="SourceFormat"/> is checked.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "More readable class name.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class SaveSourceFormatAsync_Validation_Should : TestBase
    {
        public SaveSourceFormatAsync_Validation_Should(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public void ThrowException_WhenInputIsNull()
        {
            // Arrange
            SourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidators,
                _domainEntityHelperServiceMock.Object);

            sourceFormatBuilderService.SourceFormat = null;

            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.SaveSourceFormatAsync()
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<SourceFormatBuilderServiceException>();
        }

        [Theory]
        [MemberData(
            nameof(MasterData_SourceFormat_Validation_TestData.AddNew),
            MemberType = typeof(MasterData_SourceFormat_Validation_TestData))]
        public void ThrowException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            SourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidators,
                _domainEntityHelperServiceMock.Object);

            sourceFormatBuilderService.SourceFormat.Id = id;
            sourceFormatBuilderService.SourceFormat.Name = name;
            sourceFormatBuilderService.SourceFormat.Desc = desc;
            sourceFormatBuilderService.SourceFormat.IsActive = isActive;

            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.SaveSourceFormatAsync()
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<SourceFormatBuilderServiceException>();
        }
    }
}