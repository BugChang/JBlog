using JBlog.Application.AppInterfaces;
using JBlog.Application.AppServices;
using JBlog.Application.AutoMapper;
using JBlog.Core.Interfaces;
using JBlog.Data;
using JBlog.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<JBlogDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(typeof(EntityToViewModelProfile), typeof(ViewModelToEntityProfile));

builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<IArticleAppService, ArticleAppService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "shortRoute",
        pattern: "{controller}/{id:int}",
        defaults: new { action = "Index" }
    );

    endpoints.MapControllerRoute("areaRoute", "{area}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute("defaultRoute", "{controller=Home}/{action=Index}/{id?}");
});

await using var scope = app.Services.CreateAsyncScope();
await using var dbContext = scope.ServiceProvider.GetService<JBlogDbContext>();
await dbContext.Database.MigrateAsync();

app.Run();
