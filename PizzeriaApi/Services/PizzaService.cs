using Pizzeria_API.DTOs;
using Pizzeria_DB;

namespace Pizzeria_API.Services;

public class PizzaService : IPizzaService
{
    private readonly PizzeriaContext _pizzeriaContext;

    public PizzaService(PizzeriaContext pizzeriaContext)
    {
        _pizzeriaContext = pizzeriaContext;
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