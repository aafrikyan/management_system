using System;
using Management.System.Domain.Common;

namespace Management.System.Domain;

public class Role : RowVersion
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
}
