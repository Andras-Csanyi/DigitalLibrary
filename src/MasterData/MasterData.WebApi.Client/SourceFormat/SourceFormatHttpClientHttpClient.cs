namespace DigitalLibrary.MasterData.WebApi.Client.SourceFormat
{
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.MasterData.Web.Api.Client.Interfaces;
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.Guards;

    /// <inheritdoc />
    public partial class SourceFormatHttpClientHttpClient : ISourceFormatHttpClient
    {
        private readonly IDiLibHttpClient _diLibHttpClient;

        private const string SourceFormatBase = MasterDataApi.SourceFormat.BasePath;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SourceFormatHttpClientHttpClient" /> class.
        /// </summary>
        /// <param name="diLibHttpClient">Http client.</param>
        public SourceFormatHttpClientHttpClient(IDiLibHttpClient diLibHttpClient)
        {
            Check.IsNotNull(diLibHttpClient);
            _diLibHttpClient = diLibHttpClient;
        }
    }
}