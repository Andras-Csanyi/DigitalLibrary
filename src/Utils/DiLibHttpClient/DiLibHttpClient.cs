using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using DigitalLibrary.Utils.DiLibHttpClient.Exceptions;
using Newtonsoft.Json;

namespace DigitalLibrary.Utils.DiLibHttpClient
{
    public class DiLibHttpClient : IDiLibHttpClient
    {
        private readonly HttpClient _httpClient;

        public DiLibHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException();
        }

        public async Task<T> Post<T>(T payload, string url)
        {
            try
            {
                if (payload == null || string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url))
                {
                    throw new ArgumentNullException();
                }

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Post, url);
                httpRequestMessage.Content = CreateStringContent(payload);

                using (HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false))
                {
                    try
                    {
                        httpResponseMessage.EnsureSuccessStatusCode();
                        string content = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                        T result = JsonConvert.DeserializeObject<T>(content);
                        return result;
                    }
                    catch (Exception e)
                    {
                        string errorDetails = await httpResponseMessage.Content.ReadAsStringAsync();
                        throw new DiLibHttpClientErrorDetailsException(errorDetails, e);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DiLibHttpClientPostException(e.Message, e);
            }
        }

        public async Task Delete<T>(T payload, string url)
        {
            try
            {
                if (payload == null || string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url))
                {
                    throw new ArgumentNullException();
                }

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Delete, url);
                httpRequestMessage.Content = CreateStringContent(payload);

                using (HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false))
                {
                    try
                    {
                        httpResponseMessage.EnsureSuccessStatusCode();
                    }
                    catch (Exception e)
                    {
                        string errorDetails = await httpResponseMessage.Content.ReadAsStringAsync()
                            .ConfigureAwait(false);
                        throw new DiLibHttpClientErrorDetailsException(errorDetails, e);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DiLibHttpClientDeleteException(e.Message, e);
            }
        }

        public async Task<T> Get<T>(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url))
                {
                    throw new ArgumentNullException();
                }

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

                using (HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false))
                {
                    try
                    {
                        httpResponseMessage.EnsureSuccessStatusCode();
                        string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                            .ConfigureAwait(false);
                        T result = JsonConvert.DeserializeObject<T>(responseString);
                        return result;
                    }
                    catch (Exception e)
                    {
                        string errorDetails = await httpResponseMessage.Content.ReadAsStringAsync()
                            .ConfigureAwait(false);
                        throw new DiLibHttpClientErrorDetailsException(errorDetails, e);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DiLibHttpClientGetException(e.Message, e);
            }
        }

        public async Task<T> Put<T>(T payload, string url)
        {
            try
            {
                if (payload == null || string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url))
                {
                    throw new ArgumentNullException();
                }

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Put, url);
                httpRequestMessage.Content = CreateStringContent(payload);

                using (HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false))
                {
                    try
                    {
                        httpResponseMessage.EnsureSuccessStatusCode();

                        string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                            .ConfigureAwait(false);
                        T result = JsonConvert.DeserializeObject<T>(resultString);

                        return result;
                    }
                    catch (Exception e)
                    {
                        string errorDetails = await httpResponseMessage.Content.ReadAsStringAsync()
                            .ConfigureAwait(false);
                        throw new DiLibHttpClientErrorDetailsException(errorDetails, e);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DiLibHttpClientPutException(e.Message, e);
            }
        }

        private StringContent CreateStringContent<T>(T payload)
        {
            string payloadString = JsonConvert.SerializeObject(payload);
            StringContent stringContent = new StringContent(payloadString, Encoding.UTF8);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Json);
            return stringContent;
        }
    }
}