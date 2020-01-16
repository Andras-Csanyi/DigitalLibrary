using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid
{
    public partial class DiLibGridComponent<TData>
    {
        public BSModal AddNewActionButton;

        private List<TData> Data;

        public BSModal DeleteActionButton;

        public BSModal EditActionButton;

        public DiLibModalEdit<TData> ModalEdit;

        private TData NewData;

        [Parameter]
        public DiLibGrid<TData> DiLibGrid { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Data = await DiLibGrid.GetAllAsync().ConfigureAwait(false);
            NewData = (TData) Activator.CreateInstance(typeof(TData));
        }

        public async Task ShowConfirmDeleteModal(TData data)
        {
            await JsRuntime.InvokeAsync<string>("console.log", $"invoked... {data}").ConfigureAwait(false);
            DiLibGrid.ToBeDelete = data;
            DeleteActionButton.Show();
        }

        public async Task ShowEditModal(TData data)
        {
            DiLibGrid.ToBeEdited = data;
            EditActionButton.Show();
            DiLibGrid.GridMode = GridModesEnum.Update;
            StateHasChanged();
        }

        public async Task DeleteActionHandler()
        {
            await JsRuntime.InvokeAsync<string>("console.log", nameof(DeleteActionHandler)).ConfigureAwait(false);
            DiLibGrid.ToBeDelete = default(TData);
            // delete it
            DeleteActionButton.Hide();
        }

        public async Task CancelEditActionHandler()
        {
            await JsRuntime.InvokeAsync<string>("console.log", nameof(CancelEditActionHandler)).ConfigureAwait(false);
            // edit and save it...
            DiLibGrid.ToBeEdited = default(TData);
            EditActionButton.Hide();
        }

        public async Task ShowAddNewModal()
        {
            AddNewActionButton.Show();
        }

        public async Task SaveNewActionHandler()
        {
            await DiLibGrid.AddNewOperation(NewData).ConfigureAwait(false);
        }

        public async Task CancelAddNewActionHandler()
        {
            AddNewActionButton.Hide();
        }
    }
}