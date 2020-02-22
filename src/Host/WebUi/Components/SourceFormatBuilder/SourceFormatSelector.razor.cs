namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using Microsoft.AspNetCore.Components;

    using Notifiers;

    using Services;

    public partial class SourceFormatSelector
    {
        [Inject]
        public ISourceFormatBuilderService SourceFormatBuilderService { get; set; }

        [Inject]
        public ISourceFormatSelectorComponentService SourceFormatSelectorComponentService { get; set; }

        private List<SourceFormat> _sourceFormats = new List<SourceFormat>();

        private long _selectedSourceFormatId;

        protected override async Task OnInitializedAsync()
        {
            await PopulateSourceFormats().ConfigureAwait(false);
            await AddNulloAsFirstElemToSourceFormatList().ConfigureAwait(false);
        }

        private async Task AddNulloAsFirstElemToSourceFormatList()
        {
            SourceFormat nullo = new SourceFormat
            {
                Id = 0,
                Name = "--Select One--",
            };
            _sourceFormats.Insert(0, nullo);
        }

        private async Task PopulateSourceFormats()
        {
            _sourceFormats = await SourceFormatSelectorComponentService.GetSourceFormatsAsync().ConfigureAwait(false);
        }

        private async Task NotifyDocumentDisplay()
        {
            await SourceFormatBuilderService.OnUpdate(_selectedSourceFormatId).ConfigureAwait(false);
        }
    }
}