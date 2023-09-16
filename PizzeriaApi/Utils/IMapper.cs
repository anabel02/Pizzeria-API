using PizzeriaApi.DTOs;
using PizzeriaDb.Models;

namespace PizzeriaApi.Utils;

public interface IMapper<TDto, T> 
    where TDto : IDto
    where T : IDbEntity
{
    TDto Map(T entity);
    T Map(TDto dto);
}