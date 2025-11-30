using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Management.System.Shared.Validation.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public sealed class ListLengthAttribute : ValidationAttribute
{
    public int Minimum { get; }
    public int Maximum { get; }

    public ListLengthAttribute(int minimum, int maximum)
    {
        Minimum = minimum;
        Maximum = maximum;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult($"The field '{validationContext.MemberName}' is required.");
        }
        if (value is not IEnumerable enumerable)
        {
            return new ValidationResult($"The field '{validationContext.MemberName}' must be a collection.");
        }
        int count = 0;
        foreach (object _ in enumerable)
        {
            count++;
            if (count > Maximum)
            {
                return new ValidationResult($"The list cannot contain more than {Maximum} items.");
            }
        }
        if (count < Minimum)
        {
            return new ValidationResult($"The list must have at least {Minimum} items.");
        }
        return ValidationResult.Success;
    }
}
