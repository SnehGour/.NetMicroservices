using CommandService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Plateform> Plateforms { get; set; }
        public DbSet<Command> Commands { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Plateform>()
            .HasMany(p=>p.Commands)
            .WithOne(p=>p.Plateform!)
            .HasForeignKey(p=>p.PlateformId);

            modelBuilder
            .Entity<Command>()
            .HasOne(p=>p.Plateform)
            .WithMany(p=>p.Commands)
            .HasForeignKey(p=>p.PlateformId);
        }
    }
}