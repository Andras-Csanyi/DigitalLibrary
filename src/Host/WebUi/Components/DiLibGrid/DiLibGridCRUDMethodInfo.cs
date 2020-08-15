// <copyright file="DiLibGridCRUDMethodInfo.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

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