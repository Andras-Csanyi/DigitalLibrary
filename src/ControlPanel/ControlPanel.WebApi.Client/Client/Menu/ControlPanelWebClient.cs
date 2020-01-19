namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    using Api;

    using DomainModel.Entities;

    using Exceptions;

    using Newtonsoft.Json;

    public class ControlPanelWebClient : IControlPanelWebClient
    {
        private HttpClient _httpClient;

        public ControlPanelWebClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ControlPanelWebApiClientArgumentNullException();
        }

        public async Task<List<DomainModel.Entities.Menu>> GetAllMenusAsync()
        {
            try
            {
                string url = $"{ControlPanelWebApi.Menu.Base}/{ControlPanelWebApi.Menu.GetAll}";
                HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(url)
                   .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string stringContent = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                List<DomainModel.Entities.Menu> result =
                    JsonConvert.DeserializeObject<List<DomainModel.Entities.Menu>>(stringContent);

                return result;
            }
            catch (Exception e)
            {
                throw new ControlPanelWebApiClientGetAllMenusAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<DomainModel.Entities.Menu>> GetAllActiveMenusAsync()
        {
            try
            {
                string url = $"{ControlPanelWebApi.Menu.Base}/{ControlPanelWebApi.Menu.GetAllActive}";
                HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(
                        url)
                   .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string stringContent = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                List<DomainModel.Entities.Menu> result =
                    JsonConvert.DeserializeObject<List<DomainModel.Entities.Menu>>(stringContent);

                return result;
            }
            catch (Exception e)
            {
                throw new ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException(e.Message, e);
            }
        }

        public async Task<DomainModel.Entities.Menu> FindMenuAsync(DomainModel.Entities.Menu menu)
        {
            try
            {
                if (menu == null)
                {
                    string msg = $"Null input: {nameof(ControlPanelWebClient)}.{nameof(FindMenuAsync)}";
                    throw new ControlPanelWebApiClientArgumentNullException(msg);
                }

                string url = $"{ControlPanelWebApi.Menu.Base}/{ControlPanelWebApi.Menu.Find}";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);

                string json = JsonConvert.SerializeObject(menu);
                StringContent stringContent = new StringContent(json, Encoding.UTF8);
                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                request.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request)
                   .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                   .ConfigureAwait(false);
                DomainModel.Entities.Menu result =
                    JsonConvert.DeserializeObject<DomainModel.Entities.Menu>(resultString);

                return result;
            }
            catch (Exception e)
            {
                throw new ControlPanelWebApiClientFindMenuAsyncOperationException(e.Message, e);
            }
        }

        public async Task<DomainModel.Entities.Menu> AddMenuAsync(DomainModel.Entities.Menu menu)
        {
            try
            {
                if (menu == null)
                {
                    string msg = $"Null input: {nameof(ControlPanelWebClient)}.{nameof(AddMenuAsync)}";
                    throw new ControlPanelWebApiClientArgumentNullException(msg);
                }

                string url = $"{ControlPanelWebApi.Menu.Base}/{ControlPanelWebApi.Menu.Add}";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);

                string json = JsonConvert.SerializeObject(menu);
                StringContent stringContent = new StringContent(json, Encoding.UTF8);
                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                request.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request)
                   .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                   .ConfigureAwait(false);
                DomainModel.Entities.Menu result =
                    JsonConvert.DeserializeObject<DomainModel.Entities.Menu>(resultString);

                return result;
            }
            catch (Exception e)
            {
                throw new ControlPanelWebApiClientAddMenuAsyncOperationException(e.Message, e);
            }
        }

        public async Task<DomainModel.Entities.Menu> ModifyMenuAsync(DomainModel.Entities.Menu menu)
        {
            try
            {
                if (menu == null)
                {
                    string msg = $"Null input: {nameof(ControlPanelWebClient)}.{nameof(ModifyMenuAsync)}";
                    throw new ControlPanelWebApiClientArgumentNullException(msg);
                }

                string url = $"{ControlPanelWebApi.Menu.Base}/{ControlPanelWebApi.Menu.Modify}";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url);

                string json = JsonConvert.SerializeObject(menu);
                StringContent stringContent = new StringContent(json, Encoding.UTF8);
                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                request.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request)
                   .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                   .ConfigureAwait(false);
                DomainModel.Entities.Menu result =
                    JsonConvert.DeserializeObject<DomainModel.Entities.Menu>(resultString);

                return result;
            }
            catch (Exception e)
            {
                throw new ControlPanelWebApiClientModifyMenuAsyncOperationException(e.Message, e);
            }
        }

        public async Task DeleteMenuAsync(DomainModel.Entities.Menu menu)
        {
            try
            {
                if (menu == null)
                {
                    string msg = $"Null input: {nameof(ControlPanelWebClient)}.{nameof(DeleteMenuAsync)}";
                    throw new ControlPanelWebApiClientArgumentNullException(msg);
                }

                string url = $"{ControlPanelWebApi.Menu.Base}/{ControlPanelWebApi.Menu.Delete}";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete,
                    url);

                string json = JsonConvert.SerializeObject(menu);
                StringContent stringContent = new StringContent(json, Encoding.UTF8);
                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                request.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request)
                   .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new ControlPanelWebApiClientDeleteMenuAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<Module>> GetAllModulesAsync()
        {
            try
            {
                string url = $"{ControlPanelWebApi.Module.Base}/{ControlPanelWebApi.Module.GetAll}";
                HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(url)
                   .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string stringContent = await httpResponseMessage.Content.ReadAsStringAsync()
                   .ConfigureAwait(false);
                List<Module> result = JsonConvert.DeserializeObject<List<Module>>(stringContent);

                return result;
            }
            catch (Exception e)
            {
                throw new ControlPanelWebApiClientGetAllModulesAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<Module>> GetAllActiveModulesAsync()
        {
            try
            {
                string url = $"{ControlPanelWebApi.Module.Base}/{ControlPanelWebApi.Module.GetAllActive}";
                HttpResponseMessage httpResponseMessage = await _httpClient
                   .GetAsync(url)
                   .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string stringContent = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                List<Module> result = JsonConvert.DeserializeObject<List<Module>>(stringContent);

                return result;
            }
            catch (Exception e)
            {
                throw new ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException(e.Message, e);
            }
        }

        public async Task<Module> FindModuleAsync(Module module)
        {
            try
            {
                if (module == null)
                {
                    string msg = $"Null input: {nameof(ControlPanelWebClient)}.{nameof(FindModuleAsync)}";
                    throw new ControlPanelWebApiClientArgumentNullException(msg);
                }

                string url = $"{ControlPanelWebApi.Module.Base}/{ControlPanelWebApi.Module.Find}";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,
                    url);

                string json = JsonConvert.SerializeObject(module);
                StringContent stringContent = new StringContent(json, Encoding.UTF8);
                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                request.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request)
                   .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                   .ConfigureAwait(false);
                Module result = JsonConvert.DeserializeObject<Module>(resultString);

                return result;
            }
            catch (Exception e)
            {
                throw new ControlPanelWebApiClientFindModuleAsyncOperationException(e.Message, e);
            }
        }

        public async Task<Module> AddModuleAsync(Module module)
        {
            try
            {
                if (module == null)
                {
                    string msg = $"Null input: {nameof(ControlPanelWebClient)}.{nameof(AddModuleAsync)}";
                    throw new ControlPanelWebApiClientArgumentNullException(msg);
                }

                string url = $"{ControlPanelWebApi.Module.Base}/{ControlPanelWebApi.Module.Add}";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,
                    url);

                string json = JsonConvert.SerializeObject(module);
                StringContent stringContent = new StringContent(json, Encoding.UTF8);

                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request)
                   .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                   .ConfigureAwait(false);

                Module result = JsonConvert.DeserializeObject<Module>(resultString);

                return result;
            }
            catch (Exception e)
            {
                throw new ControlPanelWebApiClientAddModuleAsyncOperationException(e.Message, e);
            }
        }

        public async Task<Module> ModifyModuleAsync(Module module)
        {
            try
            {
                if (module == null)
                {
                    string msg = $"Null input: {nameof(ControlPanelWebClient)}.{nameof(ModifyModuleAsync)}";
                    throw new ControlPanelWebApiClientArgumentNullException(msg);
                }

                string url = $"{ControlPanelWebApi.Module.Base}/{ControlPanelWebApi.Module.Modify}";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url);

                string json = JsonConvert.SerializeObject(module);
                StringContent stringContent = new StringContent(json, Encoding.UTF8);

                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request)
                   .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                   .ConfigureAwait(false);
                Module result = JsonConvert.DeserializeObject<Module>(resultString);

                return result;
            }
            catch (Exception e)
            {
                throw new ControlPanelWebApiClientModifyModuleAsyncOperationException(e.Message, e);
            }
        }

        public async Task DeleteModuleAsync(Module module)
        {
            try
            {
                if (module == null)
                {
                    string msg = $"Null input: {nameof(ControlPanelWebClient)}.{nameof(DeleteModuleAsync)}";
                    throw new ControlPanelWebApiClientArgumentNullException(msg);
                }

                string url = $"{ControlPanelWebApi.Module.Base}/{ControlPanelWebApi.Module.Delete}";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);

                string json = JsonConvert.SerializeObject(module);
                StringContent stringContent = new StringContent(json, Encoding.UTF8);

                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request)
                   .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new ControlPanelWebApiClientDeleteModuleAsyncOperationException(e.Message, e);
            }
        }
    }
}