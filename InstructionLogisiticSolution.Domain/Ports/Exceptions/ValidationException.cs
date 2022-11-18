namespace InstructionLogisticSolution.Domain.Ports.Exceptions;

/* DO NOT CHANGE */
public class ValidationException : DomainException
{
    private const string Scope = "validation error";
    public ValidationException(string? message = null) : base(ComputeMessage(Scope, message))
    {
    }
}
