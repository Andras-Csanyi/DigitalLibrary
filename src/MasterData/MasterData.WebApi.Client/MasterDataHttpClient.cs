// <copyright file="MasterDataHttpClient.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

using IMasterDataHttpClient = DigitalLibrary.MasterData.Web.Api.Client.Interfaces.IMasterDataHttpClient;
using ISourceFormat = DigitalLibrary.MasterData.Web.Api.Client.Interfaces.ISourceFormat;

namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api.Client.Interfaces;
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.Guards;

    /// <inheritdoc />
    public partial class MasterDataHttpClient : IMasterDataHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterDataHttpClient"/> class.
        /// </summary>
        /// <param name="sourceFormatClient">
        ///    Represents <see cref="MasterData.Web.Api.Client.Interfaces.ISourceFormat"/> client.
        /// </param>
        public MasterDataHttpClient(
            ISourceFormat sourceFormatClient
        )
        {
            Check.IsNotNull(sourceFormatClient);
            SourceFormat = sourceFormatClient;
        }

        public ISourceFormat SourceFormat { get; set; }
    }
}