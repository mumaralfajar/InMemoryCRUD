using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using InMemoryCRUD.Utils;
using Swashbuckle.AspNetCore.Annotations;

namespace InMemoryCRUD.DTOs.request.employee;

public class EmployeeRequest
{
    [Required(ErrorMessage = "FullName is required")]
    [MinLength(1, ErrorMessage = "FullName cannot be an empty string")]
    [MaxLength(50, ErrorMessage = "Max fullname is 50 chars")]
    [SwaggerSchema(Description = "Full name of the employee")]
    public string FullName { get; set; }
    
    [Required(ErrorMessage = "BirthDate is required")]
    [SwaggerSchema(Description = "Birth date of the employee")]
    [JsonConverter(typeof(DateTimeConverterUsingDateFormat))] 
    public DateTime BirthDate { get; set; }
}