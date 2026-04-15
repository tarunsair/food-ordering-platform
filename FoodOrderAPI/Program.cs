using FoodMenuRepoInterface;
using FoodMenuSerInterface;
using FoodMenuRepoImplementation;
using FoodMenuSerImplementation;
using FoodMenuDbFile;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// db context
builder.Services.AddDbContext<FoodMenuDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the FoodMenuRepo as a service
builder.Services.AddScoped<IFoodMenuRepo, FoodMenuRepo>();
// Register the FoodMenuSer as a service
builder.Services.AddScoped<IFoodMenuSer, FoodMenuSer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();