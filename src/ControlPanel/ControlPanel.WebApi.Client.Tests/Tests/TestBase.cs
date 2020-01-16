using System.Net.Http;
using DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Tests.Tests
{
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