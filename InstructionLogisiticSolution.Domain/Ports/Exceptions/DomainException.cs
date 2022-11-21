namespace InstructionLogisticSolution.Domain.Ports.Exceptions;

/* DO NOT CHANGE */
public abstract class DomainException : Exception
{
    protected DomainException(string scope, string? message) : base(ComputeMessage(scope, message))
    {
    }

    private static string ComputeMessage(string scope, string? details)
    {
        details = details != null ? $": {details}" : "";
        return $"{scope}{details}";
    }
}
