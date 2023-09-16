using Pizzeria_API.DTOs;

namespace Pizzeria_API.Services;

public interface IPizzaService
{
    public IEnumerable<PizzaDto> GetAll();
    public PizzaDto GetById(int id);
    public void Create(PizzaDto pizza);
    public void Modify(PizzaDto pizza);
    public void Delete(int id);
}
