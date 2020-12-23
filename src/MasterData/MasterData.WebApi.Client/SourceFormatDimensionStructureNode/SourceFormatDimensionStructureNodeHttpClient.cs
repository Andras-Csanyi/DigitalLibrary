namespace DigitalLibrary.MasterData.WebApi.Client.SourceFormatDimensionStructureNode
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.MasterData.Web.Api.Client.Interfaces;
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    public partial class SourceFormatDimensionStructureNodeHttpClient : ISourceFormatDimensionStructureNodeHttpClient
    {
        private readonly IDiLibHttpClient _dilibHttpClient;

        public SourceFormatDimensionStructureNodeHttpClient(IDiLibHttpClient diLibHttpClient)
        {
            Check.IsNotNull(diLibHttpClient);
            _dilibHttpClient = diLibHttpClient;
        }
    }
}