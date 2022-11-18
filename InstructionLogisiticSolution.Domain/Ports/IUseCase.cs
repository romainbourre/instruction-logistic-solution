namespace InstructionLogisticSolution.Domain.Ports;

/* DO NOT CHANGE */
public interface IUseCase<in TRequest, out TResponse> where TRequest : IRequest where TResponse : IResponse
{
    public TResponse Handle(TRequest request);
}
