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

    using Services;

    using Utils.Guards;

    public partial class DimensionStructureTree
    {
        [Parameter]
        public DimensionStructure DimensionStructureParameter { get; set; }

        [Parameter]
        public long ParentDimensionStructureIdParameter { get; set; }

        [Inject]
        public ISourceFormatBuilderService SourceFormatBuilderService { get; set; }

        [Inject]
        public IDimensionStructureTreeComponentService DimensionStructureTreeComponentService { get; set; }

        private BSModal _deleteDocumentStructureBsModalWindow;

        private long _documentStructureToBeDeletedFromTree = 0;

        private long _selectedForEditDimensionStructureId = 0;

        private int _updateDimensionStructureModalListPageSize = 10;

        private int actualPage = 0;

        private int maxPage = 0;

        private int _amountOfDimensionStructures = 0;

        private BSModal _updateDocumentStructureInTheTreeModalWindow;

        private List<DimensionStructure> _dimensionStructures = new List<DimensionStructure>();

        protected override async Task OnInitializedAsync()
        {
        }

        public async Task DeleteDocumentStructureFromTreeAsync(long documentStructureId)
        {
            _documentStructureToBeDeletedFromTree = documentStructureId;
            await OpenDeleteDocumentStructureFromTreeConfirmModalAsync().ConfigureAwait(false);
        }

        private async Task OpenDeleteDocumentStructureFromTreeConfirmModalAsync()
        {
            _deleteDocumentStructureBsModalWindow.Show();
        }

        private async Task CloseDeleteDocumentStructureFromTreeConfirmModalAsync()
        {
            _deleteDocumentStructureBsModalWindow.Hide();
        }

        public async Task AddDocumentStructureToTreeAsync(
            long documentStructureId,
            long parentDimensionStructureId)
        {
            await SourceFormatBuilderService.AddDocumentStructureToTreeAsync(
                    documentStructureId,
                    parentDimensionStructureId)
               .ConfigureAwait(false);
        }

        private async Task DeleteDocumentStructureConfirmedAsync()
        {
            try
            {
                if (_documentStructureToBeDeletedFromTree == 0)
                {
                    string msg = $"{nameof(_documentStructureToBeDeletedFromTree)} is " +
                                 $"{_documentStructureToBeDeletedFromTree}";
                    throw new ArgumentNullException(msg);
                }

                await SourceFormatBuilderService
                   .DeleteDocumentStructureFromTreeAsync(_documentStructureToBeDeletedFromTree)
                   .ConfigureAwait(false);
                _documentStructureToBeDeletedFromTree = 0;
                await CloseDeleteDocumentStructureFromTreeConfirmModalAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error happened while delete...", e);
            }
        }

        private async Task CancelDeleteDocumentStructureConfirmedAsync()
        {
            _documentStructureToBeDeletedFromTree = 0;
            await CloseDeleteDocumentStructureFromTreeConfirmModalAsync().ConfigureAwait(false);
        }

        private async Task UpdateDocumentStructureInTheTreeAsync(long dimensionStructureId)
        {
            Check.AreNotEqual(dimensionStructureId, 0);
            _dimensionStructures = await DimensionStructureTreeComponentService.GetDimensionStructuresAsync()
               .ConfigureAwait(false);
            _amountOfDimensionStructures = _dimensionStructures.Count;
            _selectedForEditDimensionStructureId = dimensionStructureId;
            await CountAmountOfDimensionStructures().ConfigureAwait(false);
            await PopulateUpdateDimensionStructureNodesList().ConfigureAwait(false);
            await ShowUpdateDocumentStructureInTreeModalWindowAsync().ConfigureAwait(false);
        }

        private async Task CountAmountOfDimensionStructures()
        {
            maxPage = _amountOfDimensionStructures / _updateDimensionStructureModalListPageSize;
        }

        private async Task ShowUpdateDocumentStructureInTreeModalWindowAsync()
        {
            _updateDocumentStructureInTheTreeModalWindow.Show();
        }

        private async Task HideUpdateDocumentStructureInTreeModalWindowAsync()
        {
            _updateDocumentStructureInTheTreeModalWindow.Hide();
        }

        private async Task CancelDocumentStructureUpdateInTreeModalWindowAsync()
        {
            _selectedForEditDimensionStructureId = 0;
            await HideUpdateDocumentStructureInTreeModalWindowAsync().ConfigureAwait(false);
        }

        private async Task SelectDimensionStructureForTree(long dimensionStructureId)
        {
            Check.AreNotEqual(dimensionStructureId, 0);
            await SourceFormatBuilderService.ReplaceDimensionStructureInTheTree(
                    _selectedForEditDimensionStructureId,
                    dimensionStructureId)
               .ConfigureAwait(false);
            await HideUpdateDocumentStructureInTreeModalWindowAsync().ConfigureAwait(false);
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

        private async Task ShowLastPagePagerAction()
        {
            actualPage = maxPage;

            await PopulateUpdateDimensionStructureNodesList().ConfigureAwait(false);
        }
    }
}