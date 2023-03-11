using Main.Data.Context;
using Main.IoC;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

//below part added by me!

builder.Services.AddDbContext<EshopContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#region login

builder.Services.AddAuthentication(Options =>
{
    Options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    Options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    Options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;



}).AddCookie(Options =>
{
    Options.LoginPath = "/Login";
    Options.LogoutPath = "/logout";
    Options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
});

#endregion

DependencyContainers.RegisterServices(builder.Services);//related to IoC


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
ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//by me!----> these are middlewares!
app.UseAuthentication();
app.UseAuthorization();

//Area_Admin_ScaffoldingReadMe
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
