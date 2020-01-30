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
            DocumentBuilderDocumentDisplayNotifier.Notify += OnNotify;
            Console.WriteLine($"doc display oninit...: {_selectedSourceFormatId}");


            _counter += 1;
        }

        public async Task PopulateSourceFormatToBeDisplayed(long sourceFormatId)
        {
            if (sourceFormatId != 0)
            {
                _selectedSourceFormat = await MasterDataHttpClient.GetSourceFormatById(sourceFormatId)
                   .ConfigureAwait(false);
            }
        }

        public async Task OnNotify(long selectedSourceFormatId)
        {
            Console.WriteLine($"OnNotify in DocDisplay: {selectedSourceFormatId}");
            await SetSelectedSourceFormatId(selectedSourceFormatId).ConfigureAwait(false);
            await PopulateSourceFormatToBeDisplayed(selectedSourceFormatId).ConfigureAwait(false);
            await InvokeAsync(() => { StateHasChanged(); });
        }

        private async Task SetSelectedSourceFormatId(long selectedSourceFormatId)
        {
            _selectedSourceFormatId = selectedSourceFormatId;
        }

        public void Dispose()
        {
            DocumentBuilderDocumentDisplayNotifier.Notify -= OnNotify;
        }
    }
}