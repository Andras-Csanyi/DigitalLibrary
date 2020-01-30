namespace DigitalLibrary.Ui.WebUi.Components.DocumentBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Microsoft.AspNetCore.Components;

    using Notifiers;

    public partial class DocumentBuilder
    {
        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        [Inject]
        public DocumentBuilderDocumentDisplayNotifier DocumentBuilderDocumentDisplayNotifier { get; set; }

        private List<SourceFormat> _sourceFormats = new List<SourceFormat>();

        private long _selectedSourceFormatId;

        protected override async Task OnInitializedAsync()
        {
            _sourceFormats = await MasterDataHttpClient.GetSourceFormatsAsync().ConfigureAwait(false);
        }

        private async Task DrawDocumentStructureAsync()
        {
        }

        private async Task NotifyDocumentDisplay(long selectedSourceFormatId)
        {
            Console.WriteLine($"selected format id: {selectedSourceFormatId}");
            await DocumentBuilderDocumentDisplayNotifier.Update(selectedSourceFormatId).ConfigureAwait(false);
        }
    }
}