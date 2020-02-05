namespace DigitalLibrary.ControlPanel.WebApi.Client.Unit.Tests
{
    using System.Net.Http;

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