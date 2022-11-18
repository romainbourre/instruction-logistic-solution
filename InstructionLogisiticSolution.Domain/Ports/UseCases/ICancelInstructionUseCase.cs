using InstructionLogisticSolution.Domain.Ports.Exceptions;
using InstructionLogisticSolution.Domain.Ports.Requests;
using InstructionLogisticSolution.Domain.Ports.Responses;


namespace InstructionLogisticSolution.Domain.Ports.UseCases;

/// <summary>
/// This use case allow a user to cancel instruction.
/// </summary>
/// <exception cref="ValidationException">If input is not correct, interface should be prevent by validation error.</exception>
/// <exception cref="NotAllowedException">If the instruction is confirmed or finished, interface should be prevent by not allowed error.</exception>
public interface ICancelInstructionUseCase : IUseCase<CancelInstructionRequest, VoidResponse>
{
}
