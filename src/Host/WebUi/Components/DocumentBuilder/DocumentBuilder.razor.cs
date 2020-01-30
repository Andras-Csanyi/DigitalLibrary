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
            await PopulateSourceFormats().ConfigureAwait(false);
            await AddNulloAsFirstElemToSourceFormatList().ConfigureAwait(false);
        }

        private async Task AddNulloAsFirstElemToSourceFormatList()
        {
            SourceFormat nullo = new SourceFormat
            {
                Id = 0,
                Name = "--Select One--",
            };
            _sourceFormats.Insert(0, nullo);
        }

        private async Task PopulateSourceFormats()
        {
            _sourceFormats = await MasterDataHttpClient.GetSourceFormatsAsync().ConfigureAwait(false);
        }

        private async Task NotifyDocumentDisplay()
        {
            Console.WriteLine($"selected format id: {_selectedSourceFormatId}");
            await DocumentBuilderDocumentDisplayNotifier.Update(_selectedSourceFormatId).ConfigureAwait(false);
        }
    }
}