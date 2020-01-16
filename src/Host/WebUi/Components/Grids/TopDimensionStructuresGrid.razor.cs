using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorStrap;
using DigitalLibrary.IaC.MasterData.DomainModel.DomainModel;
using DigitalLibrary.IaC.MasterData.WebApi.Client.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DigitalLibrary.Ui.WebUi.Components.Grids
{
    public partial class TopDimensionStructuresGrid
    {
        private BSModal _addNewModal;

        private DimensionStructure _deleteItem = new DimensionStructure();

        private BSModal _deleteModal;

        private DimensionStructure _editedItem = new DimensionStructure();

        private BSModal _editModal;

        private DimensionStructure _newItem = new DimensionStructure();

        private List<DimensionStructure> Data;

        [Inject]
        public IMasterDataHttpClient MasterDataHttpClient { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                Data = await MasterDataHttpClient.GetTopDimensionStructuresAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                await JsRuntime.InvokeAsync<string>("console.log", e).ConfigureAwait(false);
            }
        }

        private async Task ShowEditModal(DimensionStructure dimensionStructure)
        {
            _editedItem = dimensionStructure;
            _editModal.Show();
        }

        private async Task ShowDeleteModal(DimensionStructure dimensionStructure)
        {
            _deleteItem = dimensionStructure;
            _deleteModal.Show();
        }

        private async Task ShowAddNewModal()
        {
            _addNewModal.Show();
        }

        private async Task CancelEditHandler()
        {
            _editedItem = new DimensionStructure();
            _editModal.Hide();
        }

        private async Task CancelAddHandler()
        {
            _newItem = new DimensionStructure();
            _addNewModal.Hide();
        }

        private async Task DeleteHandler()
        {
            Task deleteTask = Task.Run(async () => await MasterDataHttpClient.DeleteTopDimensionStructureAsync(
                    _deleteItem)
                .ConfigureAwait(false));
            deleteTask.GetAwaiter().GetResult();
            GetAllData();
            StateHasChanged();
            _deleteModal.Hide();
        }

        private async Task CancelDeleteHandler()
        {
            _deleteItem = new DimensionStructure();
            _deleteModal.Hide();
        }

        private void OnValidEditSubmit()
        {
            try
            {
                Task<DimensionStructure> modifyTask = Task.Run(async () => await MasterDataHttpClient
                    .ModifyTopDimensionStructureAsync(_editedItem)
                    .ConfigureAwait(false));
                modifyTask.GetAwaiter().GetResult();
                MasterDataHttpClient.ModifyTopDimensionStructureAsync(_editedItem);
                GetAllData();
                StateHasChanged();
                _editedItem = new DimensionStructure();
                _editModal.Hide();
            }
            catch (Exception e)
            {
                JsRuntime.InvokeAsync<string>("console.log", e);
            }
        }

        private void OnValidAddSubmit()
        {
            try
            {
                Task<DimensionStructure> addTask = Task.Run(async () => await MasterDataHttpClient
                    .AddTopDimensionStructureAsync(_newItem)
                    .ConfigureAwait(false));
                addTask.GetAwaiter().GetResult();
                GetAllData();
                StateHasChanged();
                _newItem = new DimensionStructure();
                _addNewModal.Hide();
            }
            catch (Exception e)
            {
                JsRuntime.InvokeAsync<string>("console.log", e);
            }
        }

        private void GetAllData()
        {
            Task<List<DimensionStructure>> getTask = Task.Run(async () => await MasterDataHttpClient
                .GetTopDimensionStructuresAsync()
                .ConfigureAwait(false));
            Data = getTask.GetAwaiter().GetResult();
        }
    }
}