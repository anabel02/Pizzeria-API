using PizzeriaApi.DTOs;
using PizzeriaDb.Models;

namespace PizzeriaApi.Services;

public interface ICrudService<TDto> where TDto : IDto
{
    public Task<IEnumerable<TDto>> GetAll();
    public Task<IngredientDto> GetById(int id);
    public Task<bool> Create(TDto pizza);
    public Task<bool> Modify(TDto pizza);
    public Task<bool> Delete(int id);
}