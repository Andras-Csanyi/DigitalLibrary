namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BlazorStrap;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Microsoft.AspNetCore.Components;

    using Notifiers;

    using Services;

    public partial class DimensionStructureDisplay : IDisposable
    {
        private long _selectedSourceFormatId { get; set; }

        private int pageSize = 10;

        private int actualPage = 0;

        private int maxPage = 0;

        [Inject]
        public IDimensionStructureDisplayComponentService DimensionStructureDisplayComponentService { get; set; }

        [Inject]
        public DocumentBuilderDocumentDisplayNotifier DocumentBuilderDocumentDisplayNotifier { get; set; }

        [Inject]
        public SourceFormatBuilderService SourceFormatBuilderService { get; set; }

        private SourceFormat _selectedSourceFormat;

        private BSModal _rootDimensionStructureListModal;

        private List<DimensionStructure> _rootDimensionStructureList = new List<DimensionStructure>();

        private List<DimensionStructure> _rootDimensionStructureListRaw = new List<DimensionStructure>();

        protected override async Task OnInitializedAsync()
        {
            DocumentBuilderDocumentDisplayNotifier.Notify += OnNotify;
        }

        public async Task PopulateSourceFormatToBeDisplayed(long sourceFormatId)
        {
            if (sourceFormatId != 0)
            {
                await SourceFormatBuilderService.Init(sourceFormatId).ConfigureAwait(false);
                _selectedSourceFormat = SourceFormatBuilderService.SourceFormat;
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
            _rootDimensionStructureListRaw = await DimensionStructureDisplayComponentService
               .GetDimensionStructuresAsync()
               .ConfigureAwait(false);
            maxPage = _rootDimensionStructureListRaw.Count / pageSize;
            await PopulateDisplayedRootDimensionStructureListPagerAction().ConfigureAwait(false);
        }

        private async Task PopulateDisplayedRootDimensionStructureListPagerAction()
        {
            int skip = pageSize * actualPage;
            _rootDimensionStructureList = _rootDimensionStructureListRaw
               .OrderBy(p => p.Id)
               .Skip(skip)
               .Take(pageSize)
               .ToList();
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

        private async Task ShowFirstPagePagerAction()
        {
            actualPage = 0;
            await PopulateDisplayedRootDimensionStructureListPagerAction().ConfigureAwait(false);
        }

        private async Task ShowLastPagePagerAction()
        {
            actualPage = maxPage;
            await PopulateDisplayedRootDimensionStructureListPagerAction().ConfigureAwait(false);
        }

        private async Task PageBackOnePagePagerAction()
        {
            if (actualPage >= 1)
            {
                actualPage -= 1;
            }

            await PopulateDisplayedRootDimensionStructureListPagerAction().ConfigureAwait(false);
        }

        private async Task PageForwardOnePagePagerAction()
        {
            if (actualPage <= maxPage)
            {
                actualPage += 1;
            }

            await PopulateDisplayedRootDimensionStructureListPagerAction().ConfigureAwait(false);
        }
    }
}