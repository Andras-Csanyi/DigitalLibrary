namespace DigitalLibrary.Ui.WebUi.Components.Grids
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Microsoft.AspNetCore.Components;

    public partial class DimensionGrid
    {
        [Inject]
        public MasterDataHttpClient MasterDataHttpClient { get; set; }

        public List<Dimension> Dimensions { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Dimensions = await MasterDataHttpClient.GetDimensionsAsync().ConfigureAwait(false);
        }
    }
}