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

    using Utils.Guards;

    public partial class DimensionStructureTree
    {
        private BSModal _addOrUpdateDimensionStructureForm;

        private int _amountOfDimensionStructures = 0;

        private BSModal _confirmDeleteDocumentStructureBsModalWindow;

        private List<Dimension> _dimensions = new List<Dimension>();

        private List<DimensionStructure> _dimensionStructures = new List<DimensionStructure>();

        private DimensionStructure _documentStructureToBeDeletedFromTree;

        private DimensionStructure _newDimensionStructure = new DimensionStructure { Guid = Guid.NewGuid() };

        private int _updateDimensionStructureModalListPageSize = 10;

        private BSModal _updateDocumentStructureInTheTreeModalWindow;

        private int actualPage = 0;

        private int maxPage = 0;

        [Parameter]
        public DimensionStructure DimensionStructureParameter { get; set; }

        [Inject]
        public IDimensionStructureTreeComponentService DimensionStructureTreeComponentService { get; set; }

        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        [Parameter]
        public Guid ParentDimensionStructureGuidParameter { get; set; }

        [Inject]
        public SourceFormatBuilderNotifierService SourceFormatBuilderNotifierService { get; set; }

        [Inject]
        public ISourceFormatBuilderService SourceFormatBuilderService { get; set; }

        public async Task AddDocumentStructureToTreeAsync()
        {
            _dimensions = await SourceFormatBuilderService.GetDimensionsWithNulloAsync()
               .ConfigureAwait(false);
            await OpenNewDimensionStructureFormModalAsync().ConfigureAwait(false);
        }

        private async Task CancelAddNewRootDimensionStructureAsync()
        {
            _newDimensionStructure = new DimensionStructure { Guid = Guid.NewGuid() };
            await CloseNewDimensionStructureToTheTreeModalAsync().ConfigureAwait(false);
        }

        private async Task CancelDeleteDocumentStructureConfirmedAsync()
        {
            SourceFormatBuilderService.DimensionStructureToBeDeletedFromTree = null;
            await CloseDeleteDocumentStructureFromTreeConfirmModalAsync().ConfigureAwait(false);
        }

        private async Task CancelDocumentStructureUpdateInTreeModalWindowAsync()
        {
            SourceFormatBuilderService.UpdateNodeOldDimensionStructure = null;
            await HideUpdateDocumentStructureInTreeModalWindowAsync().ConfigureAwait(false);
        }

        private async Task CloseDeleteDocumentStructureFromTreeConfirmModalAsync()
        {
            _confirmDeleteDocumentStructureBsModalWindow.Hide();
        }

        private async Task CloseNewDimensionStructureToTheTreeModalAsync()
        {
            _addOrUpdateDimensionStructureForm.Hide();
        }

        private async Task CountAmountOfDimensionStructures()
        {
            maxPage = _amountOfDimensionStructures / _updateDimensionStructureModalListPageSize;
        }

        private async Task DeleteDocumentStructureConfirmedAsync()
        {
            try
            {
                await SourceFormatBuilderService.DeleteDocumentStructureFromTreeAsync()
                   .ConfigureAwait(false);
                SourceFormatBuilderService.DimensionStructureToBeDeletedFromTree = null;
                await CloseDeleteDocumentStructureFromTreeConfirmModalAsync().ConfigureAwait(false);
                await SourceFormatBuilderNotifierService.UpdateSourceFormatBuilder().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error happened while delete...", e);
            }
        }


        public async Task DeleteDocumentStructureFromTreeAsync(DimensionStructure documentStructure)
        {
            Check.IsNotNull(documentStructure);
            SourceFormatBuilderService.DimensionStructureToBeDeletedFromTree = documentStructure;
            await OpenDeleteDocumentStructureFromTreeConfirmModalAsync().ConfigureAwait(false);
        }

        private async Task EditDocumentStructureInTheTreeAsync(DimensionStructure dimensionStructureParameter)
        {
            _newDimensionStructure = dimensionStructureParameter;
            _dimensions = await SourceFormatBuilderService.GetDimensionsWithNulloAsync()
               .ConfigureAwait(false);
            await OpenNewDimensionStructureFormModalAsync().ConfigureAwait(false);
        }

        private async Task HideUpdateDocumentStructureInTreeModalWindowAsync()
        {
            _updateDocumentStructureInTheTreeModalWindow.Hide();
        }

        protected override async Task OnInitializedAsync()
        {
            if (DimensionStructureParameter.Guid == Guid.Empty)
            {
                DimensionStructureParameter.Guid = Guid.NewGuid();
            }

            _dimensions = await SourceFormatBuilderService.GetDimensionsWithNulloAsync()
               .ConfigureAwait(false);
        }

        private async Task OpenDeleteDocumentStructureFromTreeConfirmModalAsync()
        {
            _confirmDeleteDocumentStructureBsModalWindow.Show();
        }

        private async Task OpenNewDimensionStructureFormModalAsync()
        {
            _addOrUpdateDimensionStructureForm.Show();
        }

        private async Task PageBackOnePagePagerAction()
        {
            if (actualPage >= 1)
            {
                actualPage -= 1;
            }

            await PopulateUpdateDimensionStructureNodesList().ConfigureAwait(false);
        }

        private async Task PageForwardOnePagePagerAction()
        {
            if (actualPage < maxPage)
            {
                actualPage += 1;
            }

            await PopulateUpdateDimensionStructureNodesList().ConfigureAwait(false);
        }

        private async Task PopulateUpdateDimensionStructureNodesList()
        {
            int skip = actualPage * _updateDimensionStructureModalListPageSize;

            List<DimensionStructure> list = await DimensionStructureTreeComponentService.GetDimensionStructuresAsync()
               .ConfigureAwait(false);

            _dimensionStructures = list
               .Skip(skip)
               .Take(_updateDimensionStructureModalListPageSize)
               .ToList();
        }

        private async Task ShowFirstPagePagerAction()
        {
            actualPage = 0;
            await PopulateUpdateDimensionStructureNodesList().ConfigureAwait(false);
        }

        private async Task ShowLastPagePagerAction()
        {
            actualPage = maxPage;

            await PopulateUpdateDimensionStructureNodesList().ConfigureAwait(false);
        }

        private async Task ShowUpdateDocumentStructureInTreeModalWindowAsync()
        {
            _updateDocumentStructureInTheTreeModalWindow.Show();
        }

        private async Task UpdateDimensionStructureInTreeAsync(DimensionStructure dimensionStructure)
        {
            Check.IsNotNull(dimensionStructure);
            SourceFormatBuilderService.UpdateNodeNewDimensionStructure = dimensionStructure;
            await SourceFormatBuilderService.ReplaceDimensionStructureInTheTree()
               .ConfigureAwait(false);
            await SourceFormatBuilderService.SetDefaultStateForReplacementOfDimensionStructureInTree()
               .ConfigureAwait(false);
            await HideUpdateDocumentStructureInTreeModalWindowAsync().ConfigureAwait(false);
            await SourceFormatBuilderNotifierService.UpdateSourceFormatBuilder().ConfigureAwait(false);
        }

        private async Task UpdateDocumentStructureInTheTreeAsync(DimensionStructure dimensionStructure)
        {
            Check.IsNotNull(dimensionStructure);
            _dimensionStructures = await DimensionStructureTreeComponentService.GetDimensionStructuresAsync()
               .ConfigureAwait(false);
            _amountOfDimensionStructures = _dimensionStructures.Count;
            SourceFormatBuilderService.UpdateNodeOldDimensionStructure = dimensionStructure;
            await CountAmountOfDimensionStructures().ConfigureAwait(false);
            await PopulateUpdateDimensionStructureNodesList().ConfigureAwait(false);
            await ShowUpdateDocumentStructureInTreeModalWindowAsync().ConfigureAwait(false);
        }

        private async Task UpdateOrAddDimensionStructureHandlerAsync()
        {
            try
            {
                Dimension dimension = _dimensions.FirstOrDefault(p => p.Id == _newDimensionStructure.DimensionId);
                _newDimensionStructure.Dimension = dimension;

                await SourceFormatBuilderService.AddOrUpdateDocumentStructureToTreeAsync(
                        _newDimensionStructure,
                        DimensionStructureParameter.Guid)
                   .ConfigureAwait(false);
                _newDimensionStructure = new DimensionStructure { Guid = Guid.NewGuid() };
                await CloseNewDimensionStructureToTheTreeModalAsync().ConfigureAwait(false);
                await SourceFormatBuilderNotifierService.UpdateSourceFormatBuilder().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.StackTrace} --- {e.Message}");
            }
        }
    }
}