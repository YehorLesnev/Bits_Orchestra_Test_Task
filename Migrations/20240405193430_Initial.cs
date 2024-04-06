using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bits_Orchestra_Test_Task.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employee_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employee_name = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    employee_date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    is_married = table.Column<bool>(type: "bit", nullable: false),
                    employee_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    employee_salary = table.Column<decimal>(type: "Decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employee_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
