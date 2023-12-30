using Client.Models;
using Client.Repositories;
using Client.Repositories.Interface;

namespace Client.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, Guid>, IEmployeeRepository
    {
        private readonly HttpClient httpClient;
        private readonly string request;
        public EmployeeRepository(string request = "Employees/") : base(request)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7186/api/")
            };
            this.request = request;
        }

    }
}
