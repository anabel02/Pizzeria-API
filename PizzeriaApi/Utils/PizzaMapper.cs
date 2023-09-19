using PizzeriaApi.DTOs;
using PizzeriaDb;
using PizzeriaDb.Models;

namespace PizzeriaApi.Utils;

public class PizzaMapper : IMapper<PizzaDto, Pizza>
{

    private readonly PizzeriaContext _pizzeriaContext;

    public PizzaMapper(PizzeriaContext pizzeriaContext)
    {
        _pizzeriaContext = pizzeriaContext;
    }

    public PizzaDto Map(Pizza entity) => new PizzaDto
    {
        Id = entity.Id,
        Name = entity.Name,
        Price = entity.Price,
        Size = (DTOs.Size)entity.Size,
        Ingredients = entity.Ingredients?.Select(ingredient => new PizzaIngredientDto()
                      {
                          IngredientId = ingredient.Ingredient.Id,
                          Units = ingredient.Units
                      })
                      ?? Enumerable.Empty<PizzaIngredientDto>()
    };

    private static bool ContainsId(IEnumerable<PizzaIngredientDto> pizzas, int id) =>
        pizzas.Select(i => i.IngredientId).Any(i => i == id);
    
    public Pizza Map(PizzaDto dto)
    {
        var ingredients = _pizzeriaContext.Ingredients?.ToDictionary(ingredient => ingredient.Id)
            .Where(ingredient => ContainsId(dto.Ingredients!, ingredient.Key))
            .Select(ing => ing.Value);
        
        return new Pizza
        {

            Id = dto.Id,
            Name = dto.Name,
            Price = dto.Price,
            Size = (PizzeriaDb.Models.Size)dto.Size,
            Ingredients = dto.Ingredients?.Select(ingredient => new PizzaIngredient
                {
                    Ingredient = ingredients?.Where(i => i.Id == ingredient.IngredientId).First(),
                    Units = ingredient.Units
                }).Where(pizzaIngredient => pizzaIngredient is { Ingredient: not null }).ToList()
        };
    }
}