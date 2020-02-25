namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System;
    using System.Threading.Tasks;

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

        protected override async Task OnInitializedAsync()
        {
        }

        public async Task DeleteDocumentStructureFromTreeAsync(long documentStructureId)
        {
            await SourceFormatBuilderService.DeleteDocumentStructureFromTreeAsync(documentStructureId)
               .ConfigureAwait(false);
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
    }
}