using AutoMapper;
using Bits_Orchestra_Test_Task.Dto.EmployeeDto;
using Bits_Orchestra_Test_Task.Entities;
using Bits_Orchestra_Test_Task.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace Bits_Orchestra_Test_Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController(
        IMapper mapper,
        IEmployeeService employeeService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ResponseEmployeeDto>> GetAll()
        {
            return Ok(mapper.Map<IEnumerable<ResponseEmployeeDto>>(employeeService.GetAll()));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseEmployeeDto>> GetByIdAsync([FromRoute] Guid id)
        {
            var employee = await employeeService.GetAsync(e => e.EmployeeId.Equals(id));

            if(employee is null) return NotFound("No user with given id");

            return Ok(mapper.Map<ResponseEmployeeDto>(employee));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseEmployeeDto>> CreateAsync([FromBody] RequestEmployeeDto employeeDto)
        {
            var newEmployee = mapper.Map<Employee>(employeeDto);

            await employeeService.CreateAsync(newEmployee);


            return await GetByIdAsync(newEmployee.EmployeeId);
        }

        [HttpPost("update-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateAllAsync([FromBody] RequestEmployeeListDto employeesDto)
        {
            var newEmployees = mapper.Map<IEnumerable<Employee>>(employeesDto.Employees);

            await employeeService.UpdateAllAsync(newEmployees.ToArray());

            return Ok();
        }

        [HttpPatch("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseEmployeeDto>> UpdateAsync([FromRoute] Guid id, [FromBody] RequestEmployeeDto employeeDto)
        {
            var updatedEmployee = mapper.Map<Employee>(employeeDto);
            updatedEmployee.EmployeeId = id;

            try
            {
                await employeeService.UpdateAsync(updatedEmployee);
            }
            catch (Exception)
            {
                return NotFound("No user with given id");
            }

            return Ok(updatedEmployee);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var employee = await employeeService.GetAsync(e => e.EmployeeId == id);

            if(employee is null) return NotFound("No user with given id");

            await employeeService.DeleteAsync(employee);

            return Ok();
        }
    }
}
