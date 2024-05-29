using System;
using System.Collections.Generic;

namespace RecipeApp
{
    // Class representing a single recipe
    public class Recipes
    {
        // Properties for the recipe
        public string Name { get; set; } // Name of the recipe
        private List<Ingredient> ingredients; // List to store ingredients
        private List<string> steps; // List to store steps of the recipe
        private Dictionary<Ingredient, double> originalQuantities; // Dictionary to store original quantities of ingredients

        // Constructor to initialize a recipe with a name
        public Recipes(string name)
        {
            Name = name;
            ingredients = new List<Ingredient>(); // Initialize ingredients list
            steps = new List<string>(); // Initialize steps list
            originalQuantities = new Dictionary<Ingredient, double>(); // Initialize dictionary for original quantities
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            var ingredient = new Ingredient(name, quantity, unit, calories, foodGroup); // Create a new ingredient object
            ingredients.Add(ingredient); // Add the ingredient to the list of ingredients
            originalQuantities[ingredient] = quantity; // Store the original quantity in the dictionary
        }

        // Method to add a step to the recipe
        public void AddStep(string step)
        {
            steps.Add(step); // Add the step to the list of steps
        }

        // Method to display the recipe details
        public void Display()
        {
            Console.WriteLine($"\nRecipe: {Name}"); // Display the name of the recipe
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                // Display each ingredient's details (quantity, unit, name, calories, food group)
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                // Display each step with numbering
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // Method to scale the quantities of ingredients in the recipe by a factor
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                // Scale the quantity of each ingredient by the given factor, using the original quantity
                ingredient.Quantity = originalQuantities[ingredient] * factor;
            }
        }

        // Method to reset the quantities of ingredients to their original values
        public void ResetQuantities()
        {
            foreach (var ingredient in ingredients)
            {
                // Reset the quantity of each ingredient to its original quantity
                ingredient.Quantity = originalQuantities[ingredient];
            }
        }

        // Method to clear the recipe (remove all ingredients and steps)
        public void Clear()
        {
            ingredients.Clear(); // Clear the list of ingredients
            steps.Clear(); // Clear the list of steps
            originalQuantities.Clear(); // Clear the dictionary of original quantities
        }

        // Method to calculate the total calories of the recipe
        public int CalculateTotalCalories()
        {
            int totalCalories = 0; // Initialize the total calories to zero
            foreach (var ingredient in ingredients)
            {
                // Calculate the calories contributed by each ingredient, considering its quantity
                totalCalories += (int)(ingredient.Calories * ingredient.Quantity);
            }
            return totalCalories; // Return the total calories
        }
    }
}