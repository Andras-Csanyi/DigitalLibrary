// <copyright file="GridSettings.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
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