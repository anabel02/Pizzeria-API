using Microsoft.EntityFrameworkCore;
using PizzeriaDb.Models;

namespace PizzeriaDb;

public sealed class PizzeriaContext : DbContext
{
    public DbSet<Pizza>? Pizzas { get; set; }
    public DbSet<Ingredient>? Ingredients { get; set; }

    public PizzeriaContext(DbContextOptions<PizzeriaContext> options) : base(options) {}
}