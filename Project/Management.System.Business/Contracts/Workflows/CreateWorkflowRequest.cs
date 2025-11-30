using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Management.System.Business.Contracts.Stpes;
using Management.System.Shared.Validation.Attributes;

namespace Management.System.Business.Contracts.Workflows;

public sealed record CreateWorkflowRequest
{
    [Required]
    [StringLength(100)]
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [Required]
    [StringLength(500)]
    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [Required]
    [ListLength(minimum: 3, maximum: 10)]
    [JsonPropertyName("steps")]
    public List<CreateStepRequest> Steps { get; init; } = new();
}
