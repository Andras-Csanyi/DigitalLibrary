namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Company
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

    public class CompanyApiWebClient : ICompanyApiWebClient
    {
        private readonly HttpClient _httpClient;

        public CompanyApiWebClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new CompanyApiWebClientArgumentNullException(nameof(httpClient));
        }

        public async Task<Company> AddAsync(Company company)
        {
            try
            {
                if (company == null)
                {
                    throw new CompanyApiWebClientArgumentNullException(nameof(company));
                }

                string url = $"{TeamManagerWebApi.CompanyApi.CompanyBase}/{TeamManagerWebApi.CompanyApi.Add}";
                HttpRequestMessage requestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

                string json = JsonConvert.SerializeObject(company);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                requestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(requestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string responseStringContent = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                Company result = JsonConvert.DeserializeObject<Company>(responseStringContent);
                return result;
            }
            catch (Exception e)
            {
                throw new CompanyApiWebClientAddAsyncOperationException(e.Message, e);
            }
        }

        public async Task DeleteAsync(Company company)
        {
            try
            {
                if (company == null)
                {
                    throw new CompanyApiWebClientArgumentNullException(nameof(company));
                }

                string url = $"{TeamManagerWebApi.CompanyApi.CompanyBase}/{TeamManagerWebApi.CompanyApi.Delete}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Delete,
                    url);

                string json = JsonConvert.SerializeObject(company);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw new CompanyApiWebClientDeleteAsyncOperationException(e.Message, e);
            }
        }

        public async Task<Company> FindAsync(Company company)
        {
            try
            {
                if (company == null)
                {
                    throw new CompanyApiWebClientArgumentNullException(nameof(company));
                }

                string url = $"{TeamManagerWebApi.CompanyApi.CompanyBase}/{TeamManagerWebApi.CompanyApi.Find}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

                string jsonString = JsonConvert.SerializeObject(company);
                StringContent stringContent = new StringContent(jsonString, Encoding.UTF8);
                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = stringContent;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                Company result = JsonConvert.DeserializeObject<Company>(resultString);
                return result;
            }
            catch (Exception e)
            {
                throw new CompanyApiWebClientFindAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<Company>> GetAllAsync()
        {
            try
            {
                string url = $"{TeamManagerWebApi.CompanyApi.CompanyBase}/{TeamManagerWebApi.CompanyApi.GetAll}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                    url);

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                List<Company> result = JsonConvert.DeserializeObject<List<Company>>(responseString);
                return result;
            }
            catch (Exception e)
            {
                throw new CompanyApiWebClientGetAllAsyncOperationException(e.Message, e);
            }
        }

        public async Task<List<Company>> GetAllActiveAsync()
        {
            try
            {
                string url = $"{TeamManagerWebApi.CompanyApi.CompanyBase}/{TeamManagerWebApi.CompanyApi.GetAllActive}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                    url);

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                List<Company> result = JsonConvert.DeserializeObject<List<Company>>(responseString);
                return result;
            }
            catch (Exception e)
            {
                throw new CompanyApiWebClientGetAllActiveAsyncOperationException(e.Message, e);
            }
        }

        public async Task<Company> ModifyAsync(Company company)
        {
            try
            {
                if (company == null)
                {
                    throw new CompanyApiWebClientArgumentNullException(nameof(company));
                }

                string url = $"{TeamManagerWebApi.CompanyApi.CompanyBase}/{TeamManagerWebApi.CompanyApi.Modify}";
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Put,
                    url);

                string json = JsonConvert.SerializeObject(company);
                StringContent content = new StringContent(json, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpRequestMessage.Content = content;

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
                    .ConfigureAwait(false);

                httpResponseMessage.EnsureSuccessStatusCode();

                string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                Company result = JsonConvert.DeserializeObject<Company>(resultString);
                return result;
            }
            catch (Exception e)
            {
                throw new CompanyApiWebClientModifyAsyncOperationException(e.Message, e);
            }
        }
    }
}