namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Position
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

    public class PositionApiWebClient : IPositionApiWebClient
    {
        private readonly HttpClient _httpClient;

        public PositionApiWebClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new PositionApiWebClientArgumentNullException(nameof(httpClient));
        }

        public async Task<Position> AddAsync(Position position)
        {
            try
            {
                if (position == null)
                {
                    throw new PositionApiWebClientArgumentNullException(nameof(position));
                }

                string url = $"{TeamManagerWebApi.PositionApi.PositionBase}/{TeamManagerWebApi.PositionApi.Add}";
                HttpRequestMessage requestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

                string json = JsonConvert.SerializeObject(position);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                requestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(requestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string responseStringContent = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                Position result = JsonConvert.DeserializeObject<Position>(responseStringContent);
                return result;
            }
            catch (Exception e)
            {
                throw new PositionApiWebClientAddAsyncOperationException(e.Message, e);
            }
        }

        public async Task DeleteAsync(Position postition)
        {
            try
            {
                if (postition == null)
                {
                    throw new PositionApiWebClientArgumentNullException(nameof(postition));
                }

                string url = $"{TeamManagerWebApi.PositionApi.PositionBase}/{TeamManagerWebApi.PositionApi.Delete}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Delete,
                    url);

                string json = JsonConvert.SerializeObject(postition);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new PositionApiWebClientDeleteAsyncOperationException(e.Message, e);
            }
        }

        public async Task<Position> FindAsync(Position position)
        {
            try
            {
                if (position == null)
                {
                    throw new PositionApiWebClientArgumentNullException(nameof(position));
                }

                string url = $"{TeamManagerWebApi.PositionApi.PositionBase}/{TeamManagerWebApi.PositionApi.Find}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

                string jsonString = JsonConvert.SerializeObject(position);
                StringContent stringContent = new StringContent(jsonString, Encoding.UTF8);
                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                Position result = JsonConvert.DeserializeObject<Position>(resultString);
                return result;
            }
            catch (Exception e)
            {
                throw new PositionApiWebClientFindAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<Position>> GetAllAsync()
        {
            try
            {
                string url = $"{TeamManagerWebApi.PositionApi.PositionBase}/{TeamManagerWebApi.PositionApi.GetAll}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                    url);

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                List<Position> result = JsonConvert.DeserializeObject<List<Position>>(responseString);
                return result;
            }
            catch (Exception e)
            {
                throw new PositionApiWebClientGetAllAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<Position>> GetAllActiveAsync()
        {
            try
            {
                string url =
                    $"{TeamManagerWebApi.PositionApi.PositionBase}/{TeamManagerWebApi.PositionApi.GetAllActive}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                    url);

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                List<Position> result = JsonConvert.DeserializeObject<List<Position>>(responseString);
                return result;
            }
            catch (Exception e)
            {
                throw new PositionApiWebClientGetAllActiveAsyncOperationException(e.Message, e);
            }
        }

        public async Task<Position> ModifyAsync(Position peopleEventLog)
        {
            try
            {
                if (peopleEventLog == null)
                {
                    throw new PositionApiWebClientArgumentNullException(nameof(peopleEventLog));
                }

                string url = $"{TeamManagerWebApi.PositionApi.PositionBase}/{TeamManagerWebApi.PositionApi.Modify}";
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
                Position result = JsonConvert.DeserializeObject<Position>(resultString);
                return result;
            }
            catch (Exception e)
            {
                throw new PositionApiWebClientModifyAsyncOperationException(e.Message, e);
            }
        }
    }
}