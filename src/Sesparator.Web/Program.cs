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

// controllerın çalışması ve html döndürmesini sağlar.
builder.Services.AddControllersWithViews();


/* AddDbContext-> DbContexti servis olarak kaydeder. controller ya da servis yapıcısında 
 UygulamaDbContext db istediğinde, ASP.NET Core nesneyi kendisi oluşturup verir; senin new yazman gerekmez.*/
builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VarsayilanBaglanti"))); // UygulamaDbContext istenirse, SQL Server ve şu bağlantı cümlesiyle oluştur

builder.Services.AddIdentity<Kullanici, IdentityRole>(o =>
    {
        o.Password.RequiredLength = 8;
        o.User.RequireUniqueEmail = true;
        o.Lockout.MaxFailedAccessAttempts = 5;
    })
    .AddEntityFrameworkStores<UygulamaDbContext>() //kullanıcıları ve rolleri EF Core ile UygulamaDbContext üzerinden saklamasını söyler.
    .AddDefaultTokenProviders();//güvenlik kodları üretme yeteneği->şifremi unuttum, e-posta doğrulama

// Web: çerez (cookie) ile oturum
builder.Services.ConfigureApplicationCookie(o =>
{
    o.LoginPath = "/Oturum/Giris"; // kullanıcı giriş yapmamışsa yönlendirileceği sayfa
    o.LogoutPath = "/Oturum/Cikis"; // kullanıcı çıkış yapınca yönlendirileceği sayfa
    o.AccessDeniedPath = "/Oturum/ErisimEngellendi";// kullanıcı yetkisiz sayfaya girmeye çalışırsa yönlendirileceği sayfa
    o.ExpireTimeSpan = TimeSpan.FromMinutes(30); 
    o.SlidingExpiration = true; //kullanıcı işlem yaptıkça süre yenilenir. 30 dk boyunca işlem yapmazsa oturum kapanır.
});

// Mobil: JWT
var jwtAyar = builder.Configuration.GetSection("Jwt"); //appsettings.jsondaki jwt ayarlarını alır. 
var jwtAnahtar = jwtAyar["Anahtar"]
    ?? throw new InvalidOperationException("Jwt:Anahtar ayarlanmamış (Manage User Secrets).");

builder.Services.AddAuthentication()   //Bu satır sunucuya, kullanıcıyı çerez dışında bir yolla da tanımayı öğretir: JWT token ile.
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

// Servisleri DI'a kaydet. controller ya da başka servisler constructorlarında bu servisleri isterse, ASP.NET Core nesneyi kendisi oluşturup verir; senin new yazman gerekmez.

builder.Services.AddScoped<JwtServisi>(); 

// STT/TTS: Gemini (anahtar: Gemini:ApiAnahtari, Manage User Secrets)
builder.Services.AddHttpClient<ISesServisi, GeminiSesServisi>(c => c.Timeout = TimeSpan.FromSeconds(30));
// Asistan: Gemini ile niyet çıkarma + sunucu tarafı kontroller
builder.Services.AddHttpClient<INiyetServisi, GeminiNiyetServisi>(c => c.Timeout = TimeSpan.FromSeconds(15));
builder.Services.AddScoped<BankaIslemServisi>();
builder.Services.AddScoped<AsistanServisi>();
builder.Services.AddScoped<KayitliAliciDogrulayici>(); 


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

// adres eşlenir
app.UseRouting();

// kullanıcı tanınır
app.UseAuthentication();    

//  kullanıcının yetkisi kontrol edilir
app.UseAuthorization();

// wwwroot altındaki statik dosyalar (css, js, resim) sunulur
app.MapStaticAssets();

/* Adresleri controller'lara bağlar. {controller=Home}/{action=Index}/{id?} şablonuna göre /Hesap/Detay/5 adresini HesapController.Detay(5)'e
 gönderir. Parçalar yazılmazsa varsayılanlar devreye girer: / adresi HomeController.Index()'e gider, id ise isteğe bağlıdır.*/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
