using PizzeriaDb.Models;

namespace PizzeriaApi.DTOs;

public class PizzaDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public Size Size { get; set; } = Size.Medium;

    public IEnumerable<int>? Ingredients { get; set; }
}