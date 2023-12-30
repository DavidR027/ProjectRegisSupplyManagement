using Client.Models;
using Client.Repositories;

namespace Client.Repositories.Interface
{
    public interface IEmployeeRepository : IGeneralRepository<Employee, Guid>
    {

    }
}
