using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.System.Business.Contracts.Users;

namespace Management.System.Business.Services.Abstractions;

public interface IUserService
{
    Task<List<GetUserResponse>> GetAllAsync();
}