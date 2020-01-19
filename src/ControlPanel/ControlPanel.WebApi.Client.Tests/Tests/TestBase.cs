using System.Net.Http;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Tests.Tests
{
    using Client.Menu;

    public class TestBase
    {
        protected IControlPanelWebClient ControlPanelWebApiClient;

        public TestBase()
        {
            HttpClient client = new HttpClient();
            ControlPanelWebApiClient = new ControlPanelWebClient(client);
        }
    }
}