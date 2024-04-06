using System.Text.Json.Serialization;

namespace Bits_Orchestra_Test_Task.Dto.EmployeeDto
{
    public class ResponseEmployeeDto
    {
        [JsonPropertyName("employee_id")]
        public required Guid EmployeeId { get; set; }

        [JsonPropertyName("employee_name")]
        public required string EmployeeName { get; set; }

        [JsonPropertyName("employee_date_of_birth")]
        public required DateOnly EmployeeDateOfBirth { get; set; }

        [JsonPropertyName("is_married")]
        public required bool IsMarried { get; set; }

        [JsonPropertyName("employee_phone")]
        public required string EmployeePhone { get; set; }

        [JsonPropertyName("employee_salary")]
        public required decimal EmployeeSalary { get; set; }
    }
}
