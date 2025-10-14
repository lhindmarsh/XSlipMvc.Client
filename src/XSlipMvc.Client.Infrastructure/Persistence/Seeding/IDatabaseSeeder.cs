namespace XSlipMvc.Client.Infrastructure.Persistence.Seeding
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}