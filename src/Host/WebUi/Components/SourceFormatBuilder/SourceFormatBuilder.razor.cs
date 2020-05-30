namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BlazorStrap;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;

    using FluentValidation;

    using Microsoft.AspNetCore.Components;

    using Services;

    public partial class SourceFormatBuilder
    {
        [Inject]
        public ISourceFormatBuilderService SourceFormatBuilderService { get; set; }

        [Inject]
        public SourceFormatBuilderNotifierService SourceFormatBuilderNotifierService { get; set; }

        private List<SourceFormat> _sourceFormats = new List<SourceFormat>();

        private BSModal _addNewSourceFormatModal;

        private SourceFormat _newSourceFormat = new SourceFormat();

        private bool _isSourceFormatDropDownlistDisabled;

        private bool _isLoadSourceFormatsButtonDisabled;

        private bool _isNewSourceFormatButtonDisabled;

        private int pageSize = 10;

        private int actualPage = 0;

        private int maxPage = 0;

        private SourceFormat _selectedSourceFormat;

        private BSModal _rootDimensionStructureListModal;

        private List<DimensionStructure> _rootDimensionStructureList = new List<DimensionStructure>();

        private List<DimensionStructure> _rootDimensionStructureListRaw = new List<DimensionStructure>();

        private BSModal _addNewRootDimensionStructureForm;

        private DimensionStructure _newRootDimensionStructure = new DimensionStructure();

        private BSModal _editSourceFormatDetailsModal;

        private SourceFormat _newSourceFormatDetails = new SourceFormat();

        private List<Dimension> _dimensions = new List<Dimension>();

        protected override async Task OnInitializedAsync()
        {
            SourceFormatBuilderNotifierService.Notify += OnNotify;

            await PopulateSourceFormatsAsync().ConfigureAwait(false);
            await AddNulloAsFirstElemToSourceFormatList().ConfigureAwait(false);
            _dimensions = await SourceFormatBuilderService.GetAvailableDimensionsAsync().ConfigureAwait(false);
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

        private async Task PopulateSourceFormatsAsync()
        {
            _sourceFormats = await SourceFormatBuilderService.GetSourceFormatsAsync().ConfigureAwait(false);
        }

        private async Task NotifyDocumentDisplay()
        {
            await SourceFormatBuilderService.OnUpdate(SourceFormatBuilderService.LoadedSourceFormatId)
               .ConfigureAwait(false);
        }

        private async Task OpenAddNewSourceFormatModal()
        {
            _addNewSourceFormatModal.Show();
        }

        private async Task CloseAddNewSourceFormatModal()
        {
            _addNewSourceFormatModal.Hide();
        }

        private async Task AddNewSourceFormatAsync()
        {
            if (_newSourceFormat == null)
            {
                _newSourceFormat = new SourceFormat();
            }

            await OpenAddNewSourceFormatModal().ConfigureAwait(false);
        }

        private async Task CancelAddNewSourceFormatAsync()
        {
            _newSourceFormat = new SourceFormat();
            await CloseAddNewSourceFormatModal().ConfigureAwait(false);
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

        private async Task OnNotify()
        {
            await InvokeAsync(() => { StateHasChanged(); });
        }

        public void Dispose()
        {
            SourceFormatBuilderNotifierService.Notify -= OnNotify;
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

        private async Task OpenRootDimensionStructureSelectingModalAsync()
        {
            _rootDimensionStructureListModal.Show();
        }

        private async Task CloseSelectingRootDimensionStructureModalAsync()
        {
            _rootDimensionStructureListModal.Hide();
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

            _dimensions = await SourceFormatBuilderService.GetAvailableDimensionsAsync().ConfigureAwait(false);
            await OpenAddNewRootDimensionStructureModalAsync().ConfigureAwait(false);
        }

        private async Task SaveNewRootDimensionStructureHandlerAsync()
        {
            try
            {
                await SourceFormatBuilderService.MasterDataValidators.DimensionStructureValidator
                   .ValidateAndThrowAsync(
                        _newRootDimensionStructure,
                        ruleSet: DimensionStructureValidatorRulesets.Add)
                   .ConfigureAwait(false);
                _newRootDimensionStructure.Guid = Guid.NewGuid();

                SourceFormatBuilderService.SourceFormat.RootDimensionStructure = _newRootDimensionStructure;
                SourceFormatBuilderService.SourceFormat.RootDimensionStructure.DimensionId =
                    _newRootDimensionStructure.DimensionId;

                Dimension selectedDimension = _dimensions
                   .FirstOrDefault(p => p.Id == _newRootDimensionStructure.DimensionId);
                await SourceFormatBuilderService.AddDimensionToTheAlreadyUsedDimensionsListAsync(selectedDimension)
                   .ConfigureAwait(false);

                SourceFormatBuilderService.SourceFormat.RootDimensionStructure.Dimension = selectedDimension;
            }
            catch (Exception e)
            {
                string msg = $"{nameof(SaveNewRootDimensionStructureHandlerAsync)}";
                Console.WriteLine(msg);
            }

            await CloseAddNewRootDimensionStructureModalAsync().ConfigureAwait(false);
        }

        private async Task OpenAddNewRootDimensionStructureModalAsync()
        {
            _addNewRootDimensionStructureForm.Show();
        }

        private async Task CloseAddNewRootDimensionStructureModalAsync()
        {
            _newRootDimensionStructure = new DimensionStructure();
            _addNewRootDimensionStructureForm.Hide();
        }

        private async Task CancelAddNewRootDimensionStructureAsync()
        {
            _newRootDimensionStructure = new DimensionStructure();
            await CloseAddNewRootDimensionStructureModalAsync().ConfigureAwait(false);
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

        private async Task CancelEditSourceFormatDetails()
        {
            _newSourceFormatDetails = new SourceFormat();
            await CloseSourceFormatDetailsEditModal().ConfigureAwait(false);
        }

        private async Task SaveSourceFormatDetailsAsync()
        {
        }

        private async Task OpenSourceFormatDetailsEditModal()
        {
            _editSourceFormatDetailsModal.Show();
        }

        private async Task CloseSourceFormatDetailsEditModal()
        {
            _editSourceFormatDetailsModal.Hide();
        }

        private async Task CancelSourceFormatOperation()
        {
            SourceFormatBuilderService.SourceFormat = new SourceFormat();
            SourceFormatBuilderService.LoadedSourceFormatId = 0;
        }

        private async Task SaveSourceFormatOperation()
        {
        }
    }
}