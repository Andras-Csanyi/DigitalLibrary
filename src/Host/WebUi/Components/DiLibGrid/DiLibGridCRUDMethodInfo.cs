namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid
{
    using System.Collections.Generic;
    using System.Net.Http;

    public class DiLibGridCrudMethodInfo
    {
        public string Url { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

        public HttpMethod HttpMethod { get; set; }
    }
}