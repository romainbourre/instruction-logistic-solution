namespace InstructionLogisticSolution.Domain.Ports.Exceptions;

/* DO NOT CHANGE */
public abstract class DomainException : Exception
{
    protected DomainException(string message) : base(message)
    {
    }

    protected static string ComputeMessage(string scope, string? details)
    {
        details = details != null ? $": {details}" : "";
        return $"{scope}{details}";
    }
}
