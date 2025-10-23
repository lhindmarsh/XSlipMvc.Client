using XSlipMvc.Client.Infrastructure.Persistence.Configurations;
using XSlipMvc.Client.Infrastructure.Persistence.Seeding;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddControllersWithViews();

//Inject DbContext (and any Identity context) from Infrastructure project, with SQLServer connectionstring, and any services needed for the app
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddRazorPages(); //for Identity UI pages

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

app.UseAuthentication(); //Identity
app.UseAuthorization();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    //endpoints.MapControllerRoute(
    //    name: "default",
    //    pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Banks}/{action=BankList}/{id?}");

    endpoints.MapRazorPages(); //for Identity UI endpoints

    // Redirect root to Identity login
    //endpoints.MapGet("/", context =>
    //{
    //    context.Response.Redirect("/Identity/Account/Login");
    //    return Task.CompletedTask;
    //});
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run();