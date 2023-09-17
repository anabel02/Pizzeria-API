using PizzeriaApi.DTOs;
using PizzeriaApi.Exceptions;
using PizzeriaApi.Utils;
using PizzeriaDb;
using PizzeriaDb.Models;

namespace PizzeriaApi.Services;

public class IngredientService : IIngredientService
{
    private readonly IMapper<IngredientDto, Ingredient> _ingredientMapper;
    private readonly PizzeriaContext _pizzeriaContext;

    public IngredientService(IMapper<IngredientDto, Ingredient> ingredientMapper, PizzeriaContext pizzeriaContext)
    {
        _ingredientMapper = ingredientMapper;
        _pizzeriaContext = pizzeriaContext;
    }

    public Task<IEnumerable<IngredientDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IngredientDto> GetById(int id) => _pizzeriaContext.Ingredients?.FindAsync(id).Result switch
    {
        null => throw new NotFoundException($"Ingredient with id {id} not found"),
        var ingredient => Task.FromResult(_ingredientMapper.Map(ingredient))
    };

    public async Task<bool> Create(IngredientDto ingredient) 
    {
        await _pizzeriaContext.AddAsync(_ingredientMapper.Map(ingredient));
        return await _pizzeriaContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modify(int id, IngredientDto ingredientDto)
    {
        var ingredient = _pizzeriaContext.Ingredients?.FindAsync(id).Result ?? _ingredientMapper.Map(ingredientDto);
        ingredient.Name = ingredientDto.Name;
        _pizzeriaContext.Ingredients?.Update(ingredient);
        return await _pizzeriaContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var ingredient = _pizzeriaContext.Ingredients?.FindAsync(id).Result;
        if (ingredient is null)
        {
            return false;
        }
        _pizzeriaContext.Ingredients?.Remove(ingredient);
        return await _pizzeriaContext.SaveChangesAsync() > 0;
    }
    
    public IEnumerable<Ingredient?> GetIngredientsById(IEnumerable<int> ids) => 
        ids.Select(id => _pizzeriaContext.Ingredients?.FindAsync(id).Result).Where(ingredient => ingredient is not null);
}