using System;
using System.Text.Json.Serialization;

namespace Management.System.Business.Contracts.Roles;

public sealed record GetRoleResponse
{
    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}
