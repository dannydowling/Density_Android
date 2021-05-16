using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DensityServer.Shared;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;

namespace DensityServer.Server.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private HttpClient _httpClient;
        private IHttpContextAccessor _httpContextAccessor;

        // The httpContextAccessor is registered in configure services, then accessible in any class.
        // gives information on the context the user is running in. Such as authenticated...
        public EmployeeDataService( HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient ?? throw new System.ArgumentNullException(nameof(httpClient));
            _httpContextAccessor = httpContextAccessor ?? throw new System.ArgumentNullException(nameof(httpContextAccessor));
        }
        
     
        public async Task<Employee> GetEmployeeDetails(string Id)
        {
            return await JsonSerializer.DeserializeAsync<Employee>
                (await _httpClient.GetStreamAsync($"employee/{Id}"), 
                new JsonSerializerOptions() 
                { PropertyNameCaseInsensitive = true });
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var employeeJson =
                new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"employee/{0}", employeeJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Employee>(
                    await _httpClient.GetStreamAsync(string.Format($"employee/{0}", employee.FirstName + " " + employee.LastName)));
            }
            return null;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var employeeJson =
                new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"employee/{employee.FirstName + " " + employee.LastName}", employeeJson);

            return Task.CompletedTask.IsCompletedSuccessfully;
        }

        public async Task DeleteEmployee(string Id)
        {
            await _httpClient.DeleteAsync($"employee/{Id}");
        }
    }
}
