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
                new Sandwich {Name="White bread toast & butter", Price=1.00, Ingredients = new List<Ingredient> { new Ingredient { Name = "white bread"}, new Ingredient { Name = "butter"} } },
                new Sandwich {Name="White bread toast & butter with jam", Price=1.50, Ingredients = new List<Ingredient> { new Ingredient { Name = "white bread"}, new Ingredient { Name = "butter"}, new Ingredient { Name = "jam"} } },
                new Sandwich {Name="Guinness braised beef", Price=8.00, Meal=meal.lunch, Ingredients = new List<Ingredient> { new Ingredient { Name = "Guinness braised beef"}, new Ingredient { Name = "house pickles"}, new Ingredient { Name = "smoky salsa roja"}, new Ingredient { Name = "creamy coleslaw" }, new Ingredient { Name = "French roll" } } },
                new Sandwich {Name="Mumbai spiced chicken breast", Price=8.00, Meal=meal.lunch, Ingredients = new List<Ingredient> { new Ingredient { Name = "Mumbai spiced chicken breast"}, new Ingredient { Name = "papadum"}, new Ingredient { Name = "pickled cucumber + tomato salsa"}, new Ingredient { Name = "raita" }, new Ingredient { Name = "French roll" } } },
                new Sandwich {Name="Fried egg, cheddar or pepper jack cheese", Price=3.00, Ingredients = new List<Ingredient> { new Ingredient { Name = "English muffin"}, new Ingredient { Name = "cheddar cheese"}, new Ingredient { Name = "pepper jack cheese"} } }
            };
            sandwiches.ForEach(s => context.Sandwiches.Add(s));
            context.SaveChanges();


        }
    }
}