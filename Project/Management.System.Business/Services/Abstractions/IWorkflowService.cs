using System;
using System.Threading.Tasks;
using Management.System.Business.Contracts.Workflows;

namespace Management.System.Business.Services.Abstractions;

public interface IWorkflowService
{
    Task CreateAsync(CreateWorkflowRequest request);
}