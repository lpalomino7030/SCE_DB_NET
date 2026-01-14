using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using SCE_DB_NET.Data;
using SCE_DB_NET.Respository.DAO;
using SCE_DB_NET.Respository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 1. Servicios base del framework
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// 2. Inyección de dependencias (Infraestructura)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IEmpresa, EmpresaDAO>();

// 3. Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// 4. Aplicar CORS (antes del pipeline de controllers)
app.UseCors("AllowAll");

// 5. Ejecutar migraciones automáticas (opcional pero útil)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (dbContext.Database.IsRelational())
    {
        dbContext.Database.Migrate();
    }
}

// 6. Configuración de middlewares HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 7. Endpoints
app.MapControllers();

// 8. Ejecutar aplicación
app.Run();


//host
//https://localhost:7178/swagger/index.html