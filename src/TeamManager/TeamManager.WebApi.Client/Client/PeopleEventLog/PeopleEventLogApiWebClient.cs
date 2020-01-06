namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.PeopleEventLog
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

    public class PeopleEventLogApiWebClient : IPeopleEventLogApiWebClient
    {
        private readonly HttpClient _httpClient;

        public PeopleEventLogApiWebClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new PeopleEventLogApiWebClientArgumentNullException(nameof(httpClient));
        }

        public async Task<PeopleEventLog> AddAsync(PeopleEventLog peopleEventLog)
        {
            try
            {
                if (peopleEventLog == null)
                {
                    throw new PeopleEventLogApiWebClientArgumentNullException(nameof(peopleEventLog));
                }

                string url =
                    $"{TeamManagerWebApi.PeopleEventLogApi.PeopleEventLogBase}/{TeamManagerWebApi.PeopleEventLogApi.Add}";
                HttpRequestMessage requestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

                string json = JsonConvert.SerializeObject(
                    peopleEventLog,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    });
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                requestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(requestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string responseStringContent = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                PeopleEventLog result = JsonConvert.DeserializeObject<PeopleEventLog>(
                    responseStringContent,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    });
                return result;
            }
            catch (Exception e)
            {
                throw new PeopleEventLogApiWebClientAddAsyncOperationException(e.Message, e);
            }
        }

        public async Task DeleteAsync(PeopleEventLog peopleEventLog)
        {
            try
            {
                if (peopleEventLog == null)
                {
                    throw new PeopleEventLogApiWebClientArgumentNullException(nameof(peopleEventLog));
                }

                string url =
                    $"{TeamManagerWebApi.PeopleEventLogApi.PeopleEventLogBase}/{TeamManagerWebApi.PeopleEventLogApi.Delete}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Delete,
                    url);

                string json = JsonConvert.SerializeObject(peopleEventLog);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new PeopleEventLogApiWebClientDeleteAsyncOperationException(e.Message, e);
            }
        }

        public async Task<PeopleEventLog> FindAsync(PeopleEventLog peopleEventLog)
        {
            try
            {
                if (peopleEventLog == null)
                {
                    throw new PeopleEventLogApiWebClientArgumentNullException(nameof(peopleEventLog));
                }

                string url =
                    $"{TeamManagerWebApi.PeopleEventLogApi.PeopleEventLogBase}/{TeamManagerWebApi.PeopleEventLogApi.Find}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

                string jsonString = JsonConvert.SerializeObject(peopleEventLog);
                StringContent stringContent = new StringContent(jsonString, Encoding.UTF8);
                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                PeopleEventLog result = JsonConvert.DeserializeObject<PeopleEventLog>(resultString);
                return result;
            }
            catch (Exception e)
            {
                throw new PeopleEventLogApiWebClientFindAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<PeopleEventLog>> GetAllAsync()
        {
            try
            {
                string url =
                    $"{TeamManagerWebApi.PeopleEventLogApi.PeopleEventLogBase}/{TeamManagerWebApi.PeopleEventLogApi.GetAll}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                    url);

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                List<PeopleEventLog> result = JsonConvert.DeserializeObject<List<PeopleEventLog>>(responseString);
                return result;
            }
            catch (Exception e)
            {
                throw new PeopleEventLogApiWebClientGetAllAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<PeopleEventLog>> GetAllActiveAsync()
        {
            try
            {
                string url =
                    $"{TeamManagerWebApi.PeopleEventLogApi.PeopleEventLogBase}/{TeamManagerWebApi.PeopleEventLogApi.GetAllActive}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    url);

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                List<PeopleEventLog> result = JsonConvert.DeserializeObject<List<PeopleEventLog>>(responseString);
                return result;
            }
            catch (Exception e)
            {
                throw new PeopleEventLogApiWebClientGetAllActiveAsyncOperationException(e.Message, e);
            }
        }

        public async Task<PeopleEventLog> ModifyAsync(PeopleEventLog peopleEventLog)
        {
            try
            {
                if (peopleEventLog == null)
                {
                    throw new PeopleEventLogApiWebClientArgumentNullException(nameof(peopleEventLog));
                }

                string url =
                    $"{TeamManagerWebApi.PeopleEventLogApi.PeopleEventLogBase}/{TeamManagerWebApi.PeopleEventLogApi.Modify}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Put,
                    url);

                string json = JsonConvert.SerializeObject(peopleEventLog);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                PeopleEventLog result = JsonConvert.DeserializeObject<PeopleEventLog>(resultString);
                return result;
            }
            catch (Exception e)
            {
                throw new PeopleEventLogApiWebClientModifyAsyncOperationException(e.Message, e);
            }
        }
    }
}