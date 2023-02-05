using API_task;
using API_task.Services;
using API_task.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//INYECTANDO context
builder.Services.AddSqlServer<TareasContext>( builder.Configuration.GetConnectionString("DBConection") );

//INYECCION de dependencia
builder.Services.AddScoped<CreateDBController>();
builder.Services.AddScoped<IHellowWorldService, HellowWorldService>();
//INYECTANDO servicios como dependencias
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
