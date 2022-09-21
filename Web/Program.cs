using Web.Helpers;

var builder = WebApplication.CreateBuilder(args);

//Configrar la sesion
builder.Services.AddSession(options => 
    {
        options.Cookie.Name = ".pelisya.session";
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.IsEssential = true;
    }    
);

//Inyeccion de dependencia
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddSingleton<SessionsHelpers>();
builder.Services.AddScoped<LocalStorageHelpers>();
builder.Services.AddSingleton<ActionHelpers>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
//Usar las sesiones
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
