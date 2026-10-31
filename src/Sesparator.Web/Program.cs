using Microsoft.EntityFrameworkCore;
using Sesparator.Web.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Sesparator.Web.Models;
using Sesparator.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VarsayilanBaglanti")));

builder.Services.AddIdentity<Kullanici, IdentityRole>(o =>
    {
        o.Password.RequiredLength = 8;
        o.User.RequireUniqueEmail = true;
        o.Lockout.MaxFailedAccessAttempts = 5;
    })
    .AddEntityFrameworkStores<UygulamaDbContext>()
    .AddDefaultTokenProviders();

// Web: çerez (cookie) ile oturum
builder.Services.ConfigureApplicationCookie(o =>
{
    o.LoginPath = "/Oturum/Giris";
    o.LogoutPath = "/Oturum/Cikis";
    o.AccessDeniedPath = "/Oturum/ErisimEngellendi";
    o.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    o.SlidingExpiration = true;
});

// Mobil: JWT
var jwtAyar = builder.Configuration.GetSection("Jwt");
var jwtAnahtar = jwtAyar["Anahtar"]
    ?? throw new InvalidOperationException("Jwt:Anahtar ayarlanmamış (Manage User Secrets).");

builder.Services.AddAuthentication()   // varsayılan şema Identity çerezi olarak kalır
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
    {
        o.MapInboundClaims = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtAyar["Yayinci"],
            ValidateAudience = true,
            ValidAudience = jwtAyar["Hedef"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAnahtar)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(1)
        };
    });

builder.Services.AddScoped<JwtServisi>();


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

app.UseAuthentication();    

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
