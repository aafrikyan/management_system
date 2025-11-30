using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.System.Domain.Common;

namespace Management.System.Domain;

public class User : RowVersion
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string Username { get; set; }
    public Role Role { get; set; }
}