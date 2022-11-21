namespace InstructionLogisticSolution.Domain.Ports.Exceptions;

/* DO NOT CHANGE */
public class ResourceNotFoundException : DomainException
{
    private const string Scope = "resource not found";
    public ResourceNotFoundException(string? message) : base(Scope, message)
    {
    }
}
