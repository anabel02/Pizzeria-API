namespace PizzeriaApi.DTOs;

public enum Size {Small, Medium, Large}
public class PizzaDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public Size Size { get; set; } = Size.Medium;

    public IEnumerable<(int IngredientId, decimal Units)>? Ingredients { get; set; }
}