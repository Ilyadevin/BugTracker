using BugTracker.Data;
using BugTracker.Data.Interfaces;
using BugTracker.Data.Mocs;
using BugTracker.Data.Models;
using BugTracker.Data.Repository;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity;

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
/*        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // указывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = true,
                    // строка, представляющая издателя
                    ValidIssuer = AuthenticationOptions.ISSUER,
                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,
                    // установка потребителя токена
                    ValidAudience = AuthOptions.AUDIENCE,
                    // будет ли валидироваться время существования
                    ValidateLifetime = true,
                    // установка ключа безопасности
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true,
                };
            });*/
        
    

        builder.Services.AddDbContext<AppDataBaseContent>(options => options.UseSqlServer(connection));
        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();
        app.UseDeveloperExceptionPage();
        app.UseStatusCodePages();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.MapGet("/Home", async(AppDataBaseContent db) => await db.Bugs.ToListAsync());
        app.MapGet("/Home/Bugs/List", async (Guid id, AppDataBaseContent db) =>
        {
            Bugs? bug = await db.Bugs.FirstOrDefaultAsync(u => u.Id == id);
            if (bug != null) return Results.NotFound(new { message = "Bugs are not found, all clear" });
            return Results.Json(bug);
        });
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        /*app.Run(async(context)=>
            {
            context.Response.ContentType = "text/html; charset=utf-8";

            
            if (context.Request.Path == "/Create")
            {
                var form = context.Request.Form;
                string name = form["Name"];
                string shortDescription = form["ShortDescription"];
                string longDescription = form["LongDescription"];
                string creationDate = form["CreationDate"];
                string isSolved = form["Description"];
                string priority = form["Priority"];
                    await context.Response.WriteAsync($"<div><input>Name{name}</input></div>" +
                        $"<div><input>ShortDescription{shortDescription}</input></div>" +
                        $"<div><textarea>LongDescription{longDescription}</textarea></div>" +
                        $"<div><input>CreationDate{creationDate}</input></div>" +
                        $"<div><input>IsSolved{isSolved}</input></div>" +
                        $"<div><span><select>Priority{priority}</select></span></div>");
            }
            else
            {
                await context.Response.SendFileAsync("html/index.html");
            }
        });*/
        app.Run();

    }
}