using AplicacionWebAuroraBoutique.DA;  // <-- Agregas esta l�nea
using Microsoft.EntityFrameworkCore;   // <-- Esta la ocuparemos luego para el DbContext

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Aqu� es donde inyectamos la cadena de conexi�n
DbConfig.ConnString = builder.Configuration
    .GetConnectionString("PostgresConnection")!;

// Por ahora a�n no agregamos el DbContext (eso lo hacemos en el siguiente paso)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

