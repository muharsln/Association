using Association.Core.Exceptions.Common;

namespace Association.Core.Exceptions;
public class BusinessException(string message, string? solution = null) : ApiException("BUSINESS_ERROR", message, solution) { }
