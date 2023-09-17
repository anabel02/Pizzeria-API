using PizzeriaApi.DTOs;
using PizzeriaApi.Exceptions;
using PizzeriaApi.Utils;
using PizzeriaDb;
using PizzeriaDb.Models;

namespace PizzeriaApi.Services;

public class PizzaService : IPizzaService
{
    private readonly PizzeriaContext _pizzeriaContext;
    private readonly IMapper<PizzaDto, Pizza> _pizzaMapper;

    public PizzaService(PizzeriaContext pizzeriaContext,
                        IMapper<PizzaDto, Pizza> pizzaMapper)
    {
        _pizzeriaContext = pizzeriaContext;
        _pizzaMapper = pizzaMapper;
    }

    public Task<IEnumerable<PizzaDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<PizzaDto> GetById(int id) => Task.FromResult(_pizzeriaContext.Pizzas?.FindAsync(id).Result switch
    {
        null => throw new NotFoundException($"Pizza with id {id} not found"),
        var pizza => _pizzaMapper.Map(pizza)
    });

    public async Task<bool> Create(PizzaDto ingredient)
    {
        await _pizzeriaContext.AddAsync(_pizzaMapper.Map(ingredient));
        return await _pizzeriaContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modify(int id, PizzaDto pizza)
    {
        var pizzaDb = _pizzeriaContext.Pizzas?.FindAsync(id).Result ?? _pizzaMapper.Map(pizza);
        
        pizzaDb.Name = pizza.Name;
        pizzaDb.Size = (PizzeriaDb.Models.Size)pizza.Size;
        pizzaDb.Price = pizza.Price;
        
        _pizzeriaContext.Pizzas?.Update(pizzaDb);
        return await _pizzeriaContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var pizza = _pizzeriaContext.Pizzas?.FindAsync(id).Result;
        if (pizza is null)
        {
            return false;
        }
        _pizzeriaContext.Pizzas?.Remove(pizza);
        return await _pizzeriaContext.SaveChangesAsync() > 0;
    }
} 