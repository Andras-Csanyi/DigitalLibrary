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

        protected override async Task OnInitializedAsync()
        {
        }

        public async Task DeleteDocumentStructureFromTreeAsync(long documentStructureId)
        {
            throw new NotImplementedException();
        }
    }
}