using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.System.Domain.Common;

public class RowVersion
{
    [Column("version")]
    public Guid Version
    {
        get
        {
            return _Version;
        }
        set
        {
            _Version = value;
        }
    }
    private Guid _Version = Guid.NewGuid();
}