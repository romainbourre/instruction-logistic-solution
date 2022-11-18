namespace InstructionLogisticSolution.Domain.Ports.Responses;

/* DO NOT CHANGE */
/// <param name="State">value: confirmed, finished, canceled</param>
public record InstructionStateView(string State, DateTime DoneAt);

/* DO NOT CHANGE */
public record InstructionView(string Id, string AgentName, DateTime InterventionDateAndHour, string InterventionDescription, InstructionStateView[] States);

/* DO NOT CHANGE */
public class GetInstructionsForDateAndHourResponse : List<InstructionView>, IResponse{}
