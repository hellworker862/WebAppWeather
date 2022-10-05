using Microsoft.EntityFrameworkCore;
using WebAppWeather;
using WebAppWeather.Controllers;
using WebAppWeather.Controllers.Interfaces;
using WebAppWeather.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<HttpClient>();
builder.Services.AddScoped<WeathersService>();
builder.Services.AddScoped<IWeathersController, WeathersController>();

var app = builder.Build();

//app.UseSwagger();
//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//    options.RoutePrefix = string.Empty;
//});

app.UseRouting();
app.UseHsts();
app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // подключаем маршрутизацию на контроллеры
});


app.Run();

