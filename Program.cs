using BugTracker.Data.Interfaces;
using BugTracker.Data.Mocs;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
services.AddTransient<IBugs, MockBugs>();
services.AddTransient<IBugPriority, MockBugPriority>();
services.AddMvc();
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
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();