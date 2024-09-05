using InMemoryCRUD.DTOs.request.employee;
using InMemoryCRUD.DTOs.Response;
using InMemoryCRUD.DTOs.Response.employee;
using InMemoryCRUD.Models;
using InMemoryCRUD.Repositories;
using InMemoryCRUD.Services.Interfaces;

namespace InMemoryCRUD.Services;

public class EmployeeService : IEmployeeService
{
    public PagedResponse<EmployeeResponse> GetAllEmployees(int page, int size)
    {
        var totalItems = EmployeeRepository.Employees.Count;
        var totalPages = (int)Math.Ceiling((double)totalItems / size);

        // Paginate employees
        var paginatedEmployees = EmployeeRepository.Employees
            .Skip((page - 1) * size)
            .Take(size)
            .Select(e => new EmployeeResponse
            {
                EmployeeID = e.EmployeeID,
                FullName = e.FullName,
                BirthDate = e.BirthDate
            }).ToList();

        // Return paginated response
        return new PagedResponse<EmployeeResponse>(page, size, totalItems, totalPages, paginatedEmployees);
    }

    public EmployeeResponse GetEmployeeById(long id)
    {
        var employee = EmployeeRepository.Employees.FirstOrDefault(e => e.EmployeeID == id);
        if (employee == null)
        {
            throw new ArgumentException("Employee not found");
        }

        return new EmployeeResponse
        {
            EmployeeID = employee.EmployeeID,
            FullName = employee.FullName,
            BirthDate = employee.BirthDate
        };
    }

    public EmployeeResponse AddEmployee(EmployeeRequest employeeRequest)
    {
        ArgumentNullException.ThrowIfNull(employeeRequest);

        // Generate a new EmployeeID
        var newId = EmployeeRepository.Employees.Count != 0 ? EmployeeRepository.Employees.Max(e => e.EmployeeID) + 1 : 1;

        // Map EmployeeRequest to Employee model
        var employee = new Employee
        {
            EmployeeID = newId,
            FullName = employeeRequest.FullName,
            BirthDate = employeeRequest.BirthDate
        };

        // Add the employee to the repository
        EmployeeRepository.Employees.Add(employee);

        return new EmployeeResponse
        {
            EmployeeID = employee.EmployeeID,
            FullName = employee.FullName,
            BirthDate = employee.BirthDate
        };
    }

    public EmployeeResponse UpdateEmployee(long id, EmployeeRequest updatedEmployeeRequest)
    {
        var existingEmployee = EmployeeRepository.Employees.FirstOrDefault(e => e.EmployeeID == id);
        if (existingEmployee == null)
        {
            throw new ArgumentException("Employee not found");
        }

        // Update employee details
        existingEmployee.FullName = updatedEmployeeRequest.FullName;
        existingEmployee.BirthDate = updatedEmployeeRequest.BirthDate;

        return new EmployeeResponse
        {
            EmployeeID = existingEmployee.EmployeeID,
            FullName = existingEmployee.FullName,
            BirthDate = existingEmployee.BirthDate
        };
    }

    public EmployeeResponse DeleteEmployee(long id)
    {
        var employee = EmployeeRepository.Employees.FirstOrDefault(e => e.EmployeeID == id);
        if (employee == null)
        {
            throw new ArgumentException("Employee not found");
        }

        EmployeeRepository.Employees.Remove(employee);

        return new EmployeeResponse
        {
            EmployeeID = employee.EmployeeID,
            FullName = employee.FullName,
            BirthDate = employee.BirthDate
        };
    }
}
