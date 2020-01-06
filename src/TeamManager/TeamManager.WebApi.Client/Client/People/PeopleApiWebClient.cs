namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.People
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

    public class PeopleApiWebClient : IPeopleApiWebClient
    {
        private readonly HttpClient _httpClient;

        public PeopleApiWebClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new PeopleApiWebClientArgumentNullException(nameof(httpClient));
        }

        public async Task<People> AddAsync(People people)
        {
            try
            {
                if (people == null)
                {
                    throw new PeopleApiWebClientArgumentNullException(nameof(people));
                }

                string url = $"{TeamManagerWebApi.PeopleApi.PeopleBase}/{TeamManagerWebApi.PeopleApi.Add}";
                HttpRequestMessage requestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

                string json = JsonConvert.SerializeObject(people);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                requestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(requestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string responseStringContent = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                People result = JsonConvert.DeserializeObject<People>(responseStringContent);
                return result;
            }
            catch (Exception e)
            {
                throw new PeopleApiWebClientAddAsyncOperationException(e.Message, e);
            }
        }

        public async Task DeleteAsync(People people)
        {
            try
            {
                if (people == null)
                {
                    throw new PeopleApiWebClientArgumentNullException(nameof(people));
                }

                string url = $"{TeamManagerWebApi.PeopleApi.PeopleBase}/{TeamManagerWebApi.PeopleApi.Delete}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Delete,
                    url);

                string json = JsonConvert.SerializeObject(people);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new PeopleApiWebClientDeleteAsyncOperationException(e.Message, e);
            }
        }

        public async Task<People> FindAsync(People people)
        {
            try
            {
                if (people == null)
                {
                    throw new PeopleApiWebClientArgumentNullException(nameof(people));
                }

                string url = $"{TeamManagerWebApi.PeopleApi.PeopleBase}/{TeamManagerWebApi.PeopleApi.Find}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

                string jsonString = JsonConvert.SerializeObject(people);
                StringContent stringContent = new StringContent(jsonString, Encoding.UTF8);
                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                People result = JsonConvert.DeserializeObject<People>(resultString);
                return result;
            }
            catch (Exception e)
            {
                throw new PeopleApiWebClientFindAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<People>> GetAllAsync()
        {
            try
            {
                string url = $"{TeamManagerWebApi.PeopleApi.PeopleBase}/{TeamManagerWebApi.PeopleApi.GetAll}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                    url);

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                List<People> result = JsonConvert.DeserializeObject<List<People>>(responseString);
                return result;
            }
            catch (Exception e)
            {
                throw new PeopleApiWebClientGetAllAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<People>> GetAllActiveAsync()
        {
            try
            {
                string url = $"{TeamManagerWebApi.PeopleApi.PeopleBase}/{TeamManagerWebApi.PeopleApi.GetAllActive}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                    TeamManagerWebApi.PeopleApi.GetAllActive);

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                List<People> result = JsonConvert.DeserializeObject<List<People>>(responseString);
                return result;
            }
            catch (Exception e)
            {
                throw new PeopleApiWebClientGetAllActiveAsyncOperationException(e.Message, e);
            }
        }

        public async Task<People> ModifyAsync(People people)
        {
            try
            {
                if (people == null)
                {
                    throw new PeopleApiWebClientArgumentNullException(nameof(people));
                }

                string url = $"{TeamManagerWebApi.PeopleApi.PeopleBase}/{TeamManagerWebApi.PeopleApi.Modify}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Put,
                    url);

                string json = JsonConvert.SerializeObject(people);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                People result = JsonConvert.DeserializeObject<People>(resultString);
                return result;
            }
            catch (Exception e)
            {
                throw new PeopleApiWebClientModifyAsyncOperationException(e.Message, e);
            }
        }
    }
}