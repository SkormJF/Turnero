using Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TurneroContext>
    (options => options.UseMySql(builder.Configuration.GetConnectionString("Conexion"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.2-mysql")));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => 
{
    options.LoginPath = "/Asistentes/Login";
    options.LogoutPath = "/Asistentes/Logout";
    options.AccessDeniedPath = "/Asistentes/AccessDenied";
});

var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Cookies["LoggedOut"] == "true" && !context.Request.Path.Equals("/Asistentes/Login", StringComparison.OrdinalIgnoreCase))
    {
        context.Response.Cookies.Delete("LoggedOut");
        context.Response.Redirect("/Asistentes/Index");
        return;
    }

    await next();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
