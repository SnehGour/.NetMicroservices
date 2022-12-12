using Microsoft.EntityFrameworkCore;
using PlateformService.Models;

namespace PlateformService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Plateform> Plateforms { get; set; }
    }
}