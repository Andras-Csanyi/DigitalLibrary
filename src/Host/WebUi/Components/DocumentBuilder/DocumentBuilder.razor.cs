namespace DigitalLibrary.Ui.WebUi.Components.DocumentBuilder
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Microsoft.AspNetCore.Components;

    public partial class DocumentBuilder
    {
        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        private List<SourceFormat> _sourceFormats = new List<SourceFormat>();

        private long _selectedSourceFormatId;

        protected override async Task OnInitializedAsync()
        {
            _sourceFormats = await MasterDataHttpClient.GetSourceFormatsAsync().ConfigureAwait(false);
        }

        private async Task DrawDocumentStructureAsync()
        {
        }
    }
}