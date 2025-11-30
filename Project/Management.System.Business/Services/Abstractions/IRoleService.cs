using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Management.System.Business.Contracts.Roles;

namespace Management.System.Business.Services.Abstractions;

public interface IRoleService
{
    Task<List<GetRoleResponse>> GetAllAsync();
}