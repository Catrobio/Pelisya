using Business.Mappers;
using Business.UsuariosBusinnes;
using Business.UserAccountBusiness;
using Business.CategoriasBusiness;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

string CorsPolicy = "ApiCors";

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//Iyeccion de dependencia 
builder.Services.AddScoped<IUsuariosBusiness, UsuariosBusiness>();
builder.Services.AddScoped<IUserAccountBusiness, UserAccountBusiness>();
builder.Services.AddScoped<ICategoriasBusiness, CategoriasBusiness>();


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
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Configuration.AddJsonFile("appsettings.json");
//var secretKey = builder.Configuration.GetSection("settings").GetSection("secretKey").ToString();// "=Codig0Estudiant3=";
var keyBytes = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");

builder.Services.AddAuthentication(config => {

        config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(config => {
        config.RequireHttpsMetadata = false;
        config.SaveToken = false;
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateIssuer = false,
            ValidateAudience = false
        };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Implementamos la politica de CORS
app.UseCors("ApiCors");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
