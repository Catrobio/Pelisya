using Business.Mappers;
using Business.UsuariosBusinnes;
using Business.UserAccountBusiness;
using Business.CategoriasBusiness;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "apibirras", Version = "v1" });
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Seguraridad basada en token. Ingresar Bearer seguido del token obtenido en el authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
                    {
                        {securityScheme, new string[] { }}
                    };

    c.AddSecurityRequirement(securityRequirement);
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ"))
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
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
