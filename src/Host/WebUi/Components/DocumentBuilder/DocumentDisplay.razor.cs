namespace DigitalLibrary.Ui.WebUi.Components.DocumentBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BlazorStrap;

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

        private SourceFormat _selectedSourceFormat;

        private BSModal _rootDimensionStructureListModal;

        private List<DimensionStructure> _rootDimensionStructureList = new List<DimensionStructure>();

        protected override async Task OnInitializedAsync()
        {
            DocumentBuilderDocumentDisplayNotifier.Notify += OnNotify;
        }

        public async Task PopulateSourceFormatToBeDisplayed(long sourceFormatId)
        {
            if (sourceFormatId != 0)
            {
                SourceFormat query = new SourceFormat { Id = sourceFormatId };
                _selectedSourceFormat = await MasterDataHttpClient.GetSourceFormatById(query)
                   .ConfigureAwait(false);
            }
        }

        public async Task OnNotify(long selectedSourceFormatId)
        {
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

        private async Task PopulateDimensionStructuresListForSelectingRootDimensionStructure()
        {
            _rootDimensionStructureList = await MasterDataHttpClient.GetDimensionStructuresAsync()
               .ConfigureAwait(false);
        }

        private async Task OpenRootDimensionStructureSelectingModalAsync()
        {
            _rootDimensionStructureListModal.Show();
        }

        private async Task CloseSelectingRootDimensionStructureModalAsync()
        {
            _rootDimensionStructureListModal.Hide();
        }

        private async Task SelectRootDimensionStructure()
        {
            await PopulateDimensionStructuresListForSelectingRootDimensionStructure().ConfigureAwait(false);
            await OpenRootDimensionStructureSelectingModalAsync().ConfigureAwait(false);
        }

        private async Task SelectRootDimensionStructureHandler(long selectedDimensionStructureId)
        {
        }

        private async Task CancelRootDimensionStructureSelectAsync()
        {
            await CloseSelectingRootDimensionStructureModalAsync().ConfigureAwait(false);
        }
    }
}