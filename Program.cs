using BugTracker.Data;
using BugTracker.Data.Interfaces;
using BugTracker.Data.Models;
using BugTracker.Data.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
internal class Program
{
    private static void Main(string[] args)
    {
        var people = new List<Person>
        {
            new Person(Guid.NewGuid(),"tom@gmail.com", "12345"),
            new Person(Guid.NewGuid(), "bob@gmail.com", "55555")
        };
        var builder = WebApplication.CreateBuilder(args);
        string connection = builder.Configuration.GetConnectionString("DefaultConnection");

        IServiceCollection services = builder.Services;
        services.AddTransient<IBugs, BugsRepository>();
        services.AddTransient<IBugPriority, BugPriorityRepository>();
        services.AddMvc();
        services.AddAuthentication("Cookies");
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/login");
        services.AddAuthorization();
        /*       services.AddAuthorization();
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
        app.MapGet("/login", async (HttpContext context) =>
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            // html-форма для ввода логина/пароля
            string loginForm = @"<!DOCTYPE html>
            <html>
            <head>
                <meta charset='utf-8' />
                <title>METANIT.COM</title>
            </head>
            <body>
                <h2>Login Form</h2>
                <form method='post'>
                    <p>
                        <label>Email</label><br />
                        <input name='email' />
                    </p>
                    <p>
                        <label>Password</label><br />
                        <input type='password' name='password' />
                    </p>
                    <input type='submit' value='Login' />
                </form>
            </body>
            </html>";
            await context.Response.WriteAsync(loginForm);
        });
        /*app.MapPost("/login", async (string? returnUrl, HttpContext context) =>
        {
            // получаем из формы email и пароль
            var form = context.Request.Form;
            // если email и/или пароль не установлены, посылаем статусный код ошибки 400
            if (!form.ContainsKey("email") || !form.ContainsKey("password"))
                return Results.BadRequest("Email и/или пароль не установлены");

            string email = form["email"];
            string password = form["password"];

            // находим пользователя 
            //Person? person = people.FirstOrDefault(p => p.Login == email && p.Password == password);
            // если пользователь не найден, отправляем статусный код 401
            //if (person is null) return Results.Unauthorized();

            //var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };
            // создаем объект ClaimsIdentity
            //ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            // установка аутентификационных куки
            //await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            //return Results.Redirect(returnUrl ?? "/");
        });*/

        app.MapGet("/logout", async (HttpContext context) =>
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Results.Redirect("/login");
        });
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