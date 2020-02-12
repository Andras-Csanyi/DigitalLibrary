namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Microsoft.AspNetCore.Components;

    using Services;

    public partial class DimensionStructureTree
    {
        [Parameter]
        public long DimensionStructureId { get; set; }

        [Inject]
        public IDimensionStructureTreeComponentService DimensionStructureTreeComponentService { get; set; }

        [Inject]
        public ISourceFormatBuilderService SourceFormatBuilderService { get; set; }

        private DimensionStructure _dimensionStructure = new DimensionStructure();

        protected override async Task OnInitializedAsync()
        {
            _dimensionStructure = await SourceFormatBuilderService
               .GetDimensionStructureFromTreeByIdAsync(DimensionStructureId)
               .ConfigureAwait(false);
        }

        public async Task DeleteDocumentStructureFromTreeAsync(long documentStructureId)
        {
            await SourceFormatBuilderService.DeleteDocumentStructureFromTreeAsync(documentStructureId)
               .ConfigureAwait(false);
        }
    }
}