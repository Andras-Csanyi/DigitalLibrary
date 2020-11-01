// <copyright file="TestBase.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

using IMasterDataHttpClient = MasterData.Web.Api.Client.Interfaces.IMasterDataHttpClient;

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;

    using DigitalLibrary.MasterData.WebApi.Client;
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.IntegrationTestFactories.Factories;

    using Microsoft.AspNetCore.Mvc.Testing;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class TestBase<TTestedEntity> : IClassFixture<DiLibMasterDataWebApplicationFactory<Startup, TTestedEntity>>
        where TTestedEntity : class
    {
        protected readonly WebApplicationFactory<Startup> _host;

        protected readonly IMasterDataHttpClient _masterDataHttpClient;

        protected readonly ITestOutputHelper _testOutputHelper;

        protected TestBase(
            DiLibMasterDataWebApplicationFactory<Startup, TTestedEntity> host,
            ITestOutputHelper testOutputHelper)
        {
            _host = host ?? throw new ArgumentNullException(nameof(host));
            _testOutputHelper = testOutputHelper;

            HttpClient httpClient = _host.CreateClient();
            DiLibHttpClient diLibHttpClient = new DiLibHttpClient(httpClient);
            _masterDataHttpClient = new MasterDataHttpClient(diLibHttpClient);
        }
    }
}