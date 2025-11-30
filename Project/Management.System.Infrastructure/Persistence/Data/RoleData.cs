using System;
using Microsoft.EntityFrameworkCore;
using Management.System.Domain;

namespace Management.System.Infrastructure.Persistence.Data;

public static class RoleData
{
    public static void Seed(ModelBuilder builder)
    {
        Guid version = new Guid("4019929e-708c-4f0a-974b-480b5e9f3eb6");
        builder.Entity<Role>().HasData(
            new Role { Id = 1, Code = "admin", Name = "Administrator", Version = version },
            new Role { Id = 2, Code = "employee", Name = "Employee", Version = version },
            new Role { Id = 3, Code = "manager", Name = "Manager", Version = version },
            new Role { Id = 4, Code = "finance", Name = "Finance", Version = version });
    }
}