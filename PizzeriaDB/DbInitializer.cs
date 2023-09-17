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

        if (context.Pizzas is null || !context.Pizzas.Any())
        {
            var pizzas = new Pizza[]
            {
                new() { Name = "Margarita", Price = 2.50 },
                new() { Name = "Hawaiian", Price = 4.75, Size = Size.Large},
                new() { Name = "Pepperoni", Price = 3.50, Size = Size.Medium},
                new() { Name = "Bacon", Price = 3.50, Size = Size.Medium},
                new() { Name = "Vegetarian", Price = 3.50, Size = Size.Medium},
                new() { Name = "Meat", Price = 3.50, Size = Size.Medium}
            };

            context.Pizzas?.AddRange(pizzas);
        }

        if (context.Ingredients is null || !context.Ingredients.Any())
        {
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

            context.Ingredients?.AddRange(ingredients);
        }
        
        context.SaveChanges();
    }
}