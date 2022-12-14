using back.db;
using Microsoft.EntityFrameworkCore;
using back.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductRepository, ProdutoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


builder.Services.AddDbContext<UsuarioContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase")));

builder.Services.AddDbContext<ProductContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase")));    
var app = builder.Build();

#region [Cors]
builder.Services.AddCors();
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region [Cors]
    app.UseCors(c =>
    {
        c.AllowAnyHeader();
        c.AllowAnyMethod();
        c.AllowAnyOrigin();
    });
#endregion
app.UseAuthorization();

app.MapControllers(); 

app.Run();
