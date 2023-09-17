using PizzeriaApi.DTOs;

namespace PizzeriaApi.Services;

public interface ICrudService<TDto> where TDto : IDto
{
    public Task<IEnumerable<TDto>> GetAll();
    public Task<TDto> GetById(int id);
    public Task<bool> Create(TDto ingredient);
    public Task<bool> Modify(int id, TDto dto);
    public Task<bool> Delete(int id);
}