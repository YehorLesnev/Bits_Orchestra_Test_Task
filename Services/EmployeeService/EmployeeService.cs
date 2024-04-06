using Bits_Orchestra_Test_Task.Entities;
using Bits_Orchestra_Test_Task.Repositories.EmployeeRepository;

namespace Bits_Orchestra_Test_Task.Services.EmployeeService
{
    public class EmployeeService(IEmployeeRepository employeeRepository) 
        : BaseService<Employee>(employeeRepository), IEmployeeService
    {
    }
}
