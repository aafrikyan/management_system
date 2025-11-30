using System;
using Microsoft.EntityFrameworkCore;
using Management.System.Domain;

namespace Management.System.Infrastructure.Persistence.Data;

public static class UserData
{
    public static void Seed(ModelBuilder builder)
    {
        Guid version = new Guid("ac7cf7de-7461-42ab-af2d-5f6979db6556");
        builder.Entity<User>().HasData(
            new User { Id = 1, RoleId = 1, Username = "admin", Version = version },
            new User { Id = 2, RoleId = 2, Username = "tom", Version = version },
            new User { Id = 3, RoleId = 3, Username = "john", Version = version },
            new User { Id = 4, RoleId = 4, Username = "jessica", Version = version });
    }
}