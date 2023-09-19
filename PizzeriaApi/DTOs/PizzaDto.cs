namespace PizzeriaApi.DTOs;

public enum Size {Small, Medium, Large}
public class PizzaDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public Size Size { get; set; } = Size.Medium;

    public IEnumerable<PizzaIngredientDto>? Ingredients { get; set; }
}