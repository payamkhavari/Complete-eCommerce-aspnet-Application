namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void SeedData(IApplicationBuilder builder)
        {
            using(var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();
            }
        }
    }
}
