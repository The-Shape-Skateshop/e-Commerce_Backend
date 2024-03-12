using e_Commerce.API.Config.ExtensionMethods;
using e_Commerce.API.Config.Filters;
using e_Commerce.API.Config.TratadoresErros;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.ConfigurarValidacao();

//============== Logs =================
builder.Services.ConfigurarSerilog(builder.Logging);
//=====================================

//============= Mappers ===============
//builder.Services.ConfigurarAutoMapper();
//=====================================

//============ Extension ==============
builder.Services.ConfigurarSwaggerExtension();
builder.Services.ConfigurarInjecaoDependencia(builder.Configuration);
//=====================================

//== Controllers, Filtros e Exceções ==
builder.Services.AddControllers(config =>
{
    config.Filters.Add<LogActionFilter>();
});

var app = builder.Build();

app.UseMiddleware<ManipuladorExcecoes>();
//=====================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
