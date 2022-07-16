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
    public class EmployeeDataService : IEmployeeDataService
    {
        private string baseUrl = "https://gorest.co.in/public/v2/users";
        private readonly string bearerToken = "fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56";
        public Task<EmployeeDto> Create(EmployeeDto entity)
        {
            throw new NotImplementedException();
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, this.baseUrl);

            }
        }

        public async Task<EmployeeDto> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"{this.baseUrl}/{id}");

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.bearerToken);
                HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
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
        }

        public async Task<EmployeeDto> Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{ this.baseUrl}/{id}");
                string responseMessage = await response.Content.ReadAsStringAsync();
                Employee employee = JsonConvert.DeserializeObject<Employee>(responseMessage);
                return employee;
            }
        }

        public async Task<List<Employee>> getAllEmployees()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(this.baseUrl);
                string responseMessage = await response.Content.ReadAsStringAsync();
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(responseMessage);
                return employees;
            }
        }

        public async Task<List<Employee>> searchByName(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{this.baseUrl}?name={name}");
                string responseMessage = await response.Content.ReadAsStringAsync();
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(responseMessage);
                return employees;
            }
        }

        public Task<EmployeeDto> Update(EmployeeDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
