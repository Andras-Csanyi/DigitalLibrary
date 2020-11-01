namespace DigitalLibrary.MasterData.WebApi.Client.SourceFormat
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.MasterData.Web.Api.Client.Interfaces;
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.Guards;

    /// <inheritdoc />
    public partial class SourceFormatHttpClient : ISourceFormat
    {
        private readonly IDiLibHttpClient _diLibHttpClient;

        private const string SourceFormatBase = MasterDataApi.SourceFormat.SourceFormatBase;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceFormatHttpClient"/> class.
        /// </summary>
        /// <param name="diLibHttpClient">Http client.</param>
        public SourceFormatHttpClient(IDiLibHttpClient diLibHttpClient)
        {
            Check.IsNotNull(diLibHttpClient);
            _diLibHttpClient = diLibHttpClient;
        }
    }
}