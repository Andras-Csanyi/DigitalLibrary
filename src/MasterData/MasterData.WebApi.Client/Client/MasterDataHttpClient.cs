using System;
using DigitalLibrary.Utils.DiLibHttpClient;

namespace DigitalLibrary.MasterData.WebApi.Client.Client
{
    public partial class MasterDataHttpClient : IMasterDataHttpClient
    {
        private readonly IDiLibHttpClient _diLibHttpClient;

        public MasterDataHttpClient(IDiLibHttpClient dilibHttpClient)
        {
            _diLibHttpClient = dilibHttpClient ?? throw new ArgumentNullException();
        }
    }
}