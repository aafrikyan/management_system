using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Management.System.Domain;

namespace Management.System.Infrastructure.Persistence.Configurations;

public class StepConfiguration : IEntityTypeConfiguration<Step>
{
    public StepConfiguration()
    {
    }

    public void Configure(EntityTypeBuilder<Step> builder)
    {
        builder.ToTable("steps");

        builder.HasKey(t => t.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.WorkflowId)
            .HasColumnName("workflow_id")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.AssignedTo)
            .HasColumnName("assigned_to") // role id
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.NextStep)
            .HasColumnName("next_step")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.Version)
            .IsConcurrencyToken()
            .ValueGeneratedNever()
            .IsRequired();
    }
}
