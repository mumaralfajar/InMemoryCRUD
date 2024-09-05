using InMemoryCRUD.DTOs.request.employee;
using InMemoryCRUD.DTOs.Response;
using InMemoryCRUD.DTOs.Response.employee;
using InMemoryCRUD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace InMemoryCRUD.Controllers;

[Route("api/[controller]")]
[SwaggerTag("Employee Management")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get paginated list of employees")]
    [SwaggerResponse(200, "Employees retrieved successfully", typeof(PagedResponse<EmployeeResponse>))]
    public IActionResult GetEmployees([FromQuery] int page = 1, [FromQuery] int size = 5)
    {
        var employees = _employeeService.GetAllEmployees(page, size);

        if (employees.Items.Count != 0)
            return Ok(GeneralResponse<PagedResponse<EmployeeResponse>>.Success(employees,
                "Employees retrieved successfully"));
        
        var emptyResponse = new PagedResponse<EmployeeResponse>(page, size, 0, 1, []);
        return Ok(GeneralResponse<PagedResponse<EmployeeResponse>>.Success(emptyResponse, "No employees found"));
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Get employee details by ID")]
    [SwaggerResponse(200, "Employee retrieved successfully", typeof(EmployeeResponse))]
    public IActionResult GetEmployeeById(long id)
    {
        try
        {
            var employee = _employeeService.GetEmployeeById(id);
            return Ok(GeneralResponse<EmployeeResponse>.Success(employee, "Employee retrieved successfully"));
        }
        catch (ArgumentException ex)
        {
            return NotFound(GeneralResponse<EmployeeResponse>.Error(ex.Message, null));
        }
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Add a new employee")]
    [SwaggerRequestExample(typeof(EmployeeRequest), typeof(EmployeeRequestExample))]
    [SwaggerResponse(201, "Employee added successfully", typeof(EmployeeResponse))]
    public IActionResult AddEmployee([FromBody] EmployeeRequest employeeRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var employee = _employeeService.AddEmployee(employeeRequest);
            return Created($"/employees/{employee.EmployeeID}",
                GeneralResponse<EmployeeResponse>.Success(employee, "Employee added successfully"));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(GeneralResponse<EmployeeResponse>.Error(ex.Message, null));
        }
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing employee")]
    [SwaggerResponse(200, "Employee updated successfully", typeof(EmployeeResponse))]
    public IActionResult UpdateEmployee(long id, [FromBody] EmployeeRequest employeeRequest)
    {
        try
        {
            var updatedEmployee = _employeeService.UpdateEmployee(id, employeeRequest);
            return Ok(GeneralResponse<EmployeeResponse>.Success(updatedEmployee, "Employee updated successfully"));
        }
        catch (ArgumentException ex)
        {
            return NotFound(GeneralResponse<EmployeeResponse>.Error(ex.Message, null));
        }
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Remove an employee by ID")]
    [SwaggerResponse(200, "Employee removed successfully", typeof(EmployeeResponse))]
    public IActionResult RemoveEmployee(long id)
    {
        try
        {
            var deletedEmployee = _employeeService.DeleteEmployee(id);
            return Ok(GeneralResponse<EmployeeResponse>.Success(deletedEmployee, "Employee removed successfully"));
        }
        catch (ArgumentException ex)
        {
            return NotFound(GeneralResponse<EmployeeResponse>.Error(ex.Message, null));
        }
    }
}