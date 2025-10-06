using XSlipMvc.Client.Infrastructure.Persistence.Configurations;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddControllersWithViews();

//Inject DbContext with SQLServer connectionstring
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Expenses}/{action=Index}/{id?}");
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

//app.MapGet("/", () => "Hello World!");

app.Run();