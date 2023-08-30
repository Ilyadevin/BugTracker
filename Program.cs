using BugTracker.Data;
using BugTracker.Data.Interfaces;
using BugTracker.Data.Mocs;
using BugTracker.Data.Repository;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        string connection = builder.Configuration.GetConnectionString("DefaultConnection");

        IServiceCollection services = builder.Services;
        services.AddTransient<IBugs, BugsRepository>();
        services.AddTransient<IBugPriority, BugPriorityRepository>();
        services.AddMvc();

        builder.Services.AddDbContext<AppDataBaseContent>(options => options.UseSqlServer(connection));
        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.MapGet("/", (AppDataBaseContent db) => db.BugPriority.ToList());

        app.UseDeveloperExceptionPage();
        app.UseStatusCodePages();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        //DBObjects.Initial(builder)
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        //app.MapGet()
        app.Run();
    }
}