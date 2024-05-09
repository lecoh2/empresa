using CompanyApp.Api.Configurations;
using CompanyApp.Domain.Interfaces.Repositories;
using CompanyApp.Domain.Interfaces.Services;
using CompanyApp.Domain.Services;
using CompanyApp.Infa.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
SwaggerConfiguration.Configure(builder.Services);
CorsConfiguration.Configure(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddEndpointsApiExplorer();
///builder.Services.AddSwaggerGen();


//registrar as injeções de dependencia do sistema para cada dominio

builder.Services.AddTransient<IEmpresaDomainService, EmpresaDomainService>();
builder.Services.AddTransient<IFuncionarioDomainService, FuncionarioDomainService>();

//registrar as injeções de dependencia do sistema pra cada camada de repositorio

builder.Services.AddTransient<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
//adiconando a politica
app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();

public partial class Program { }
