using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class TaskTypeConfiguration : IEntityTypeConfiguration<TaskType>
    {
        public void Configure(EntityTypeBuilder<TaskType> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnType("uniqueidentifier").ValueGeneratedNever();

            builder
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar(200)");

            builder.Property(t => t.Description).HasMaxLength(1000).HasColumnType("nvarchar(1000)");

            builder.Property(t => t.DueDate).IsRequired().HasColumnType("datetime2(3)");

            builder.Property(t => t.IsCompleted).HasColumnType("bit").HasDefaultValue(false);
        }
    }
}
