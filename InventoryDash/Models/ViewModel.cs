using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryDash.Models;
using System.ComponentModel.DataAnnotations;

namespace InventoryDash.Models
{
    public class ViewModel
    {
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Sandwich> Sandwiches { get; set; }

        public ViewModel(ICollection<Ingredient> i, ICollection<Sandwich> s)
        {
            Ingredients = i;
            Sandwiches = s;
        }
    }
    
    public enum category
    {
        beverage, bread, condiment, dairy, produce, protein, togo
    }

    public class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public category Category { get; set; }

        public virtual ICollection<Sandwich> Sandwiches { get; set; }
    }

    public enum meal
    {
        breakfast, lunch, both
    }

    public class Sandwich
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public meal Meal { get; set; }
        [Display(Name = "Ingredients")]
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}