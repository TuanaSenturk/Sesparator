using Microsoft.EntityFrameworkCore;
using Sesparator.Web.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Sesparator.Web.Models;
using Sesparator.Web.Services;
using Microsoft.OpenApi;    

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

// STT/TTS: Gemini (anahtar: Gemini:ApiAnahtari, Manage User Secrets)
builder.Services.AddHttpClient<ISesServisi, GeminiSesServisi>(c => c.Timeout = TimeSpan.FromSeconds(30));

builder.Services.AddScoped<KayitliAliciDogrulayici>(); /* Dependency injection’a “controller bu servisi istediğinde her 
istek için bir tane oluştur” der. Bu satır olmadan controller’ın constructor’ı servisi alamaz.
*/

builder.Services.AddSwaggerGen(c =>
{
// Controller’lara bakarak API’nin tanımını (OpenAPI dokümanı) çıkarır.
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sesparator API",
        Version = "v1",
        Description = "Token almak için önce POST /api/oturum/giris çağırın."
    });

/* Swagger sayfasına Authorize butonu ekler. Token’ı bir kez yapıştırırsın, tüm isteklere eklenir. 
API’n JWT istediği için bu olmadan Swagger’dan yapılan her istek 401 döner.
*/
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Sadece token'ı yapıştırın (başına 'Bearer' yazmayın)."
    });
    c.AddSecurityRequirement(belge => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", belge)] = []
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();

}
// Swagger sadece geliştirme ortamında açılır. Canlı ortamda API yapısının herkese görünmesi istenmez.
else
{
    app.UseSwagger();
    app.UseSwaggerUI(o => o.DocumentTitle = "Sesparator API");
}

app.UseRouting();

app.UseAuthentication();    

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
