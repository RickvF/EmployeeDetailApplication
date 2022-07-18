using EmployeeDetailApplication.Models;
using EmployeeDetailApplication.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailApplication.Services
{
    //Service to preform CRUD operation for the provided REST API
    public class EmployeeDataService : IEmployeeDataService
    {
        private string baseUrl = "https://gorest.co.in/public/v2/users";
        private readonly string bearerToken = "fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56";
        private readonly HttpClient _client;

        public EmployeeDataService(HttpClient client)
        {
            _client = client;
        }
        public async Task<EmployeeDto> Create(EmployeeDto entity)
        {
            string jsonEntity = JsonConvert.SerializeObject(entity);
            StringContent stringContent = new StringContent(jsonEntity, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, this.baseUrl)
            {
                Content = stringContent
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.bearerToken);
            HttpResponseMessage response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseMessage = await response.Content.ReadAsStringAsync();
                Employee employee = JsonConvert.DeserializeObject<Employee>(responseMessage);
                return employee;
            }
            else
            {
                return null;
            }
        }

        public async Task<EmployeeDto> Delete(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{this.baseUrl}/{id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.bearerToken);
            HttpResponseMessage response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseMessage = await response.Content.ReadAsStringAsync();
                Employee employee = JsonConvert.DeserializeObject<Employee>(responseMessage);
                return employee;
            } else
            {
                return null;
            }
        }

        public async Task<EmployeeDto> Get(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{this.baseUrl}/{id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.bearerToken);
            HttpResponseMessage response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseMessage = await response.Content.ReadAsStringAsync();
                Employee employee = JsonConvert.DeserializeObject<Employee>(responseMessage);
                return employee;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Employee>> getAllEmployees()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{this.baseUrl}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.bearerToken);
            HttpResponseMessage response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseMessage = await response.Content.ReadAsStringAsync();
                List<Employee> employee = JsonConvert.DeserializeObject<List<Employee>>(responseMessage);
                return employee;
            }
            else
            {
                return new List<Employee>();
            }
        }

        public async Task<List<Employee>> searchByName(string name)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{this.baseUrl}?name={name}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.bearerToken);
            HttpResponseMessage response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseMessage = await response.Content.ReadAsStringAsync();
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(responseMessage);
                return employees;
            }
            else
            {
                return null;
            }
        }

        public async Task<EmployeeDto> Update(int id, EmployeeDto entity)
        {
            string jsonEntity = JsonConvert.SerializeObject(entity);
            StringContent stringContent = new StringContent(jsonEntity, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Patch, $"{this.baseUrl}/{id}")
            {
                Content = stringContent
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.bearerToken);
            HttpResponseMessage response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseMessage = await response.Content.ReadAsStringAsync();
                Employee employee = JsonConvert.DeserializeObject<Employee>(responseMessage);
                return employee;
            }
            else
            {
                return null;
            }
        }
    }
}
