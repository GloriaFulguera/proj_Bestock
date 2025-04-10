using Microsoft.EntityFrameworkCore;
using proj_Bestock.Data;
using proj_Bestock.Data.Repositories;
using proj_Bestock.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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
