namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

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
            SourceFormatBuilderService _sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidators,
                _domainEntityHelperServiceMock.Object);

            _sourceFormatBuilderService.SourceFormat = null;

            Func<Task> action = async () =>
            {
                await _sourceFormatBuilderService.SaveSourceFormatAsync()
                   .ConfigureAwait(false);
            };

            action.Should().ThrowExactly<SourceFormatBuilderServiceException>();
        }
    }
}