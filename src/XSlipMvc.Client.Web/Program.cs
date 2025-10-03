using XSlipMvc.Client.Infrastructure.Persistence.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

//Inject DbContext with SQLServer connectionstring
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();