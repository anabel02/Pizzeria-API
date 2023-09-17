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
        Size = (DTOs.Size) entity.Size,
        Ingredients = entity.Ingredients?.Select(ingredient => (ingredient.Ingredient.Id, ingredient.Units)) 
                      ?? Enumerable.Empty<(int IngredientId, decimal Units)>()
    };

    public Pizza Map(PizzaDto dto)
    {
        var pizza = new Pizza
        {
            Id = dto.Id,
            Name = dto.Name,
            Price = dto.Price,
            Size = (PizzeriaDb.Models.Size)dto.Size
        };

        pizza.Ingredients = (ICollection<PizzaIngredient>?)(dto.Ingredients is not null ?
            dto.Ingredients.Select(ingredient => new PizzaIngredient
            {
                Pizza = pizza,
                Ingredient = _pizzeriaContext.Ingredients?.Find(ingredient.IngredientId),
                Units = ingredient.Units
            }).Where(pizzaIngredient => pizzaIngredient is
            {
                Ingredient: not null,
                Units: > 0
            })
            : Enumerable.Empty<PizzaIngredient>());
        
        return pizza;

    }
}