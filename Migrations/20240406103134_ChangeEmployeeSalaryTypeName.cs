using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bits_Orchestra_Test_Task.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEmployeeSalaryTypeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "employee_salary",
                table: "employees",
                type: "Decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(5,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "employee_salary",
                table: "employees",
                type: "Decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,2)");
        }
    }
}
