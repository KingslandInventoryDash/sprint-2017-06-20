using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryDash.Models
{
    public enum category
    {
        bread, protein, dairy, produce, condiment, beverage, togo
    }

    public class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public category Category { get; set; }
    }
}