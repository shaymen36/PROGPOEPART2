using System;

namespace RecipeApp
{
    public class Ingredient
    {
        // Properties for the ingredient
        public string Name { get; set; } // Name of the ingredient
        public double Quantity { get; set; } // Quantity of the ingredient
        public string Unit { get; set; } // Unit of measurement for the quantity
        public int Calories { get; set; } // Number of calories in the ingredient
        public string FoodGroup { get; set; } // Food group the ingredient belongs to

        // Constructor to initialize an ingredient with details
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name; // Initialize the name of the ingredient
            Quantity = quantity; // Initialize the quantity of the ingredient
            Unit = unit; // Initialize the unit of measurement
            Calories = calories; // Initialize the number of calories
            FoodGroup = foodGroup; // Initialize the food group
        }
    }
}
