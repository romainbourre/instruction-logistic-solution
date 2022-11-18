namespace InstructionLogisticSolution.Domain.Ports.Exceptions;

/* DO NOT CHANGE */
public class NotAllowedException : DomainException
{
    private const string Scope = "this operation is not allowed";
    public NotAllowedException(string? message = null) : base(ComputeMessage(Scope, message))
    {
    }
}
