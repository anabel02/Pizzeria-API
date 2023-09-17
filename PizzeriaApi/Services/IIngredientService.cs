using PizzeriaApi.DTOs;
using PizzeriaDb.Models;

namespace PizzeriaApi.Services;

public interface IIngredientService : ICrudService<IngredientDto>
{
    IEnumerable<Ingredient?> GetIngredientsById(IEnumerable<int> ids);
}