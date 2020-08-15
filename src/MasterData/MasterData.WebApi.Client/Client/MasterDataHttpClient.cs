// <copyright file="MasterDataHttpClient.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.WebApi.Client
{
    using Utils.DiLibHttpClient;
    using Utils.Guards;

    public partial class MasterDataHttpClient : IMasterDataHttpClient
    {
        private readonly IDiLibHttpClient _diLibHttpClient;

        public MasterDataHttpClient(IDiLibHttpClient client)
        {
            Check.IsNotNull(client);
            _diLibHttpClient = client;
        }
    }
}