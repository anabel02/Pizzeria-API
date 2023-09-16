using PizzeriaApi.DTOs;
using PizzeriaDb.Models;

namespace PizzeriaApi.Utils;

public class IngredientMapper : IMapper<IngredientDto, Ingredient>
{
    public IngredientDto Map(Ingredient entity) => new IngredientDto { Id = entity.Id, Name = entity.Name };

    public Ingredient Map(IngredientDto dto) => new Ingredient { Name = dto.Name };
}