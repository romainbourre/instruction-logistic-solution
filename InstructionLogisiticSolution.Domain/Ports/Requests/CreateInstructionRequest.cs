namespace InstructionLogisticSolution.Domain.Ports.Requests;

/* DO NOT CHANGE */
public record CreateInstructionRequest : IRequest
{
    public string? AgentName { get; init; }
    public string? InterventionDescription { get; init; }
    public DateTime? InterventionDateAndHour { get; init; }
    public string? RecipientTeamName { get; init; }
}
