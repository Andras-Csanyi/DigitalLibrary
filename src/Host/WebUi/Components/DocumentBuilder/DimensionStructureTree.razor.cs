namespace DigitalLibrary.Ui.WebUi.Components.DocumentBuilder
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Microsoft.AspNetCore.Components;

    public partial class DimensionStructureTree
    {
        [Parameter]
        public long DimensionStructureId { get; set; }

        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        private DimensionStructure _dimensionStructure = new DimensionStructure();

        protected override async Task OnInitializedAsync()
        {
            DimensionStructure queryDimensionStructure = new DimensionStructure
            {
                Id = DimensionStructureId,
            };
            _dimensionStructure = await MasterDataHttpClient.GetDimensionStructureById(queryDimensionStructure)
               .ConfigureAwait(false);
        }
    }
}