using System;

namespace Management.System.Business.Contracts.Users;

public sealed record GetUserResponse
{
    public string Username { get; set; }
    public string Role { get; set; }
}