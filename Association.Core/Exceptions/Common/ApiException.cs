namespace Association.Core.Exceptions.Common;
public class ApiException : Exception
{
    public string ErrorCode { get; set; }
    public string Solution { get; set; }

    public ApiException(string errorCode, string message, string? solution = null)
        : base(message)
    {
        ErrorCode = errorCode;
        Solution = solution!;
    }
}
