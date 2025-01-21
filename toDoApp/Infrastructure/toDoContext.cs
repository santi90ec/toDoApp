using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure
{
    public class toDoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public toDoContext(DbContextOptions<toDoContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Configurar la relación entre User y Task
            modelBuilder.Entity<User>()
                .HasMany<Task>()
                .WithOne()
                .HasForeignKey(t => t.Id);


        }
    }
}
