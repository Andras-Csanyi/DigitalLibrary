namespace WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.Ui.WebUi.Services;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xunit;

    public class Ctor_Validation_Should : TestBase
    {
        [Fact]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () => { new SourceFormatBuilderService(_masterDataWebApiClientMock.Object); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}