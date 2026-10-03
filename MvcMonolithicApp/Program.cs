using Microsoft.EntityFrameworkCore;
using MvcMonolithicApp.ApplicationServices;
using MvcMonolithicApp.ApplicationServices.Contracts;
using MvcMonolithicApp.Models.Services;
using MvcMonolithicApp.Models.Services.Contracts;
using MvcMonolithicApp.Models.Services.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("FinalProjectDb") ?? throw new InvalidOperationException("Connection string 'FinalProjectDb' not found.");
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonApplicationService, PersonApplicationService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductApplicationService, ProductApplicationService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();