using Microsoft.EntityFrameworkCore;
using PizzeriaApi.DTOs;
using PizzeriaApi.Services;
using PizzeriaApi.Utils;
using PizzeriaDb;
using PizzeriaDb.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PizzeriaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PizzeriaContextSQLite")));

builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IMapper<IngredientDto, Ingredient>, IngredientMapper>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
} 
else
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<PizzeriaContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();