using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Meal
    {
        public int MealId { get; set; }
        public string Name { get; set; }

        public Food Food { get; set; }
        public Drink Drink { get; set; }

        public int FoodId { get; set; }
        public int DrinkId { get; set; }
    }
}