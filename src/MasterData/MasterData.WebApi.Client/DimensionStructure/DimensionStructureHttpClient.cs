namespace DigitalLibrary.MasterData.WebApi.Client.DimensionStructure
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api.Client.Interfaces;
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    /// <summary>
    /// HttpClient for DimensionStructure which provides Http communication with
    /// DimensionStructure WebApi endpoint.
    /// </summary>
    public partial class DimensionStructureHttpClientHttpClient : IDimensionStructureHttpClient
    {
        private readonly IDiLibHttpClient _diLibHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DimensionStructureHttpClientHttpClient"/> class.
        /// </summary>
        /// <param name="diLibHttpClient">
        /// DilibHttpClient instance.
        /// </param>
        public DimensionStructureHttpClientHttpClient(IDiLibHttpClient diLibHttpClient)
        {
            Check.IsNotNull(diLibHttpClient);
            _diLibHttpClient = diLibHttpClient;
        }
    }
}