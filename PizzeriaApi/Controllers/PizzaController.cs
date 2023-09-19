using Microsoft.AspNetCore.Mvc;
using PizzeriaApi.DTOs;
using PizzeriaApi.Exceptions;
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

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            return Ok(await _pizzaService.GetById(id));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet]
    public async IAsyncEnumerable<PizzaDto> Get()
    {
        await foreach (var pizza in _pizzaService.GetAll())
        {
            yield return pizza;
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(PizzaDto pizza) =>
        await _pizzaService.Create(pizza) ? Ok() : BadRequest();
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, PizzaDto pizza) => 
        await _pizzaService.Modify(id, pizza) ? Ok() : BadRequest();
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) => await _pizzaService.Delete(id) ? Ok() : BadRequest();
}