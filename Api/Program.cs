using Business.Mappers;
using Business.UsuariosBusinnes;
using Business.UserAccountBusiness;
using Business.CategoriasBusiness;

string CorsPolicy = "ApiCors";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Iyeccion de dependencia 
builder.Services.AddScoped<IUsuariosBusiness, UsuariosBusiness>();
builder.Services.AddScoped<IUserAccountBusiness, UserAccountBusiness>();
builder.Services.AddScoped<ICategoriasBusiness, CategoriasBusiness>();
builder.Services.AddControllers();

//Añadimos la configuracion de CORS policy
builder.Services.AddCors(op =>
    op.AddPolicy(CorsPolicy,
        build =>
        {
            build.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        })
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Implementamos la politica de CORS
app.UseCors("ApiCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
