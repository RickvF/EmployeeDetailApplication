using EmployeeDetailApplication.Models;
using EmployeeDetailApplication.Models.Dto;
using EmployeeDetailApplication.Services;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeDetailApplication.Test.Services
{
    public class EmployeeDataServiceTest
    {
        private Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private List<Employee> _employees;
        private HttpResponseMessage _httpResponseMessage;

        [SetUp]
        public void SetUp()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _employees = new List<Employee>();
            _httpResponseMessage = new HttpResponseMessage();
            _httpResponseMessage.StatusCode = HttpStatusCode.OK;
        }

        [Test]
        public async Task GetEmployeesByName_Match()
        {
            Employee expectedEmployee = new Employee();
            expectedEmployee.id = 1;
            expectedEmployee.name = "test";
            expectedEmployee.email = "test@gmail.com";
            expectedEmployee.gender = "male";
            expectedEmployee.status = "inactive";
            _employees.Add(expectedEmployee);
            
            _httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(_employees));

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(_httpResponseMessage);

            HttpClient client = new HttpClient(_httpMessageHandlerMock.Object);
            EmployeeDataService employeeDataService = new EmployeeDataService(client);

            List<Employee> resultEmployees = await employeeDataService.searchByName(expectedEmployee.name);

            Assert.AreEqual(expectedEmployee.id, resultEmployees[0].id);
        }

        [Test]
        public async Task GetEmployeesByName_NoMatch()
        {
            
            _httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(_employees));

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(_httpResponseMessage);

            HttpClient client = new HttpClient(_httpMessageHandlerMock.Object);
            EmployeeDataService employeeDataService = new EmployeeDataService(client);

            List<Employee> resultEmployees = await employeeDataService.searchByName("test");

            Assert.IsEmpty(resultEmployees);
        }
    }
}
