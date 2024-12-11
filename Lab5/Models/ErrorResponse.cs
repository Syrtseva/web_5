namespace Lab6.Models;

public class ErrorResponse
{
    public ErrorDetail Error { get; set; }
}

public class ErrorDetail
{
    public string Code { get; set; }
    public string Message { get; set; }
    public Dictionary<string, List<string>> Context { get; set; }
}
