using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Pizzeria_DB.Models;

public class PizzaIngredient : IDbRelationship
{
    public PizzaIngredient()
    {
    }

    public PizzaIngredient(int id, Pizza? pizza, Ingredient? ingredient, int units)
    {
        Id = id;
        Pizza = pizza;
        Ingredient = ingredient;
        Units = units;
    }

    [Key]
    public int Id { get; set; }
    [NotNull]
    public virtual Pizza? Pizza { get; set; }
    [NotNull]
    public virtual Ingredient? Ingredient { get; set; }    
    public int Units { get; set; }
}