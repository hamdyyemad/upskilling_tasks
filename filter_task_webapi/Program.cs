using Microsoft.EntityFrameworkCore;
using filter_task_webapi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();


if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();


app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();