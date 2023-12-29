using API.Contexts;
using API.Contracts;
using API.Entities;

namespace API.Repositories;

public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RegisterDbContext context) : base(context)
    {
    }
}
