using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence.Utilities
{
    public static class Seeder
    {
        public static async Task SeedDatabase(this IApplicationBuilder app, bool shouldSeedDatabase)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

            var applicationDbContext = scope?.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!shouldSeedDatabase)
                return;

            SeedEvents(applicationDbContext);
        }

        private static void SeedEvents(ApplicationDbContext context)
        {
            context.Events.RemoveRange(context.Events.ToList());
            context.Events.AddRange(Configuration.GetEvents());
            context.SaveChanges();
        }
    }
}
