// <copyright file="TestBase.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.WebApi.Client.Unit.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;

    using DigitalLibrary.ControlPanel.WebApi.Client.Menu;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1051", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class TestBase
    {
        [SuppressMessage("ReSharper", "SA1401", Justification = "tmp")]
        protected readonly IControlPanelWebClient ControlPanelWebApiClient;

        [SuppressMessage("ReSharper", "CA2000", Justification = "Reviewed.")]
        protected TestBase()
        {
            HttpClient client = new HttpClient();
            ControlPanelWebApiClient = new ControlPanelWebClient(client);
        }
    }
}
