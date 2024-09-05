namespace InMemoryCRUD.DTOs.Response;

public class GeneralResponse<T>
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public long Time { get; set; }
    public T Data { get; set; }

    public static GeneralResponse<T> Success(T data, string message)
    {
        return new GeneralResponse<T>
        {
            Status = true,
            Message = message,
            Time = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
            Data = data
        };
    }

    public static GeneralResponse<T> Error(string message, T data)
    {
        return new GeneralResponse<T>
        {
            Status = false,
            Message = message,
            Time = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
            Data = data
        };
    }
}