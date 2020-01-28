namespace DigitalLibrary.Ui.WebUi.Components.DocumentBuilder
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Microsoft.AspNetCore.Components;

    public partial class DocumentDisplay
    {
        [CascadingParameter(Name = "_selectedSourceFormatId")]
        public long _selectedSourceFormatId { get; set; }

        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        private SourceFormat selectedSourceFormat = new SourceFormat();

        protected override async Task OnInitializedAsync()
        {
        }
    }
}