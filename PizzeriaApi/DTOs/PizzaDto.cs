using Pizzeria_DB.Models;

namespace Pizzeria_API.DTOs;

public class PizzaDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public Size Size { get; set; } = Size.Medium;

    public IEnumerable<int>? Ingredients { get; set; }
}