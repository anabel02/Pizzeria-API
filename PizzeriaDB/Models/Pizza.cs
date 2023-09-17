using System.ComponentModel.DataAnnotations;

namespace PizzeriaDb.Models;
public enum Size {Small, Medium, Large}

public class Pizza : IDbEntity
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public Size Size { get; set; } = Size.Medium;
    
    public virtual IEnumerable<PizzaIngredient>? Ingredients { get; set; }
}