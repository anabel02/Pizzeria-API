using PizzeriaApi.DTOs;
using PizzeriaDb.Models;

namespace PizzeriaApi.Utils;

public class IngredientMapper : IMapper<IngredientDto, Ingredient>
{
    public IngredientDto Map(Ingredient entity) => new() { Id = entity.Id, Name = entity.Name };

    public Ingredient Map(IngredientDto dto) => new() { Name = dto.Name };
}