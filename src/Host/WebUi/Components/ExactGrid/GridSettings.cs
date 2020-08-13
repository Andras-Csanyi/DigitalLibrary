// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.Ui.WebUi.Components.ExactGrid
{
    using System.Collections.Generic;
    using System.Net.Http;

    public class GridSettings
    {
        public Dictionary<string, string> GetAllMethod { get; set; }

        public HttpClient HttpClient { get; set; }
    }
}