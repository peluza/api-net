using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddNpgsql<TareasContext>("Host=localhost;Port=5432;Username=postgres;Password=Eisaza.123!;Database=TareasDB3");
// builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("cnHomeworks"));
builder.Services.AddScoped<IHelloWorldService, HelloworldService>();
builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();
builder.Services.AddScoped<ITareasServices, TareasServices>();
// builder.Services.AddScoped<IHelloWorldService>(p=> new HelloworldService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseWelcomePage();

// app.UseTimeMiddleware();

app.MapControllers();

app.Run();
