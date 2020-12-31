namespace DigitalLibrary.MasterData.WebApi.Client.SourceFormatDimensionStructureNode
{
    using DigitalLibrary.MasterData.Web.Api.Client.Interfaces;
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.Guards;

    public partial class SourceFormatDimensionStructureNodeHttpClient : ISourceFormatDimensionStructureNodeHttpClient
    {
        private readonly IDiLibHttpClient _dilibHttpClient;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SourceFormatDimensionStructureNodeHttpClient" /> class.
        /// </summary>
        /// <param name="diLibHttpClient">
        ///     Instance of <see cref="IDiLibHttpClient" />.
        /// </param>
        public SourceFormatDimensionStructureNodeHttpClient(IDiLibHttpClient diLibHttpClient)
        {
            Check.IsNotNull(diLibHttpClient);
            _dilibHttpClient = diLibHttpClient;
        }
    }
}