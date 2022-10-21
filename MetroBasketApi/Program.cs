using MetroBasketApi.Dapper.Interfaces;
using MetroBasketApi.Data;
using MetroBasketApi.Services;
using MetroBasketApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBasketService, BasketService>();
builder.Services.AddTransient<IBasketRepository, BasketRespository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
