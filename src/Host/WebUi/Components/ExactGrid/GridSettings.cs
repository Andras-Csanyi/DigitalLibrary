// <copyright file="GridSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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