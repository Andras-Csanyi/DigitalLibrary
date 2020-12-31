namespace DigitalLibrary.MasterData.WebApi.Client.DimensionStructureNode
{
    using DigitalLibrary.MasterData.Web.Api.Client.Interfaces;
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.Guards;

    public partial class DimensionStructureNodeHttpClient : IDimensionStructureNodeHttpClient
    {
        private readonly IDiLibHttpClient _dilibHttpClient;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DimensionStructureNodeHttpClient" /> class.
        /// </summary>
        /// <param name="diLibHttpClient">
        ///     Instance of <see cref="IDiLibHttpClient" />.
        /// </param>
        public DimensionStructureNodeHttpClient(IDiLibHttpClient diLibHttpClient)
        {
            Check.IsNotNull(diLibHttpClient);
            _dilibHttpClient = diLibHttpClient;
        }
    }
}