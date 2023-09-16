using Microsoft.AspNetCore.Mvc;
using PizzeriaApi.DTOs;
using PizzeriaApi.Services;

namespace PizzeriaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService _pizzaService;
    
    public PizzaController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpGet]
    [Route("/{id:int}")]
    public PizzaDto GetById(int id) => _pizzaService.GetById(id);
    
    [HttpGet]
    public IEnumerable<PizzaDto> GetAll() => _pizzaService.GetAll();
    
    [HttpPost]
    public ActionResult Post(PizzaDto pizza) 
    {
        _pizzaService.Create(pizza);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Put(PizzaDto pizza) 
    {
        _pizzaService.Modify(pizza);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(int id) 
    {
        _pizzaService.Delete(id);
        return Ok();
    }
}