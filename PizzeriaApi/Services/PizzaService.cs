using PizzeriaApi.DTOs;
using PizzeriaApi.Utils;
using PizzeriaDb;
using PizzeriaDb.Models;

namespace PizzeriaApi.Services;

public class PizzaService : IPizzaService
{
    private readonly PizzeriaContext _pizzeriaContext;
    private readonly IMapper<PizzaDto, Pizza> _pizzaMapper;
    private readonly IMapper<IngredientDto, Ingredient> _ingredientMapper;

    public PizzaService(PizzeriaContext pizzeriaContext,
                        IMapper<PizzaDto, Pizza> pizzaMapper, 
                        IMapper<IngredientDto, Ingredient> ingredientMapper)
    {
        _pizzeriaContext = pizzeriaContext;
        _pizzaMapper = pizzaMapper;
        _ingredientMapper = ingredientMapper;
    }
    
    public IEnumerable<PizzaDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public PizzaDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Create(PizzaDto pizza)
    {
        throw new NotImplementedException();
    }

    public void Modify(PizzaDto pizza)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
} 