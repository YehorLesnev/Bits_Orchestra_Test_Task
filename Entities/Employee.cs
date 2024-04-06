using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bits_Orchestra_Test_Task.Entities
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; } = Guid.NewGuid();

        [Required]
        [Column("employee_name")]
        [MaxLength(55)]
        public required string EmployeeName { get; set; }

        [Required]
        [Column("employee_date_of_birth")]
        public required DateOnly EmployeeDateOfBirth { get; set; }

        [Required]
        [DefaultValue(false)]
        [Column("is_married")]
        public required bool IsMarried { get; set; }

        [Required]
        [Column("employee_phone")]
        [MaxLength(20)]
        public required string EmployeePhone { get; set; }

        [Required]
        [Column("employee_salary", TypeName = "Decimal(5,2)")]
        public required decimal EmployeeSalary { get; set; }
    }
}
