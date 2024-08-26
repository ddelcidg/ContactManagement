using Microsoft.EntityFrameworkCore;
using AuthenticationService.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AuthenticationService.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración adicional de las entidades
        }
    }
}
