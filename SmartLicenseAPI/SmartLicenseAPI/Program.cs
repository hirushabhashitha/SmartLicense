using Microsoft.EntityFrameworkCore;
using SmartLicenseAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins(
                      "http://localhost:5173",
                      "https://localhost:5173"
                  ) // Allow both HTTP and HTTPS Vite dev server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// ✅ Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 28)))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Use Swagger only in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Disabled for HTTP development

// ✅ USE CORS HERE BEFORE AUTHORIZATION
app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
