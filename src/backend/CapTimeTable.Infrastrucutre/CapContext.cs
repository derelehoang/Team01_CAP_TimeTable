using CapTimeTable.Domain;
using CapTimeTable.Infrastrucutre.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapTimeTable.Infrastrucutre
{
    public class CapContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CapWeek> CapWeek { get; set; }

        public CapContext(DbContextOptions<CapContext> options)
  : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }

        internal static CapContext CreateContext()
        {
            return new CapContext(new DbContextOptionsBuilder<CapContext>().UseSqlServer(
                 new ConfigurationBuilder()
                     .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), $"appsettings.json"))
                     .AddEnvironmentVariables()
                     .Build()
                     .GetConnectionString("DefaultConnection")
                 ).Options);
        }
    }
}
