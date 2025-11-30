using System;
using System.Collections.Generic;
using Management.System.Domain.Common;

namespace Management.System.Domain;

public class Workflow : RowVersion
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Step> Steps { get; set; }
}
