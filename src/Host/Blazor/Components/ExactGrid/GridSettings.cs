namespace Blazor.Components.ExactGrid
{
    using System.Collections.Generic;
    using System.Net.Http;

    public class GridSettings
    {
        public Dictionary<string, string> GetAllMethod { get; set; }

        public HttpClient HttpClient { get; set; }
    }
}