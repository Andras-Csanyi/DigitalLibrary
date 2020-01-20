using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

using BlazorStrap;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using Newtonsoft.Json;

namespace DigitalLibrary.Ui.WebUi.Components.ExactGrid
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;

    public partial class ExactGrid
    {
        private List<DimensionStructure> _dimensionStructures;

        private DimensionStructure _editedItem = new DimensionStructure();

        private HttpClient _httpClient;

        public List<string> Columns;

        private BSModal EditModalWindow;

        [Inject]
        public IHttpClientFactory HttpClientFactory { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        public async Task ShowEditModal(DimensionStructure dimensionStructure)
        {
            _editedItem = dimensionStructure;
            EditModalWindow.Show();
        }

        public async Task HandleValidSubmit()
        {
            await JsRuntime.InvokeAsync<string>("console.log", _editedItem);
            EditModalWindow.Hide();
        }

        protected override async Task OnInitializedAsync()
        {
            Columns = await GetColumnNames().ConfigureAwait(false);
            _httpClient = HttpClientFactory.CreateClient("httpClient");
            string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                         $"{MasterDataApi.DimensionStructure.V1.GetSourceFormats}";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get, url);
            HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
               .ConfigureAwait(false);
            httpResponseMessage.EnsureSuccessStatusCode();
            string resultString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            _dimensionStructures = JsonConvert.DeserializeObject<List<DimensionStructure>>(resultString);
        }

        private async Task<List<string>> GetColumnNames()
        {
            Type dimensionStructuretype = typeof(DimensionStructure);
            List<string> columnNames = new List<PropertyInfo>(dimensionStructuretype.GetProperties())
               .Select(n => n.Name)
               .ToList();
            return columnNames;
        }
    }
}