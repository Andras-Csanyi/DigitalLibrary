namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System;

    using Utils.DiLibHttpClient;

    public partial class MasterDataHttpClient : IMasterDataHttpClient
    {
        private readonly IDiLibHttpClient _diLibHttpClient;

        public MasterDataHttpClient(IDiLibHttpClient dilibHttpClient)
        {
            _diLibHttpClient = dilibHttpClient ?? throw new ArgumentNullException();
        }
    }
}