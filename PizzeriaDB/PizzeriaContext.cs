using Microsoft.EntityFrameworkCore;
using Pizzeria_DB.Models;

namespace Pizzeria_DB;

public sealed class PizzeriaContext : DbContext
{
    public DbSet<Pizza>? Pizzas { get; set; }
    public DbSet<Ingredient>? Ingredients { get; set; }
    public DbSet<PizzaIngredient>? PizzaIngredients { get; set; }

    public PizzeriaContext(DbContextOptions<PizzeriaContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}