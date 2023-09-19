using PizzeriaDb.Models;

namespace PizzeriaDb;

public static class DbInitializer
{
    public static void Initialize(PizzeriaContext context)
    {
        
        if (context.Pizzas != null && context.Pizzas.Any() && context.Ingredients != null && context.Ingredients.Any())
        {
            return; // DB has been seeded
        }
        
        var ingredients = new Ingredient[]
        {
            new() { Name = "Cheese" },
            new() { Name = "Tomato sauce" },
            new() { Name = "Flour" },
            new() { Name = "Ham" },
            new() { Name = "Pineapple" },
            new() { Name = "Mushrooms" },
            new() { Name = "Pepperoni" },
            new() { Name = "Bacon" },
            new() { Name = "Onion" },
            new() { Name = "Olives" }
        };
            
        var pizzas = new Pizza[]
        {
            new() { Name = "Margarita", Price = 2.50, Ingredients = new PizzaIngredient[] {new(){ Ingredient = ingredients[0], Units = 4}}},
            new() { Name = "Hawaiian", Price = 4.75, Size = Size.Large },
            new() { Name = "Pepperoni", Price = 3.50, Size = Size.Medium },
            new() { Name = "Bacon", Price = 3.50, Size = Size.Medium },
            new() { Name = "Vegetarian", Price = 3.50, Size = Size.Medium },
            new() { Name = "Meat", Price = 3.50, Size = Size.Medium }
        };

        context.Ingredients?.AddRange(ingredients);
        context.Pizzas?.AddRange(pizzas);
        
        context.SaveChanges();
    }
}