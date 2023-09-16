namespace PizzeriaApi.DTOs;

public class IngredientDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
}