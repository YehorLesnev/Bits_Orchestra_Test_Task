using Bits_Orchestra_Test_Task.Database;
using Bits_Orchestra_Test_Task.Entities;

namespace Bits_Orchestra_Test_Task.Repositories.EmployeeRepository
{
    public class EmployeeRepository(ApplicationDbContext dbContext) 
        : BaseRepository<Employee>(dbContext), IEmployeeRepository
    {
    }
}
