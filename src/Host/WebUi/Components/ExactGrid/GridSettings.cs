using System.Collections.Generic;
using System.Net.Http;

namespace DigitalLibrary.Ui.WebUi.Components.ExactGrid
{
    public class GridSettings
    {
        public Dictionary<string, string> GetAllMethod { get; set; }

        public HttpClient HttpClient { get; set; }
    }
}