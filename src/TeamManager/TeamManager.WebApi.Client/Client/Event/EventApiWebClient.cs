namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Event
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

    public class EventApiWebClient : IEventApiWebClient
    {
        private readonly HttpClient _httpClient;

        public EventApiWebClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new EventApiWebClientArgumentNullException(nameof(httpClient));
        }

        public async Task<Event> AddAsync(Event newEvent)
        {
            try
            {
                if (newEvent == null)
                {
                    throw new EventApiWebClientArgumentNullException(nameof(newEvent));
                }

                string url = $"{TeamManagerWebApi.EventApi.EventBase}/{TeamManagerWebApi.EventApi.Add}";
                HttpRequestMessage requestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

                string json = JsonConvert.SerializeObject(newEvent);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                requestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(requestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string responseStringContent = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                Event result = JsonConvert.DeserializeObject<Event>(responseStringContent);
                return result;
            }
            catch (Exception e)
            {
                throw new EventApiWebClientAddAsyncOperationException(e.Message, e);
            }
        }

        public async Task DeleteAsync(Event toBeDeletedEvent)
        {
            try
            {
                if (toBeDeletedEvent == null)
                {
                    throw new EventApiWebClientArgumentNullException(nameof(toBeDeletedEvent));
                }

                string url = $"{TeamManagerWebApi.EventApi.EventBase}/{TeamManagerWebApi.EventApi.Delete}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Delete,
                    url);

                string json = JsonConvert.SerializeObject(toBeDeletedEvent);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new EventApiWebClientDeleteAsyncOperationException(e.Message, e);
            }
        }

        public async Task<Event> FindAsync(Event eventToBeFound)
        {
            try
            {
                if (eventToBeFound == null)
                {
                    throw new EventApiWebClientArgumentNullException(nameof(eventToBeFound));
                }

                string url = $"{TeamManagerWebApi.EventApi.EventBase}/{TeamManagerWebApi.EventApi.Find}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

                string jsonString = JsonConvert.SerializeObject(eventToBeFound);
                StringContent stringContent = new StringContent(jsonString, Encoding.UTF8);
                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                Event result = JsonConvert.DeserializeObject<Event>(resultString);
                return result;
            }
            catch (Exception e)
            {
                throw new EventApiWebClientFindAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<Event>> GetAllAsync()
        {
            try
            {
                string url = $"{TeamManagerWebApi.EventApi.EventBase}/{TeamManagerWebApi.EventApi.GetAll}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                    url);

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                List<Event> result = JsonConvert.DeserializeObject<List<Event>>(responseString);
                return result;
            }
            catch (Exception e)
            {
                throw new EventApiWebClientGetAllAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<Event>> GetAllActiveAsync()
        {
            try
            {
                string url = $"{TeamManagerWebApi.EventApi.EventBase}/{TeamManagerWebApi.EventApi.GetAllActive}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                    url);

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                List<Event> result = JsonConvert.DeserializeObject<List<Event>>(responseString);
                return result;
            }
            catch (Exception e)
            {
                throw new EventApiWebClientGetAllActiveAsyncOperationException(e.Message, e);
            }
        }

        public async Task<Event> ModifyAsync(Event eventToBeModified)
        {
            try
            {
                if (eventToBeModified == null)
                {
                    throw new EventApiWebClientArgumentNullException(nameof(eventToBeModified));
                }

                string url = $"{TeamManagerWebApi.EventApi.EventBase}/{TeamManagerWebApi.EventApi.Modify}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Put,
                    url);

                string json = JsonConvert.SerializeObject(eventToBeModified);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                Event result = JsonConvert.DeserializeObject<Event>(resultString);
                return result;
            }
            catch (Exception e)
            {
                throw new EventApiWebClientModifyAsyncOperationException(e.Message, e);
            }
        }
    }
}