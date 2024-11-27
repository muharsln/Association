using Association.Core.Exceptions;

namespace Association.Application.Common;
public abstract class BaseBusinessRules
{
    protected Task ThrowBusinessException(string message, string solution) => throw new BusinessException(message, solution);
}

