using System.ComponentModel.DataAnnotations;

namespace Pizzeria_DB.Models;

public class Ingredient : IDbEntity
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
}