using System.Net;
using System.Text.Json;

namespace Server.Middleware;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public ErrorDetails(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
    {
        StatusCode = (int)statusCode;
        Message = message;
    }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

