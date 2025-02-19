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
        public toDoContext(DbContextOptions<toDoContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Configurar la relación entre User y Task
            modelBuilder.Entity<User>()
            .HasKey(u => u.IdUser);
        }
    }
}
