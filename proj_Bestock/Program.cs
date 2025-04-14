using Microsoft.EntityFrameworkCore;
using proj_Bestock.Data;
using proj_Bestock.Data.Repositories;
using proj_Bestock.Services;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAuthentication("MiCookieAuth")
    .AddCookie("MiCookieAuth", options =>
    {
        options.LoginPath = "/Cuenta/Login";
        options.LogoutPath = "/Cuenta/Logout";
        options.AccessDeniedPath = "/Cuenta/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
        options.SlidingExpiration = false;

        options.Events = new CookieAuthenticationEvents
        {
            OnValidatePrincipal = context =>
            {
                var expire = context.Properties.ExpiresUtc;
                if (expire.HasValue && expire.Value < DateTimeOffset.UtcNow)
                {
                    context.RejectPrincipal();
                }
                return Task.CompletedTask;
            }
        };
    });


//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Cuenta/Login"; // ruta a tu login
//        options.LogoutPath = "/Cuenta/Logout"; // si tenés logout
//        options.AccessDeniedPath = "/Cuenta/AccessDenied"; // opcional
//        options.ExpireTimeSpan = TimeSpan.FromMinutes(20); // igual que tu session
//        options.SlidingExpiration = true; // renueva tiempo activo si el usuario sigue interactuando
//    });


//Repositorios
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<TiendaRepository>();
//Servicios
builder.Services.AddScoped<AutenticaService>();
builder.Services.AddScoped<MenuService>();
builder.Services.AddScoped<TiendaService>();
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();       // Para HttpContext.Session
app.UseAuthentication(); // Para User.Identity
app.UseAuthorization();  // Para autorización

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cuenta}/{action=Login}/{id?}");

app.Run();
