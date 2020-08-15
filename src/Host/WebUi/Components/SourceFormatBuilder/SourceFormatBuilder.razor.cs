// <copyright file="SourceFormatBuilder.razor.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BlazorStrap;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Ui.WebUi.Services;
    using Microsoft.AspNetCore.Components;

    public partial class SourceFormatBuilder
    {
        private BSModal _addNewRootDimensionStructureForm;

        private BSModal _addNewSourceFormatModal;

        private List<Dimension> _dimensions = new List<Dimension>();

        private BSModal _editSourceFormatDetailsModal;

        private bool _isLoadSourceFormatsButtonDisabled;

        private bool _isNewSourceFormatButtonDisabled;

        private bool _isSourceFormatDropDownlistDisabled;

        private DimensionStructure _newRootDimensionStructure = new DimensionStructure();

        private SourceFormat _newSourceFormat = new SourceFormat();

        private SourceFormat _newSourceFormatDetails = new SourceFormat();

        private List<DimensionStructure> _rootDimensionStructureList = new List<DimensionStructure>();

        private BSModal _rootDimensionStructureListModal;

        private List<DimensionStructure> _rootDimensionStructureListRaw = new List<DimensionStructure>();

        private SourceFormat _selectedSourceFormat;

        private List<SourceFormat> _sourceFormats = new List<SourceFormat>();

        private int actualPage = 0;

        private int maxPage = 0;

        private int pageSize = 10;

        [Inject]
        public IDomainEntityHelperService DomainEntityHelperService { get; set; }

        [Inject]
        public SourceFormatBuilderNotifierService SourceFormatBuilderNotifierService { get; set; }

        [Inject]
        public ISourceFormatBuilderService SourceFormatBuilderService { get; set; }

        public async Task AddNewRootDimensionStructureAsync()
        {
            if (_newRootDimensionStructure == null)
            {
                _newRootDimensionStructure = new DimensionStructure();
            }

            _dimensions = await SourceFormatBuilderService.GetDimensionsWithNulloAsync()
               .ConfigureAwait(false);
            await OpenAddNewRootDimensionStructureModalAsync().ConfigureAwait(false);
        }

        private async Task AddNewSourceFormatAsync()
        {
            if (_newSourceFormat == null)
            {
                _newSourceFormat = new SourceFormat();
            }

            await OpenAddNewSourceFormatModal().ConfigureAwait(false);
        }

        private async Task CancelAddNewRootDimensionStructureAsync()
        {
            _newRootDimensionStructure = new DimensionStructure();
            await CloseAddNewRootDimensionStructureModalAsync().ConfigureAwait(false);
        }

        private async Task CancelAddNewSourceFormatAsync()
        {
            _newSourceFormat = new SourceFormat();
            await CloseAddNewSourceFormatModal().ConfigureAwait(false);
        }

        private async Task CancelEditSourceFormatDetails()
        {
            _newSourceFormatDetails = new SourceFormat();
            await CloseSourceFormatDetailsEditModal().ConfigureAwait(false);
        }

        private async Task CancelRootDimensionStructureSelectAsync()
        {
            await CloseSelectingRootDimensionStructureModalAsync().ConfigureAwait(false);
        }

        private async Task CancelSourceFormatOperation()
        {
            SourceFormatBuilderService.SourceFormat = new SourceFormat();
            SourceFormatBuilderService.LoadedSourceFormatId = 0;
        }

        private async Task CloseAddNewRootDimensionStructureModalAsync()
        {
            _newRootDimensionStructure = new DimensionStructure();
            _addNewRootDimensionStructureForm.Hide();
        }

        private async Task CloseAddNewSourceFormatModal()
        {
            _addNewSourceFormatModal.Hide();
        }

        private async Task CloseSelectingRootDimensionStructureModalAsync()
        {
            _rootDimensionStructureListModal.Hide();
        }

        private async Task CloseSourceFormatDetailsEditModal()
        {
            _editSourceFormatDetailsModal.Hide();
        }

        public void Dispose()
        {
            SourceFormatBuilderNotifierService.Notify -= OnNotify;
        }

        private async Task EditSourceFormatDetails()
        {
            if (_newSourceFormatDetails == null)
            {
                _newSourceFormatDetails = new SourceFormat();
            }

            _newSourceFormatDetails.Name = SourceFormatBuilderService.SourceFormat.Name;
            _newSourceFormatDetails.Desc = SourceFormatBuilderService.SourceFormat.Desc;

            await OpenSourceFormatDetailsEditModal().ConfigureAwait(false);
        }

        private async Task NotifyDocumentDisplay()
        {
            await SourceFormatBuilderService.OnUpdate(SourceFormatBuilderService.LoadedSourceFormatId)
               .ConfigureAwait(false);
        }

        protected override async Task OnInitializedAsync()
        {
            SourceFormatBuilderNotifierService.Notify += OnNotify;

            await PopulateSourceFormatsAsync().ConfigureAwait(false);
            await DomainEntityHelperService.AddNulloToListAsFirstItem(_sourceFormats)
               .ConfigureAwait(false);
            _dimensions = await SourceFormatBuilderService.GetDimensionsWithNulloAsync()
               .ConfigureAwait(false);
        }

        private async Task OnNotify()
        {
            await InvokeAsync(() => { StateHasChanged(); });
        }

        private async Task OpenAddNewRootDimensionStructureModalAsync()
        {
            _addNewRootDimensionStructureForm.Show();
        }

        private async Task OpenAddNewSourceFormatModal()
        {
            _addNewSourceFormatModal.Show();
        }

        private async Task OpenRootDimensionStructureSelectingModalAsync()
        {
            _rootDimensionStructureListModal.Show();
        }

        private async Task OpenSourceFormatDetailsEditModal()
        {
            _editSourceFormatDetailsModal.Show();
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

        private async Task PopulateDimensionStructuresListForSelectingRootDimensionStructureAsync()
        {
            _rootDimensionStructureListRaw = await SourceFormatBuilderService
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

        private async Task PopulateSourceFormatsAsync()
        {
            _sourceFormats = await SourceFormatBuilderService.GetSourceFormatsAsync().ConfigureAwait(false);
        }

        private async Task SaveNewRootDimensionStructureHandlerAsync()
        {
            try
            {
                await SourceFormatBuilderService.SaveNewRootDimensionStructureAsync(
                        _newRootDimensionStructure)
                   .ConfigureAwait(false);

                await CloseAddNewRootDimensionStructureModalAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                string msg = $"{nameof(SaveNewRootDimensionStructureHandlerAsync)}";
                Console.WriteLine(msg);
            }
        }

        private async Task SaveNewSourceFormatAsync()
        {
            SourceFormatBuilderService.SourceFormat = _newSourceFormat;
            await SourceFormatBuilderService.UpdateSourceFormatBuilder().ConfigureAwait(false);
            SourceFormatBuilderService.IsSourceFormatDropDownlistDisabled = true;
            SourceFormatBuilderService.IsNewSourceFormatButtonDisabled = true;
            SourceFormatBuilderService.IsLoadSourceFormatsButtonDisabled = true;
            await CloseAddNewSourceFormatModal().ConfigureAwait(false);
        }

        private async Task SaveSourceFormatDetailsAsync()
        {
        }

        private async Task SaveSourceFormatOperation()
        {
        }

        private async Task SelectRootDimensionStructureAsync()
        {
            await PopulateDimensionStructuresListForSelectingRootDimensionStructureAsync().ConfigureAwait(false);
            await OpenRootDimensionStructureSelectingModalAsync().ConfigureAwait(false);
        }

        private async Task SelectRootDimensionStructureHandler(long selectedDimensionStructureId)
        {
            await SourceFormatBuilderService.AddDimensionStructureRootAsync(selectedDimensionStructureId)
               .ConfigureAwait(false);
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
    }
}