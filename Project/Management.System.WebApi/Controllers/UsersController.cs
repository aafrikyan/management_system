using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Management.System.Business.Services.Abstractions;
using Management.System.Business.Contracts.Users;

namespace Management.System.WebApi.Controllers;

[Route("v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
public class UsersController : BaseController<IUserService>
{
    public UsersController(IUserService userService) : base(userService)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<GetUserResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await service.GetAllAsync());
    }
}