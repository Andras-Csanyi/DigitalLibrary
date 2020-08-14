// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid
{
    using System.Collections.Generic;
    using System.Net.Http;

    public class DiLibGridCrudMethodInfo
    {
        public HttpMethod HttpMethod { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

        public string Url { get; set; }
    }
}