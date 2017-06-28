using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using InventoryDash.Models;

namespace InventoryDash.DAL
{
    //public class InventoryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<InventoryContext>
    public class InventoryInitializer : System.Data.Entity.DropCreateDatabaseAlways<InventoryContext>
    {
        protected override void Seed(InventoryContext context)
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "white bread", Category = category.bread, Price=5, NumPortions=20 },
                new Ingredient { Name = "butter", Category = category.dairy, Price = 6, NumPortions=24},
                new Ingredient { Name = "pepperjack cheese", Category = category.dairy, Price=8, NumPortions=20},

                new Ingredient { Name = "Guinness braised beef", Category = category.protein, Price = 50, NumPortions=100},
                new Ingredient { Name = "house pickles", Category = category.produce, Price = 6, NumPortions=24},
                new Ingredient { Name = "smoky salsa roja", Category = category.produce, Price = 6, NumPortions=30},
                new Ingredient { Name = "creamy coleslaw", Category = category.produce, Price = 15, NumPortions=100},
                new Ingredient { Name = "French roll", Category = category.bread, Price = 10, NumPortions=12},
                new Ingredient { Name = "Mumbai spiced chicken breast", Category = category.protein, Price = 25, NumPortions=50},
                new Ingredient { Name = "papadum", Category = category.bread, Price = 6, NumPortions=40},
                new Ingredient { Name = "pickled cucumber + tomato salsa", Category = category.produce, Price = 6, NumPortions=20},
                new Ingredient { Name = "raita", Category = category.condiment, Price = 6, NumPortions=100},
                new Ingredient { Name = "Fried egg", Category = category.protein, Price = 2, NumPortions=12},
                new Ingredient { Name = "Cheddar", Category = category.dairy, Price = 12, NumPortions=20},
                new Ingredient { Name = "Pepper Jack cheese", Category = category.dairy, Price = 12, NumPortions=20},
                new Ingredient { Name = "English muffin", Category = category.dairy, Price = 12, NumPortions=20},

                new Ingredient { Name = "Bottle water", Category = category.beverage, Price = 5, NumPortions=50},
                new Ingredient { Name = "Can soda", Category = category.beverage, Price = 6, NumPortions=24},

                new Ingredient { Name = "Napkin", Category = category.togo, Price = 15, NumPortions=1000},
                new Ingredient { Name = "Sandwich Wrapping", Category = category.togo, Price = 20, NumPortions=500},

                new Ingredient { Name = "jam", Category=category.condiment, Price=6, NumPortions=60}
            };
            ingredients.ForEach(s => context.Ingredients.Add(s));
            context.SaveChanges();

            var sandwiches = new List<Sandwich>
            {
                new Sandwich {Name="White bread toast & butter", Price=1.00, Ingredients = new List<Ingredient> { context.Ingredients.Single(ing => ing.Name == "white bread"), context.Ingredients.Single(ing => ing.Name == "butter") } },
                new Sandwich {Name="White bread toast & butter with jam", Price=1.50, Ingredients = new List<Ingredient> { context.Ingredients.Single(ing => ing.Name == "white bread"), context.Ingredients.Single(ing => ing.Name == "butter"), context.Ingredients.Single(ing => ing.Name == "jam") } },

                new Sandwich {Name="Guinness braised beef", Price=8.00, Meal=meal.lunch, Ingredients = new List<Ingredient> { context.Ingredients.Single(ing => ing.Name == "Guinness braised beef"), context.Ingredients.Single(ing => ing.Name == "house pickles"), context.Ingredients.Single(ing => ing.Name == "smoky salsa roja"), context.Ingredients.Single(ing => ing.Name == "creamy coleslaw"), context.Ingredients.Single(ing => ing.Name == "French roll") } },
                new Sandwich {Name="Mumbai spiced chicken breast", Price=8.00, Meal=meal.lunch, Ingredients = new List<Ingredient> { context.Ingredients.Single(ing => ing.Name == "Mumbai spiced chicken breast"), context.Ingredients.Single(ing => ing.Name == "papadum"), context.Ingredients.Single(ing => ing.Name == "pickled cucumber + tomato salsa"), context.Ingredients.Single(ing => ing.Name == "raita"), context.Ingredients.Single(ing => ing.Name == "French roll") } },
                                                                                               
                new Sandwich {Name="Fried egg, pepper jack cheese", Price=3.00, Ingredients = new List<Ingredient> { context.Ingredients.Single(ing => ing.Name == "Fried egg"), context.Ingredients.Single(ing => ing.Name == "Pepper Jack cheese"), context.Ingredients.Single(ing => ing.Name == "English muffin") } }
            };
            sandwiches.ForEach(s => context.Sandwiches.Add(s));
            context.SaveChanges();


        }
    }
}