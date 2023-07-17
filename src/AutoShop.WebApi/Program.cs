using AutoShop.DataAccess.Interfaces.Cars;
using AutoShop.DataAccess.Interfaces.Categories;
using AutoShop.DataAccess.Interfaces.Users;
using AutoShop.DataAccess.Repositories.Cars;
using AutoShop.DataAccess.Repositories.Categories;
using AutoShop.DataAccess.Repositories.Users;
using AutoShop.Service.Interfaces.Cars;
using AutoShop.Service.Interfaces.Categories;
using AutoShop.Service.Interfaces.Common;
using AutoShop.Service.Interfaces.Users;
using AutoShop.Service.Services.Cars;
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

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();

//shohruh akadan ogan cors faylm
builder.Services.AddCors(option =>
{
    option.AddPolicy("MyPolicy", config =>
    {
        config.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
// shu yerda tugadi

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//cors ni middlewaredan choqirilgan joyi
app.UseCors("MyPolicy");
//bu yerda esa tugagan
app.UseHttpsRedirection();


app.UseStaticFiles();
app.UseRouting(); 
app.UseAuthorization();
app.MapControllers();



app.Run();


