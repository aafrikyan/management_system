using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Management.System.Business.Services.Abstractions;
using Management.System.Business.Contracts.Workflows;

namespace Management.System.WebApi.Controllers;

[Route("v{version:apiVersion}/[controller]")]
public class WorkflowsController : BaseController<IWorkflowService>
{
    public WorkflowsController(IWorkflowService workflowService) : base(workflowService)
    {
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateWorkflowRequest request)
    {
        await service.CreateAsync(request);
        return Created();
    }
}