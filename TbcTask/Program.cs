using Microsoft.EntityFrameworkCore;
using TbcTask;
using TbcTask.Interfaces;
using TbcTask.Mapping;
using TbcTask.Models.ActivityModels;
using TbcTask.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IMapper<TbcTask.Entities.Person, TbcTask.Models.PersonModel>, PersonMapper>();


builder.Services.AddScoped<IActivityService, ActivityService>();

builder.Services.AddDbContext<TbcTaskContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("TbcTask")));
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
