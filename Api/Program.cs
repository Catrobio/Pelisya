using Business.Mappers;
using Business.UsuariosBusinnes;
using Business.UserAccountBusiness;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Iyeccion de dependencia 
builder.Services.AddScoped<IUsuariosBusiness, UsuariosBusiness>();
builder.Services.AddScoped<IUserAccountBusiness, UserAccountBusiness>();
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
