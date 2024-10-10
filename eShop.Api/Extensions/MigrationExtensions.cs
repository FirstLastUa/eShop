using eShop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ApplicationDbContext dbContext =
                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // https://github.com/npgsql/npgsql/issues/3955#issuecomment-1065172063
            dbContext.Database.Migrate();
        }
    }
}
