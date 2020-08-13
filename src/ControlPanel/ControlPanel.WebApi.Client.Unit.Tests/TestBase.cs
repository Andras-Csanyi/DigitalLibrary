// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.ControlPanel.WebApi.Client.Unit.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;

    using Client.Menu;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1051")]
    public class TestBase
    {
        protected readonly IControlPanelWebClient ControlPanelWebApiClient;

        [SuppressMessage("ReSharper", "CA2000")]
        protected TestBase()
        {
            HttpClient client = new HttpClient();
            ControlPanelWebApiClient = new ControlPanelWebClient(client);
        }
    }
}