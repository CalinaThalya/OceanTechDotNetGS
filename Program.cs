using OceanTechDotNetGS.Models;
using Microsoft.EntityFrameworkCore;
using OceanTechDotNetGS.Repository;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NomeDoSeuContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NomeDoSeuContexto") ?? throw new InvalidOperationException("Connection string 'NomeDoSeuContexto' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>(option =>
{
    option.UseOracle(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))
(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=rm552523;Password=120399;");
});

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IRegistroUsuarioRepository, RegistroUsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
