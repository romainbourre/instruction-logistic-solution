using InstructionLogisticSolution.Domain.Ports.Exceptions;
using InstructionLogisticSolution.Domain.Ports.Requests;
using InstructionLogisticSolution.Domain.Ports.Responses;


namespace InstructionLogisticSolution.Domain.Ports.UseCases;

/// <summary>
/// This use case allow a user to confirm instruction.
/// </summary>
/// <exception cref="ValidationException">If input is not correct, interface should be prevent by validation error.</exception>
/// <exception cref="NotAllowedException">If the instruction is already confirmed, is finished or canceled, interface should be prevent by not allowed error.</exception>
public interface IConfirmInstructionUseCase : IUseCase<ConfirmInstructionRequest, VoidResponse>
{
}
