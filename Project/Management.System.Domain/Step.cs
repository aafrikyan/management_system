using System;
using Management.System.Domain.Common;

namespace Management.System.Domain;

public class Step : RowVersion
{
    public int Id { get; set; }
    public int WorkflowId { get; set; }
    public string Name { get; set; }
    public int AssignedTo { get; set; }
    public int ActionType { get; set; }
    public int NextStep { get; set; }
    public Workflow Workflow { get; set; }
}