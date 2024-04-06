namespace Bits_Orchestra_Test_Task.Dto.EmployeeDto
{
    public class RequestUpdateEmployeeListDto
    {
        public required IEnumerable<ResponseEmployeeDto> Employees { get; set; }
    }
}
