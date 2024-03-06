using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Helpers
{
    public static class StartupHelper
    {
        public static void ApplyMigrations(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AzureCICDDbContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    //should replace with serilog
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while applying the database migrations.");
                }
            }
        }
    }
}
