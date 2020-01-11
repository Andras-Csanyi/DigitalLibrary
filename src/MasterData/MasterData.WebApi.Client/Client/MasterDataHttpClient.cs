namespace DigitalLibrary.IaC.MasterData.WebApi.Client.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using DiLibHttpClient;

    using DomainModel.DomainModel;

    using Web.Api.Api;

    public partial class MasterDataHttpClient : IMasterDataHttpClient
    {
        private readonly IDiLibHttpClient _diLibHttpClient;

        public MasterDataHttpClient(IDiLibHttpClient dilibHttpClient)
        {
            _diLibHttpClient = dilibHttpClient ?? throw new ArgumentNullException();
        }
    }
}