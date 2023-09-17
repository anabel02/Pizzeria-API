using Microsoft.AspNetCore.Mvc;
using PizzeriaApi.DTOs;
using PizzeriaApi.Exceptions;
using PizzeriaApi.Services;

namespace PizzeriaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            return Ok(await _ingredientService.GetById(id));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(IngredientDto ingredient) =>
        await _ingredientService.Create(ingredient) ? Ok() : BadRequest();
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, IngredientDto ingredient) => 
        await _ingredientService.Modify(id, ingredient) ? Ok() : BadRequest();
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) => await _ingredientService.Delete(id) ? Ok() : BadRequest();
}