namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Title
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    using Api.Api;

    using DomainModel.Entities;

    using Exceptions;

    using Newtonsoft.Json;

    public class TitleApiWebClient : ITitleApiWebClient
    {
        private readonly HttpClient _httpClient;

        public TitleApiWebClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new TitleApiWebClientArgumentNullException(nameof(httpClient));
        }

        public async Task<Title> AddAsync(Title title)
        {
            try
            {
                if (title == null)
                {
                    throw new TitleApiWebClientArgumentNullException(nameof(title));
                }

                string url = $"{TeamManagerWebApi.TitleApi.TitleBase}/{TeamManagerWebApi.TitleApi.Add}";
                HttpRequestMessage requestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

                string json = JsonConvert.SerializeObject(title);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                requestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(requestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string responseStringContent = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                Title result = JsonConvert.DeserializeObject<Title>(responseStringContent);
                return result;
            }
            catch (Exception e)
            {
                throw new TitleApiWebClientAddAsyncOperationException(e.Message, e);
            }
        }

        public async Task DeleteAsync(Title title)
        {
            try
            {
                if (title == null)
                {
                    throw new TitleApiWebClientArgumentNullException(nameof(title));
                }

                string url = $"{TeamManagerWebApi.TitleApi.TitleBase}/{TeamManagerWebApi.TitleApi.Delete}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Delete,
                    url);

                string json = JsonConvert.SerializeObject(title);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new TitleApiWebClientDeleteAsyncOperationException(e.Message, e);
            }
        }

        public async Task<Title> FindAsync(Title title)
        {
            try
            {
                if (title == null)
                {
                    throw new TitleApiWebClientArgumentNullException(nameof(title));
                }

                string url = $"{TeamManagerWebApi.TitleApi.TitleBase}/{TeamManagerWebApi.TitleApi.Find}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

                string jsonString = JsonConvert.SerializeObject(title);
                StringContent stringContent = new StringContent(jsonString, Encoding.UTF8);
                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                Title result = JsonConvert.DeserializeObject<Title>(resultString);
                return result;
            }
            catch (Exception e)
            {
                throw new TitleApiWebClientFindAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<Title>> GetAllAsync()
        {
            try
            {
                string url = $"{TeamManagerWebApi.TitleApi.TitleBase}/{TeamManagerWebApi.TitleApi.GetAll}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                    url);

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                List<Title> result = JsonConvert.DeserializeObject<List<Title>>(responseString);
                return result;
            }
            catch (Exception e)
            {
                throw new TitleApiWebClientGetAllAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<Title>> GetAllActiveAsync()
        {
            try
            {
                string url = $"{TeamManagerWebApi.TitleApi.TitleBase}/{TeamManagerWebApi.TitleApi.GetAllActive}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                    url);

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                List<Title> result = JsonConvert.DeserializeObject<List<Title>>(responseString);
                return result;
            }
            catch (Exception e)
            {
                throw new TitleApiWebClientGetAllActiveAsyncOperationException(e.Message, e);
            }
        }

        public async Task<Title> ModifyAsync(Title title)
        {
            try
            {
                if (title == null)
                {
                    throw new TitleApiWebClientArgumentNullException(nameof(title));
                }

                string url = $"{TeamManagerWebApi.TitleApi.TitleBase}/{TeamManagerWebApi.TitleApi.Modify}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Put,
                    url);

                string json = JsonConvert.SerializeObject(title);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                Title result = JsonConvert.DeserializeObject<Title>(resultString);
                return result;
            }
            catch (Exception e)
            {
                throw new TitleApiWebClientModifyAsyncOperationException(e.Message, e);
            }
        }
    }
}