using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.System.WebApi.Controllers;

[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class BaseController<TService> : ControllerBase
{
    protected internal readonly TService service;

    public BaseController(TService service)
    {
        this.service = service;
    }
}