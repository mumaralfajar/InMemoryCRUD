using System.Text.Json.Serialization;
using InMemoryCRUD.Utils;

namespace InMemoryCRUD.DTOs.Response.employee;

public class EmployeeResponse
{
    public long EmployeeID { get; set; }
    public string FullName { get; set; }
    
    [JsonConverter(typeof(DateTimeConverterUsingDateFormat))] 
    public DateTime BirthDate { get; set; }
}