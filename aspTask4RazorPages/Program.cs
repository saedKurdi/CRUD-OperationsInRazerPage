using aspTask4RazorPages.Context;
using aspTask4RazorPages.Entities.Concretes;
using aspTask4RazorPages.Repositories.Abstracts;
using aspTask4RazorPages.Repositories.Concretes;
using aspTask4RazorPages.Services.Abstracts;
using aspTask4RazorPages.Services.Concretes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ProductDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
},ServiceLifetime.Scoped);
builder.Services.AddScoped<IBaseRepository<Product>,ProductRepository>();
builder.Services.AddScoped<IProductService,ProductService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/", async context =>
{
    context.Response.Redirect("/Products");
});

app.Run();
