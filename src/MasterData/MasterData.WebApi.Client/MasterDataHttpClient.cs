// <copyright file="MasterDataHttpClient.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.WebApi.Client
{
    using DigitalLibrary.MasterData.Web.Api.Client.Interfaces;
    using DigitalLibrary.Utils.Guards;

    /// <inheritdoc/>
    public partial class MasterDataHttpClient : IMasterDataHttpClient
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MasterDataHttpClient"/> class.
        /// </summary>
        /// <param name="sourceFormatHttpClientClient">
        ///     Instance of <see cref="ISourceFormatHttpClient"/> client.
        /// </param>
        /// <param name="dimensionStructureHttpClient">
        ///     Instance of <see cref="IDimensionStructureHttpClient"/> client.
        /// </param>
        /// <param name="sourceFormatDimensionStructureNodeHttpClient">
        ///     Instance of <see cref="ISourceFormatDimensionStructureNodeHttpClient"/> client.
        /// </param>
        public MasterDataHttpClient(
            ISourceFormatHttpClient sourceFormatHttpClientClient,
            IDimensionStructureHttpClient dimensionStructureHttpClient)
        {
            Check.IsNotNull(sourceFormatHttpClientClient);
            SourceFormatHttpClient = sourceFormatHttpClientClient;

            Check.IsNotNull(dimensionStructureHttpClient);
            DimensionStructureHttpClient = dimensionStructureHttpClient;
        }

        /// <inheritdoc/>
        public ISourceFormatHttpClient SourceFormatHttpClient { get; set; }

        /// <inheritdoc/>
        public IDimensionStructureHttpClient DimensionStructureHttpClient { get; set; }
    }
}
