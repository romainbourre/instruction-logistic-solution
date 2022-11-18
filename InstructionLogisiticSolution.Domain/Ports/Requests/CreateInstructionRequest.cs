namespace InstructionLogisticSolution.Domain.Ports.Requests;

/* DO NOT CHANGE */
public record CreateInstructionRequest
(
    string AgentName,
    string InterventionDescription,
    DateTime InterventionDateAndHour,
    string RecipientTeamName
) : IRequest;
