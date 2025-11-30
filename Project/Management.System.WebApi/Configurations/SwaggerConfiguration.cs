using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Management.System.WebApi.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Management.System.WebApi.Configurations;

public static class SwaggerConfiguration
{
    private static string version = "v1";
    private static string title = "Workflow Tracking System";
    //private static string url = $"/swagger/{version}/swagger.json";
    private static string url = $"/docs/{version}/workflow_tracking_system.json";

    private static void ProjectXmlFiles(this SwaggerGenOptions options)
    {
        DirectoryInfo baseDirectory = new DirectoryInfo(AppContext.BaseDirectory);
        FileInfo[] files = baseDirectory.GetFiles("*.xml");
        string[] parts = Assembly.GetExecutingAssembly().GetName().Name.Split('.');
        string rootNamespace = string.Join('.', parts.Take(2));
        foreach (FileInfo fileInfo in files)
        {
            if (!fileInfo.Name.StartsWith(rootNamespace))
            {
                continue;
            }
            options.IncludeXmlComments(fileInfo.FullName, includeControllerXmlComments: true);
        }
    }

    public static void Swagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(setupAction =>
        {
            setupAction.SupportNonNullableReferenceTypes();
            setupAction.ProjectXmlFiles();
            setupAction.SwaggerDoc(version, new OpenApiInfo
            {
                Title = title,
                Version = version
            });
            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
            {
                Description = "JWT authorization header using the Bearer scheme. Example \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            };
            setupAction.AddSecurityDefinition("Bearer", securityScheme);
            setupAction.OperationFilter<SwaggerSecurityFilter>();
        });
        builder.Services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });
    }

    public static void Swagger(this WebApplication application)
    {
        application.UseSwagger(setupAction =>
        {
            setupAction.RouteTemplate = "docs/{documentName}/workflow_tracking_system.json";
            setupAction.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
            {
                httpReq.HttpContext.Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
                httpReq.HttpContext.Response.Headers["Pragma"] = "no-cache";
                httpReq.HttpContext.Response.Headers["Expires"] = "0";
            });
        });
        application.UseSwaggerUI(setupAction =>
        {
            setupAction.SwaggerEndpoint(url, title);
            setupAction.RoutePrefix = "docs";
            setupAction.DocumentTitle = title;
        });
    }
}