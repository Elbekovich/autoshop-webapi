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
builder.Services.AddEndpointsApiExplorer(); // buni tushunmadim
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
// cors bu frontdan backendga ulanish
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//        policy =>
//        {
//            policy.WithOrigins("http://localhost",
//                "http://localhost:4200",
//                "https://localhost:7230",
//                "http://localhost:90"
//                )
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .SetIsOriginAllowedToAllowWildcardSubdomains();
//        });
//});

// Default Policy
// Named Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:44351", "http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
//bu yerda ulanish tugadi agar dastur xato ishlasa buni ochiraman
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseStaticFiles();
app.UseRouting(); //buni uzim qushdim
//app.UseCors(MyAllowSpecificOrigins);
//app.UseCors();
// with a named pocili
app.UseCors("AllowOrigin");
app.UseAuthorization();
app.MapControllers();



app.Run();


