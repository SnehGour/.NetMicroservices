using PlateformService.Models;

namespace PlateformService.Data
{
    public static class PrepDb
    {
        public static void PrepDbPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if(!context.Plateforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                
                context.Plateforms.AddRange(
                    new Plateform(){Name="Dotnet",Publisher="Microsoft",Cost="Free"},
                    new Plateform(){Name="SQL Server",Publisher="Microsoft",Cost="Free"},
                    new Plateform(){Name="Kubernetes",Publisher="Cloud Native Computing Foundation",Cost="Free"}
                );

                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("--> We Already have Data...");
            }
        }
    }
}