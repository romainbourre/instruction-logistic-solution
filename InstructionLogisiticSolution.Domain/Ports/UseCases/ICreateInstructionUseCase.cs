using InstructionLogisticSolution.Domain.Ports.Exceptions;
using InstructionLogisticSolution.Domain.Ports.Requests;
using InstructionLogisticSolution.Domain.Ports.Responses;


namespace InstructionLogisticSolution.Domain.Ports.UseCases;

/// <summary>
/// This use case allow a user to create instruction.
/// </summary>
/// <exception cref="ValidationException">If input is not correct, interface should be prevent by validation error.</exception>
public interface ICreateInstructionUseCase : IUseCase<CreateInstructionRequest, CreatedInstructionResponse>
{
}
