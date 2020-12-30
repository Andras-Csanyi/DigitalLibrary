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
        ///     Gets or sets instance of <see cref="SourceFormatHttpClient" />.
        /// </summary>
        ISourceFormatHttpClient SourceFormatHttpClient { get; set; }

        /// <summary>
        ///     Gets or sets instance of <see cref="DimensionStructureHttpClient" />.
        /// </summary>
        IDimensionStructureHttpClient DimensionStructureHttpClient { get; set; }

        /// <summary>
        /// Gets or sets instance of <see cref="SourceFormatDimensionStructureNodeHttpClient"/>.
        /// </summary>
        ISourceFormatDimensionStructureNodeHttpClient SourceFormatDimensionStructureNodeHttpClient { get; set; }

        /// <summary>
        /// Gets or sets instance of <see cref="DimensionStructureNodeHttpClient"/>.
        /// </summary>
        IDimensionStructureNodeHttpClient DimensionStructureNodeHttpClient { get; set; }
    }
}