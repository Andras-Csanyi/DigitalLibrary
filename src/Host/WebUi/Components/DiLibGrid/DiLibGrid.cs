using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions;
using DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Providers;
using Newtonsoft.Json;

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid
{
    public class DiLibGrid<T>
    {
        private readonly DiLibGridColumnProvider _columnProvider;

        private readonly GenericObjectPropertiesProvider _genericObjectPropertiesProvider;

        private T _newOne;

        public HttpClient HttpClient { get; set; }

        public DiLibGridCrudMethodInfo GetAllAsyncMethodInfo { get; set; }

        public DiLibGridCrudMethodInfo DeleteItemMethodInfo { get; set; }

        public DiLibGridCrudMethodInfo UpdateItemMethodInfo { get; set; }

        public DiLibGridCrudMethodInfo AddNewItemMethodInfo { get; set; }

        public List<string> Columns { get; set; }

        public List<string> ColumnsNotToBeDisplayed { get; set; }

        public bool RowEditButton { get; set; }

        public bool RowDeleteButton { get; set; }

        public bool AddButton { get; set; }

        public T ToBeDelete { get; set; }

        public T ToBeEdited { get; set; }

        public GridModesEnum GridMode { get; set; }

        public DiLibGrid()
        {
            _columnProvider = new DiLibGridColumnProvider();
            _genericObjectPropertiesProvider = new GenericObjectPropertiesProvider();
        }

        public void Init()
        {
            Columns = GetColumns<T>();
        }

        private List<string> GetColumns<T>()
        {
            List<string> entityProperties = _columnProvider.GetEntityPropertyNames<T>();
            List<string> entityPropertiesToBeDisplayed = _columnProvider
                .ColumnsToBeDisplayed(entityProperties, ColumnsNotToBeDisplayed);
            List<string> addEditButton = _columnProvider.AddEditButtonIfNeeded(
                entityPropertiesToBeDisplayed, RowEditButton);
            List<string> addDeleteButton = _columnProvider.AddDeleteButtonIfNeeded(
                addEditButton, RowDeleteButton);
            return addDeleteButton;
        }

        public async Task<List<T>> GetAllAsync()
        {
            await HttpClientOperationGuard(HttpOperationsEnum.GetAll).ConfigureAwait(false);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                GetAllAsyncMethodInfo.HttpMethod,
                GetAllAsyncMethodInfo.Url);
            HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage)
                .ConfigureAwait(false);
            httpResponseMessage.EnsureSuccessStatusCode();
            string stringResult = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            List<T> result = JsonConvert.DeserializeObject<List<T>>(stringResult);
            return result;
        }

        private async Task HttpClientOperationGuard(HttpOperationsEnum httpOperationsEnum)
        {
            if (HttpClient == null)
            {
                throw new DiLibGridHttpClientNotInstantiatedException();
            }

            switch (httpOperationsEnum)
            {
                case HttpOperationsEnum.GetAll:
                    if (GetAllAsyncMethodInfo.HttpMethod == null
                        || GetAllAsyncMethodInfo.Url == null)
                    {
                        string msg = $"{nameof(GetAllAsyncMethodInfo.HttpMethod)} is null, or " +
                                     $"{nameof(GetAllAsyncMethodInfo.Url)} is null";
                        throw new DiLibGridHttpOperationGuardException(msg);
                    }

                    break;

                case HttpOperationsEnum.Add:
                    if (AddNewItemMethodInfo.HttpMethod == null
                        || AddNewItemMethodInfo.Url == null)
                    {
                        string msg = $"{nameof(AddNewItemMethodInfo.HttpMethod)} is null, or " +
                                     $"{nameof(AddNewItemMethodInfo.Url)} is null!";
                        throw new DiLibGridHttpOperationGuardException(msg);
                    }

                    break;

                case HttpOperationsEnum.Delete:
                    if (DeleteItemMethodInfo.HttpMethod == null
                        || DeleteItemMethodInfo.Url == null)
                    {
                        string msg = $"{nameof(DeleteItemMethodInfo.HttpMethod)} is null, or " +
                                     $"{nameof(DeleteItemMethodInfo.Url)} is null!";
                        throw new DiLibGridHttpOperationGuardException(msg);
                    }

                    break;

                case HttpOperationsEnum.Modify:
                    if (UpdateItemMethodInfo.HttpMethod == null
                        || UpdateItemMethodInfo.Url == null)
                    {
                        string msg = $"{nameof(UpdateItemMethodInfo.HttpMethod)} is null, or " +
                                     $"{nameof(UpdateItemMethodInfo.Url)} is null!";
                        throw new DiLibGridHttpOperationGuardException(msg);
                    }

                    break;
            }
        }

        public async Task AddNewOperation(T newObject)
        {
            await HttpClientOperationGuard(HttpOperationsEnum.Add).ConfigureAwait(false);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                AddNewItemMethodInfo.HttpMethod,
                AddNewItemMethodInfo.Url);
            string jsonContent = JsonConvert.SerializeObject(newObject);
            StringContent stringContent = new StringContent(jsonContent, Encoding.Unicode);
            httpRequestMessage.Content = stringContent;
            HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage)
                .ConfigureAwait(false);
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task ModifyHttpOperation(T updatedObject)
        {
            await HttpClientOperationGuard(HttpOperationsEnum.Modify).ConfigureAwait(false);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                UpdateItemMethodInfo.HttpMethod,
                UpdateItemMethodInfo.Url);
            string jsonContent = JsonConvert.SerializeObject(updatedObject);
            StringContent stringContent = new StringContent(jsonContent, Encoding.Unicode);
            httpRequestMessage.Content = stringContent;
            HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage)
                .ConfigureAwait(false);
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task DeleteHttpOperation(long id)
        {
            await HttpClientOperationGuard(HttpOperationsEnum.Delete).ConfigureAwait(false);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                DeleteItemMethodInfo.HttpMethod,
                DeleteItemMethodInfo.Url);
            httpRequestMessage.Content = new StringContent(id.ToString(), Encoding.Unicode);
            HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage)
                .ConfigureAwait(false);
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public string GetTableCellValue(string columnName, T data)
        {
            if (string.IsNullOrEmpty(columnName) || string.IsNullOrWhiteSpace(columnName))
            {
                string msg = $"{nameof(columnName)} or {nameof(T)} is null, empty or whitespace!";
                throw new DiLibGridArgumentNullException(msg);
            }

            string result = string.Empty;
            if (data != null)
            {
                PropertyInfo property = data.GetType().GetProperty(columnName);

                if (property != null)
                {
                    result = property.GetValue(data, null).ToString();
                }
            }

            return result;
        }

        public async Task<List<PropertyInfo>> GetPropertiesToBeDisplayed()
        {
            List<PropertyInfo> result = await _genericObjectPropertiesProvider
                .GetPropertyInfos<T>(Columns)
                .ConfigureAwait(false);
            return result;
        }

        public void DeleteItem<TData>(TData item)
        {
            throw new NotImplementedException();
        }

        public string ShowDefaultInfoAboutGenericObject(T obj)
        {
            if (obj != null)
            {
                return $"Object type: {_genericObjectPropertiesProvider.GetType<T>()}, " +
                       $"id: {_genericObjectPropertiesProvider.GetPropertyValueOfGenericObject("Id", obj)}, " +
                       $"name: {_genericObjectPropertiesProvider.GetPropertyValueOfGenericObject("Name", obj)}";
            }

            return null;
        }
    }
}