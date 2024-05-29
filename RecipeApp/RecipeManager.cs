using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    // Class responsible for managing recipes
    public class RecipeManager
    {
        private List<Recipes> recipes; // List to store recipes

        // Event to notify when calories exceed a threshold
        public event Action<string> OnCaloriesExceeded;

        // Constructor to initialize the recipe manager
        public RecipeManager()
        {
            recipes = new List<Recipes>(); // Initialize the list of recipes
        }

        // Method to add a new recipe to the manager
        public void AddRecipe(Recipes recipe)
        {
            recipes.Add(recipe); // Add the provided recipe to the list
        }

        // Method to display all recipes managed by the manager
        public void DisplayRecipes()
        {
            Console.WriteLine("\nAll Recipes:");
            // Iterate over each recipe, ordering them alphabetically by name, and display their names
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name);
            }
        }

        // Method to select a recipe by its name
        public Recipes SelectRecipe(string name)
        {
            // Find and return the first recipe whose name matches the provided name, ignoring case
            return recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Method to check if the total calories of a recipe exceed a threshold and notify the user if so
        public void CheckCalories(Recipes recipe)
        {
            // If the total calories of the provided recipe exceed 300, invoke the OnCaloriesExceeded event with a warning message
            if (recipe.CalculateTotalCalories() > 300)
            {
                OnCaloriesExceeded?.Invoke($"Warning: The recipe \"{recipe.Name}\" exceeds 300 calories.");
            }
        }

        // Method to clear a recipe from the manager by its name
        public void ClearRecipe(string recipeName)
        {
            // Find the recipe to remove from the list by its name, ignoring case
            Recipes recipeToRemove = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            // If the recipe is found, remove it from the list and inform the user
            if (recipeToRemove != null)
            {
                recipes.Remove(recipeToRemove);
                Console.WriteLine($"Recipe '{recipeName}' cleared successfully!");
            }
            // If the recipe is not found, inform the user that it was not found
            else
            {
                Console.WriteLine($"Recipe '{recipeName}' not found.");
            }
        }
    }
}
