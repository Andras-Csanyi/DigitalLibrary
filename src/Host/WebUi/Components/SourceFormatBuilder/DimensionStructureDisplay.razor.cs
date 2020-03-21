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
        public ISourceFormatBuilderService SourceFormatBuilderService { get; set; }

        private SourceFormat _selectedSourceFormat;

        private BSModal _rootDimensionStructureListModal;

        private List<DimensionStructure> _rootDimensionStructureList = new List<DimensionStructure>();

        private List<DimensionStructure> _rootDimensionStructureListRaw = new List<DimensionStructure>();

        private BSModal _addNewRootDimensionStructureForm;

        private DimensionStructure _newRootDimensionStructure = new DimensionStructure();

        private List<Dimension> _dimensions = new List<Dimension>();

        protected override async Task OnInitializedAsync()
        {
            SourceFormatBuilderService.Notify += OnNotify;
            _dimensions = await DimensionStructureDisplayComponentService.GetAllDimensions()
               .ConfigureAwait(false);
        }

        private async Task OnNotify()
        {
            await InvokeAsync(() => { StateHasChanged(); });
        }

        private async Task SetSelectedSourceFormatId(long selectedSourceFormatId)
        {
            _selectedSourceFormatId = selectedSourceFormatId;
        }

        public void Dispose()
        {
            SourceFormatBuilderService.Notify -= OnNotify;
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
            await SourceFormatBuilderService.AddDimensionStructureRootAsync(selectedDimensionStructureId)
               .ConfigureAwait(false);
            await CloseSelectingRootDimensionStructureModalAsync().ConfigureAwait(false);
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

        public async Task AddNewRootDimensionStructureAsync()
        {
            if (_newRootDimensionStructure == null)
            {
                _newRootDimensionStructure = new DimensionStructure();
            }

            await OpenAddNewRootDimensionStructureModalAsync().ConfigureAwait(false);
        }

        private async Task SaveNewRootDimensionStructureHandlerAsync()
        {
            try
            {
                await DimensionStructureDisplayComponentService.SaveNewRootDimensionStructureAsync(
                        _newRootDimensionStructure)
                   .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task OpenAddNewRootDimensionStructureModalAsync()
        {
            _addNewRootDimensionStructureForm.Show();
        }

        private async Task CloseAddNewRootDimensionStructureModalAsync()
        {
            _addNewRootDimensionStructureForm.Hide();
        }

        private async Task CancelAddNewRootDimensionStructureAsync()
        {
            _newRootDimensionStructure = new DimensionStructure();
            await CloseAddNewRootDimensionStructureModalAsync().ConfigureAwait(false);
        }
    }
}