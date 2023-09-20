using PracticaInyeccionDependencias.Datos;
using PracticaInyeccionDependencias.Datos.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.Add(new ServiceDescriptor(
                typeof(IServiceCiudades),
                typeof(ServiceCiudades),
                ServiceLifetime.Transient
            ));

//Forma abreviada y recomendada para a�adir servicio
builder.Services.AddTransient<IServiceCiudades, ServiceCiudades>();//hace la misma funcionalidad que tenemos arriba
builder.Services.AddSingleton<IServiceCiudades, ServiceCiudades>();
builder.Services.AddScoped<IServiceCiudades, ServiceCiudades>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
