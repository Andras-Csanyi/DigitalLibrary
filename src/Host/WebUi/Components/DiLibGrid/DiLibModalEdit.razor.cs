using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid
{
    public partial class DiLibModalEdit<T>
    {
        private T _editedItem;

        private List<PropertyInfo> _propertyInfosForDisplay;

        [CascadingParameter]
        public DiLibGrid<T> DiLibGrid { get; set; }

        [CascadingParameter]
        public DiLibGridComponent<T> DiLibGridComponent { get; set; }

        [Parameter]
        public T TData { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _editedItem = Activator.CreateInstance<T>();
            _propertyInfosForDisplay = await DiLibGrid.GetPropertiesToBeDisplayed().ConfigureAwait(false);
            await JsRuntime.InvokeAsync<T>("console.log", _editedItem).ConfigureAwait(false);
        }

        private void Submit()
        {
            JsRuntime.InvokeAsync<T>("console.log", _editedItem);
            DiLibGridComponent.EditActionButton.Hide();
        }

        private string BindBuilder(T variableName, string propertyName)
        {
            return $"{nameof(_editedItem)}.{propertyName}";
        }
    }
}