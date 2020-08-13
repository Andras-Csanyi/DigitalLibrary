// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

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