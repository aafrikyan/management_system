using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Management.System.Shared.Repositories.Abstractions;
using Management.System.Domain;
using Management.System.Business.Services.Abstractions;
using Management.System.Business.Contracts.Roles;

namespace Management.System.Business.Services;

public sealed class RoleService : IRoleService
{
    private readonly IRepository<Role> repository;

    public RoleService(IRepository<Role> roleRepository)
    {
        repository = roleRepository;
    }

    public async Task<List<GetRoleResponse>> GetAllAsync()
    {
        List<GetRoleResponse> roles = await repository.GetAllAsync(x => new GetRoleResponse
        {
            Code = x.Code,
            Name = x.Name
        });
        return roles;
    }
}