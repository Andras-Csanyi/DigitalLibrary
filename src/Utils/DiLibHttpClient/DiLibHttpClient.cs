// <copyright file="DiLibHttpClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Utils.DiLibHttpClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Mime;
    using System.Text;
    using System.Threading.Tasks;

    using Exceptions;

    using Guards;

    using Newtonsoft.Json;

    public class DiLibHttpClient : IDiLibHttpClient
    {
        private readonly HttpClient _httpClient;

        public DiLibHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException();
        }

        public async Task DeleteAsync<T>(T payload, string url) where T : class
        {
            try
            {
                Check.IsNotNull(payload);
                Check.NotNullOrEmptyOrWhitespace(url);

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

        public async Task<T> GetAsync<T>(string url)
        {
            try
            {
                Check.NotNullOrEmptyOrWhitespace(url);

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

                using (HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                   .ConfigureAwait(false))
                {
                    try
                    {
                        httpResponseMessage.EnsureSuccessStatusCode();
                        string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                           .ConfigureAwait(false);
                        T result = JsonToObject<T>(responseString);
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

        public async Task<T> PostAsync<T>(T payload, string url) where T : class
        {
            try
            {
                Check.IsNotNull(payload);
                Check.NotNullOrEmptyOrWhitespace(url);

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
                        T result = JsonToObject<T>(content);
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

        public async Task<ReturnType> PostAsync<ReturnType, PayloadType>(PayloadType payload, string url)
        {
            try
            {
                Check.IsNotNull(payload);
                Check.NotNullOrEmptyOrWhitespace(url);

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
                        ReturnType result = JsonToObject<ReturnType>(content);
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

        public async Task<T> PutAsync<T>(T payload, string url) where T : class
        {
            try
            {
                Check.IsNotNull(payload);
                Check.NotNullOrEmptyOrWhitespace(url);

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
                        T result = JsonToObject<T>(resultString);

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
            string payloadString = JsonConvert.SerializeObject(payload, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
            StringContent stringContent = new StringContent(payloadString, Encoding.UTF8);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Json);
            return stringContent;
        }

        private T JsonToObject<T>(string stringContent)
        {
            T result = JsonConvert.DeserializeObject<T>(stringContent, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
            return result;
        }
    }
}