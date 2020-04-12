namespace WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.MasterData.WebApi.Client;
    using DigitalLibrary.Ui.WebUi.Services;
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Moq;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Ctor_Validation_Should : TestBase
    {
        // [Theory]
        // [InlineData(null, null)]
        // [InlineData(new MasterDataHttpClient(new DiLibHttpClient(new HttpClient(new HttpClientHandler()))), null)]
        // [InlineData(null, null)]
        // public async Task ThrowException_WhenInputIsNull(
        //     IMasterDataHttpClient masterDataHttpClient,
        //     IMasterDataValidators masterDataValidators)
        // {
        //     // Arrange
        //
        //     // Act
        //     Func<Task> action = async () =>
        //     {
        //         new SourceFormatBuilderService(masterDataHttpClient, masterDataValidators);
        //     };
        //
        //     // Assert
        //     action.Should().ThrowExactly<GuardException>();
        // }
    }
}