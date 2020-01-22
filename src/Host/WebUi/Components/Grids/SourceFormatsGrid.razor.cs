namespace DigitalLibrary.Ui.WebUi.Components.Grids
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BlazorStrap;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public partial class SourceFormatsGrid
    {
        private BSModal _addNewModal;

        private SourceFormat _deleteItem = new SourceFormat();

        private BSModal _deleteModal;

        private SourceFormat _editedItem = new SourceFormat();

        private BSModal _editModal;

        private SourceFormat _newItem = new SourceFormat();

        private List<SourceFormat> Data;

        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                Data = await MasterDataHttpClient.GetSourceFormatsAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task ShowEditModal(SourceFormat sourceFormat)
        {
            _editedItem = sourceFormat;
            _editModal.Show();
        }

        private async Task ShowDeleteModal(SourceFormat sourceFormat)
        {
            _deleteItem = sourceFormat;
            _deleteModal.Show();
        }

        private async Task ShowAddNewModal()
        {
            _addNewModal.Show();
        }

        private async Task CancelEditHandler()
        {
            _editedItem = new SourceFormat();
            _editModal.Hide();
        }

        private async Task CancelAddHandler()
        {
            _newItem = new SourceFormat();
            _addNewModal.Hide();
        }

        private async Task DeleteHandler()
        {
            Task deleteTask = Task.Run(async () => await MasterDataHttpClient.DeleteSourceFormatAsync(
                    _deleteItem)
               .ConfigureAwait(false));
            deleteTask.GetAwaiter().GetResult();
            GetAllData();
            StateHasChanged();
            _deleteModal.Hide();
        }

        private async Task CancelDeleteHandler()
        {
            _deleteItem = new SourceFormat();
            _deleteModal.Hide();
        }

        private void OnValidEditSubmit()
        {
            try
            {
                Task<SourceFormat> modifyTask = Task.Run(async () => await MasterDataHttpClient
                   .UpdateSourceFormatAsync(_editedItem)
                   .ConfigureAwait(false));
                modifyTask.GetAwaiter().GetResult();
                MasterDataHttpClient.UpdateSourceFormatAsync(_editedItem);
                GetAllData();
                StateHasChanged();
                _editedItem = new SourceFormat();
                _editModal.Hide();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void OnValidAddSubmit()
        {
            try
            {
                Task<SourceFormat> addTask = Task.Run(async () => await MasterDataHttpClient
                   .AddSourceFormatAsync(_newItem)
                   .ConfigureAwait(false));
                addTask.GetAwaiter().GetResult();
                GetAllData();
                StateHasChanged();
                _newItem = new SourceFormat();
                _addNewModal.Hide();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void GetAllData()
        {
            Task<List<SourceFormat>> getTask = Task.Run(async () => await MasterDataHttpClient
               .GetSourceFormatsAsync()
               .ConfigureAwait(false));
            Data = getTask.GetAwaiter().GetResult();
        }
    }
}