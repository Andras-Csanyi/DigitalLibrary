// <copyright file="IMasterDataHttpClient.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Web.Api.Client.Interfaces
{
    /// <summary>
    ///     Master Data Http Client interface.
    /// </summary>
    public partial interface IMasterDataHttpClient
    {
        /// <summary>
        ///     Instance of <see cref="SourceFormatHttpClient" />.
        /// </summary>
        ISourceFormatHttpClient SourceFormatHttpClient { get; set; }

        /// <summary>
        ///     Instance of <see cref="DimensionStructureHttpClient" />.
        /// </summary>
        IDimensionStructureHttpClient DimensionStructureHttpClient { get; set; }
    }
}