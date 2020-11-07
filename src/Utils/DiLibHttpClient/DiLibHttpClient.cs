// <copyright file="DiLibHttpClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Utils.DiLibHttpClient
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Mime;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.Utils.DiLibHttpClient.Exceptions;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    using Newtonsoft.Json;

    /// <inheritdoc />
    public class DiLibHttpClient : IDiLibHttpClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiLibHttpClient"/> class.
        /// </summary>
        /// <param name="httpClient">Instance.</param>
        public DiLibHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync<T>(T payload, string url)
            where T : class
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
                throw new DiLibHttpClientException(e.Message, e);
            }
        }

        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<T>> GetAsync<T>(
            string url,
            CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmptyOrWhitespace(url);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            DilibHttpClientResponse<T> result = new DilibHttpClientResponse<T>();

            using (HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
               .ConfigureAwait(false))
            {
                try
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                       .ConfigureAwait(false);
                    T res = JsonToObject<T>(responseString);

                    result.Result = res;
                    result.IsSuccess = true;
                    result.HttpStatusCode = (int) httpResponseMessage.StatusCode;

                    return result;
                }
                catch (Exception e)
                {
                    string errorDetails = await httpResponseMessage.Content.ReadAsStringAsync()
                       .ConfigureAwait(false);

                    result.IsSuccess = false;
                    result.HttpStatusCode = (int) httpResponseMessage.StatusCode;
                    result.ErrorDetails = errorDetails;

                    return result;
                }
            }
        }

        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<T>> PostAsync<T>(T payload,
                                                                   string url,
                                                                   CancellationToken cancellationToken = default)
            where T : class
        {
            Check.IsNotNull(payload);
            Check.NotNullOrEmptyOrWhitespace(url);
            DilibHttpClientResponse<T> result = new DilibHttpClientResponse<T>();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Post, url);
            httpRequestMessage.Content = CreateStringContent(payload);

            using (HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(
                    httpRequestMessage,
                    cancellationToken)
               .ConfigureAwait(false))
            {
                try
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string content = await httpResponseMessage
                       .Content
                       .ReadAsStringAsync()
                       .ConfigureAwait(false);

                    T res = JsonToObject<T>(content);

                    result.Result = res;
                    result.IsSuccess = true;
                    result.HttpStatusCode = (int) httpResponseMessage.StatusCode;

                    return result;
                }
                catch (Exception e)
                {
                    string errorDetails = await httpResponseMessage
                       .Content
                       .ReadAsStringAsync()
                       .ConfigureAwait(false);

                    result.ExceptionMessage = e.Message;
                    result.ErrorDetails = errorDetails;
                    result.HttpStatusCode = (int) httpResponseMessage.StatusCode;
                    result.IsSuccess = false;

                    return result;
                }
            }
        }

        /// <inheritdoc/>
        public async Task<TReturnType> PostAsync<TReturnType, TPayloadType>(TPayloadType payload, string url)
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
                        string content =
                            await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                        TReturnType result = JsonToObject<TReturnType>(content);
                        return result;
                    }
                    catch (Exception e)
                    {
                        string errorDetails =
                            await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new DiLibHttpClientErrorDetailsException(errorDetails, e);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DiLibHttpClientException(e.Message, e);
            }
        }

        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<T>> PutAsync<T>(
            T payload,
            string url,
            CancellationToken cancellationToken = default)
            where T : class
        {
            Check.IsNotNull(payload);
            Check.NotNullOrEmptyOrWhitespace(url);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Put, url);
            httpRequestMessage.Content = CreateStringContent(payload);

            DilibHttpClientResponse<T> result = new DilibHttpClientResponse<T>();

            using (HttpResponseMessage httpResponseMessage = await _httpClient
               .SendAsync(httpRequestMessage, cancellationToken)
               .ConfigureAwait(false))
            {
                try
                {
                    httpResponseMessage.EnsureSuccessStatusCode();

                    string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                       .ConfigureAwait(false);
                    T resulToObject = JsonToObject<T>(resultString);

                    result.Result = resulToObject;
                    result.IsSuccess = true;
                    result.HttpStatusCode = (int) httpResponseMessage.StatusCode;

                    return result;
                }
                catch (Exception e)
                {
                    string errorDetails = await httpResponseMessage.Content.ReadAsStringAsync()
                       .ConfigureAwait(false);
                    result.ErrorDetails = errorDetails;
                    result.IsSuccess = false;
                    result.HttpStatusCode = (int) httpResponseMessage.StatusCode;

                    return result;
                }
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