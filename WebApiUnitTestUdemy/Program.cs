using Microsoft.EntityFrameworkCore;
using WebApiUnitTestUdemy.DataContext;
using WebApiUnitTestUdemy.Repositories.Abstract;
using WebApiUnitTestUdemy.Repositories.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(b => b.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
