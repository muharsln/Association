using Association.Core.Exceptions.Common;

namespace Association.Core.Exceptions;
public class BusinessException : ApiException
{
    public BusinessException(string errorCode, string message, string? solution = null) : base(errorCode, message, solution)
    {
    }
}
