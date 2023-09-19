using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PizzeriaDb.Models;

public class PizzaIngredient : IDbRelationship
{
    [Key]
    public int Id { get; set; }
    [NotNull]
    public virtual Ingredient? Ingredient { get; set; }
    public double Units { get; set; }
}