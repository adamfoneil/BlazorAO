using BlazorAO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BlazorAO.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Job> Job { get; set; }
        public DbSet<Workspace> Workspace { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Job>()                
                .HasKey(
                    nameof(BlazorAO.Models.Job.ClientId), 
                    nameof(BlazorAO.Models.Job.Name));

            builder.Entity<Client>()
                .HasKey(
                    nameof(BlazorAO.Models.Client.WorkspaceId),
                    nameof(BlazorAO.Models.Client.Name));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo((s) => Debug.WriteLine(s), LogLevel.Information);
        }
    }
}
