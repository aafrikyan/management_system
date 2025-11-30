using System;
using System.ComponentModel.DataAnnotations;

namespace Management.System.Business.Contracts.Stpes
{
    public sealed record CreateStepRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; init; }

        [Required]
        [StringLength(30)]
        public string AssignedTo { get; init; }

        [Required]
        [StringLength(100)]
        public string ActionType { get; init; }

        [Required]
        [StringLength(100)]
        public string NextStep { get; init; }
    }
}