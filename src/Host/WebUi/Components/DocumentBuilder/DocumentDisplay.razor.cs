namespace DigitalLibrary.Ui.WebUi.Components.DocumentBuilder
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Microsoft.AspNetCore.Components;

    using Notifiers;

    public partial class DocumentDisplay : IDisposable
    {
        private long _selectedSourceFormatId { get; set; }

        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        [Inject]
        public DocumentBuilderDocumentDisplayNotifier DocumentBuilderDocumentDisplayNotifier { get; set; }

        private SourceFormat _selectedSourceFormat = new SourceFormat();

        private int _counter = 0;

        protected override async Task OnInitializedAsync()
        {
            DocumentBuilderDocumentDisplayNotifier.OnChange += StateHasChanged;
            _selectedSourceFormatId = DocumentBuilderDocumentDisplayNotifier.SelectedSourceFormatId;
            Console.WriteLine($"doc display: {_selectedSourceFormatId}");

            if (_selectedSourceFormatId != 0)
            {
                _selectedSourceFormat = await MasterDataHttpClient.GetSourceFormatById(_selectedSourceFormatId)
                   .ConfigureAwait(false);
            }

            _counter += 1;
        }

        public void Dispose()
        {
            DocumentBuilderDocumentDisplayNotifier.OnChange -= StateHasChanged;
        }
    }
}