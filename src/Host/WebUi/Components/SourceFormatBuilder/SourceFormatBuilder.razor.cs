namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BlazorStrap;

    using DigitalLibrary.MasterData.DomainModel;

    using Microsoft.AspNetCore.Components;

    using Services;

    public partial class SourceFormatBuilder
    {
        [Inject]
        public ISourceFormatBuilderService SourceFormatBuilderService { get; set; }

        [Inject]
        public ISourceFormatSelectorComponentService SourceFormatSelectorComponentService { get; set; }

        private List<SourceFormat> _sourceFormats = new List<SourceFormat>();

        private long _selectedSourceFormatId;

        private BSModal _addNewSourceFormatModal;

        private SourceFormat _newSourceFormat = new SourceFormat();

        private bool _isSourceFormatDropDownlistDisabled;

        private bool _isLoadSourceFormatsButtonDisabled;

        private bool _isNewSourceFormatButtonDisabled;

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

        private async Task OpenAddNewSourceFormatModal()
        {
            _addNewSourceFormatModal.Show();
        }

        private async Task CloseAddNewSourceFormatModal()
        {
            _addNewSourceFormatModal.Hide();
        }

        private async Task AddNewSourceFormatAsync()
        {
            if (_newSourceFormat == null)
            {
                _newSourceFormat = new SourceFormat();
            }

            await OpenAddNewSourceFormatModal().ConfigureAwait(false);
        }

        private async Task CancelAddNewSourceFormatAsync()
        {
            _newSourceFormat = new SourceFormat();
            await CloseAddNewSourceFormatModal().ConfigureAwait(false);
        }

        private async Task SaveNewSourceFormatAsync()
        {
            SourceFormatBuilderService.SourceFormat = _newSourceFormat;
            await SourceFormatBuilderService.Update().ConfigureAwait(false);
            SourceFormatBuilderService.IsSourceFormatDropDownlistDisabled = true;
            SourceFormatBuilderService.IsNewSourceFormatButtonDisabled = true;
            SourceFormatBuilderService.IsLoadSourceFormatsButtonDisabled = true;
            await CloseAddNewSourceFormatModal().ConfigureAwait(false);
        }
    }
}