using BusinessAccessLayer.Service;
using AutoMapper;
using PresentationLayer.Handler;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//AutoMapper Configuration
var autoMapper = new MapperConfiguration((item)=>
{
    item.AddProfile(new StockHandler());
    item.AddProfile(new FilterHandler());
});
IMapper mapper = autoMapper.CreateMapper();
string connectionString = builder.Configuration.GetConnectionString("default");
//Dependency Injection
builder.Services.AddSingleton<IStockService, StockService>();
builder.Services.AddSingleton<IStockRepository, StockRepository>();
builder.Services.AddSingleton<IMapper>(mapper);
builder.Services.AddSingleton(connectionString);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Swagger configuration
    app.UseSwagger();
    app.UseSwaggerUI();
    //swagger configuration ended
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();