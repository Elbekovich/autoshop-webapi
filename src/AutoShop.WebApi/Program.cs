using AutoShop.DataAccess.Interfaces.Categories;
using AutoShop.DataAccess.Interfaces.Users;
using AutoShop.DataAccess.Repositories.Categories;
using AutoShop.DataAccess.Repositories.Users;
using AutoShop.Service.Interfaces.Categories;
using AutoShop.Service.Interfaces.Common;
using AutoShop.Service.Interfaces.Users;
using AutoShop.Service.Services.Categories;
using AutoShop.Service.Services.Common;
using AutoShop.Service.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


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
