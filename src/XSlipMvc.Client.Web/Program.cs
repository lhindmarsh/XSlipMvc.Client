using XSlipMvc.Client.Infrastructure.Persistence.Configurations;
using XSlipMvc.Client.Infrastructure.Persistence.Seeding;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddControllersWithViews();

//Inject DbContext from Infrastructure project, with SQLServer connectionstring, and any services needed for the app
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

//Seed the database
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
    await seeder.SeedAsync();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Banks}/{action=BankList}/{id?}");
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run();