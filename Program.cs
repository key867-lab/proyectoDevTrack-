using DevTrack.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// Un único repositorio en memoria (con persistencia JSON) para toda la app.
builder.Services.AddSingleton<RepositorioDevTrack>();
// Repositorio del seguimiento: cola de QA, pila de deshacer, historial y observaciones.
builder.Services.AddSingleton<RepositorioSeguimiento>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
