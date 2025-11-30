using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Management.System.WebApi.Filters;

public sealed class SwaggerSecurityFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        bool Has<T>(IEnumerable<object> items) where T : Attribute => items.OfType<T>().Any();

        object[] methodAttributes = context.MethodInfo?.GetCustomAttributes(true) ?? Array.Empty<object>();
        object[] controllerAttributes = context.MethodInfo?.DeclaringType?.GetCustomAttributes(true) ?? Array.Empty<object>();
        IList<object> endpointMetadata = context.ApiDescription?.ActionDescriptor?.EndpointMetadata ?? Array.Empty<object>();
        if (Has<AllowAnonymousAttribute>(methodAttributes) || Has<AllowAnonymousAttribute>(controllerAttributes)
            || Has<AllowAnonymousAttribute>(endpointMetadata))
        {
            operation.Security = new List<OpenApiSecurityRequirement>();
            return;
        }
        if (Has<AuthorizeAttribute>(methodAttributes) || Has<AuthorizeAttribute>(controllerAttributes)
            || Has<AuthorizeAttribute>(endpointMetadata))
        {
            operation.Security ??= new List<OpenApiSecurityRequirement>();
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        }
        else
        {
            operation.Security = new List<OpenApiSecurityRequirement>();
        }
    }
}