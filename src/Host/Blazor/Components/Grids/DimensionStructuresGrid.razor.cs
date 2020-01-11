namespace Blazor.Components.Grids
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using DigitalLibrary.IaC.MasterData.DomainModel.DomainModel;
    using DigitalLibrary.IaC.MasterData.WebApi.Client.Client;

    using Microsoft.AspNetCore.Components;

    public partial class DimensionStructuresGrid
    {
        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        private List<DimensionStructure> Data = new List<DimensionStructure>();

        protected override async Task OnInitializedAsync()
        {
            Data = await MasterDataHttpClient.GetDimensionStructuresAsync().ConfigureAwait(false);
        }
    }
}