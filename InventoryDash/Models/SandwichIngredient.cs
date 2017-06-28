using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryDash.Models
{
    public class SandwichIngredient
    {
        public int ID { get; set; }
        public int Sandwich_ID { get; set; }
        public int Ingredient_ID { get; set; }
    }
}