using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.System.Domain;
using Management.System.Shared.Repositories.Abstractions;
using Management.System.Business.Services.Abstractions;
using Management.System.Business.Contracts.Workflows;

namespace Management.System.Business.Services;

public sealed class WorkflowService : IWorkflowService
{
    private readonly IRepository<Role> repository;

    public WorkflowService(IRepository<Role> roleRepository)
    {
        repository = roleRepository;
    }

    public async Task CreateAsync(CreateWorkflowRequest request)
    {
        // Check if Step ActionTypes are correct
        // Create a new Workflow, fill fields with data
        // Call await repository.CreateAsync();
    }
}