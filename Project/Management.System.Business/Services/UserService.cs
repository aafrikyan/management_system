using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Management.System.Shared.Repositories.Abstractions;
using Management.System.Domain;
using Management.System.Business.Services.Abstractions;
using Management.System.Business.Contracts.Users;

namespace Management.System.Business.Services;

public sealed class UserService : IUserService
{
    private readonly IRepository<User> repository;

    public UserService(IRepository<User> roleRepository)
    {
        repository = roleRepository;
    }

    public async Task<List<GetUserResponse>> GetAllAsync()
    {
        List<GetUserResponse> roles = await repository.GetAllAsync(x => new GetUserResponse
        {
            Username = x.Username,
            Role = x.Role.Code
        });
        return roles;
    }
}