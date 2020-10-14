// <copyright file="MasterDataHttpClient.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.WebApi.Client
{
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.Guards;

    /// <inheritdoc />
    public partial class MasterDataHttpClient : IMasterDataHttpClient
    {
        private readonly IDiLibHttpClient _diLibHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterDataHttpClient"/> class.
        /// </summary>
        /// <param name="client">Instance.</param>
        public MasterDataHttpClient(IDiLibHttpClient client)
        {
            Check.IsNotNull(client);
            _diLibHttpClient = client;
        }
    }
}