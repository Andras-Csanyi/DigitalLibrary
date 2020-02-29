namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System;
    using System.Threading.Tasks;

    using BlazorStrap;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Microsoft.AspNetCore.Components;

    using Services;

    public partial class DimensionStructureTree
    {
        [Parameter]
        public DimensionStructure DimensionStructureParameter { get; set; }

        [Parameter]
        public long ParentDimensionStructureIdParameter { get; set; }

        [Inject]
        public ISourceFormatBuilderService SourceFormatBuilderService { get; set; }

        private BSModal _deleteDocumentStructureBsModalWindow;

        private long DocumentStructureToBeDeletedFromTree = 0;

        protected override async Task OnInitializedAsync()
        {
        }

        public async Task DeleteDocumentStructureFromTreeAsync(long documentStructureId)
        {
            DocumentStructureToBeDeletedFromTree = documentStructureId;
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
                if (DocumentStructureToBeDeletedFromTree == 0)
                {
                    string msg = $"{nameof(DocumentStructureToBeDeletedFromTree)} is " +
                        $"{DocumentStructureToBeDeletedFromTree}";
                    throw new ArgumentNullException(msg);
                }

                await SourceFormatBuilderService
                   .DeleteDocumentStructureFromTreeAsync(DocumentStructureToBeDeletedFromTree)
                   .ConfigureAwait(false);
                DocumentStructureToBeDeletedFromTree = 0;
                await CloseDeleteDocumentStructureFromTreeConfirmModalAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error happened while delete...", e);
            }
        }

        private async Task CancelDeleteDocumentStructureConfirmedAsync()
        {
            DocumentStructureToBeDeletedFromTree = 0;
            await CloseDeleteDocumentStructureFromTreeConfirmModalAsync().ConfigureAwait(false);
        }
    }
}