using ConsultorioMedico.Data;
using ConsultorioMedico.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Obter a string de conexão
var connectionString = builder.Configuration.GetConnectionString("conexao") ?? throw new InvalidOperationException("Connection string 'conexao' not found.");

// Registrar o Contexto para os dados de domínio
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(connectionString));

// Registrar o ApplicationDbContext para o Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configurar o Identity para usar o ApplicationDbContext
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>(); // Usar o ApplicationDbContext para o Identity

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
