using Microsoft.EntityFrameworkCore;
using TestApp.DAL;
using TestApp.DAL.Repositories;
using TestApp.Domain.Interfaces.Services;
using TestApp.Service.Services;
using TestApp.Domain.Interfaces.Repositories;
using TestApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();


void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    services.AddRazorPages();
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    services.AddTransient<IProductRepository, ProductRepository>();
    services.AddTransient<ICategoryRepository, CategoryRepository>();
    
    services.AddTransient<IProductService, ProductService>();
    services.AddTransient<ICategoryService, CategoryService>();
}