namespace Bits_Orchestra_Test_Task.Dto.EmployeeDto
{
    public class RequestEmployeeListDto
    {
        public required IEnumerable<RequestEmployeeDto> Employees { get; set; }
    }
}
