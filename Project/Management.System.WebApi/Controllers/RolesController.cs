using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Management.System.Business.Services.Abstractions;
using Management.System.Business.Contracts.Roles;

namespace Management.System.WebApi.Controllers;

[Route("v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
public class RolesController : BaseController<IRoleService>
{
    public RolesController(IRoleService roleService) : base (roleService)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<GetRoleResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await service.GetAllAsync());
    }
}