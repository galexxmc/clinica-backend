using ClinicaBackend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Servicios básicos
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swagger Clásico

// 2. Base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// 4. Configurar Swagger (SIN el IF de Development para asegurar que lo veas)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinica API V1");
    c.RoutePrefix = "swagger"; // Esto hace que la url sea /swagger
});

app.UseHttpsRedirection();
app.UseCors("AllowReact");
app.UseAuthorization();

// 5. Mapear controladores
app.MapControllers();

app.Run();