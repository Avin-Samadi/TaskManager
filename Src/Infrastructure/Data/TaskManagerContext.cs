using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add configuration here
            modelBuilder.ApplyConfiguration(new TaskTypeConfiguration());
        }

        public DbSet<TaskType> taskTypes => Set<TaskType>();
    }
}
