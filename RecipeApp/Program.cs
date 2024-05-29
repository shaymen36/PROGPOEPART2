using System;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of RecipeManager to manage multiple recipes
            RecipeManager recipeManager = new RecipeManager();

            // Subscribe to the calorie notification event
            recipeManager.OnCaloriesExceeded += (string message) =>
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red for warning messages
                Console.WriteLine(message);
                Console.ResetColor(); // Reset text color to default
            };

            int choice;

            do
            {

                Console.ForegroundColor = ConsoleColor.White; // Set text color to white for menu options
                // Display menu options
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add a New Recipe");
                Console.WriteLine("2. Display All Recipes");
                Console.WriteLine("3. Display a Specific Recipe");
                Console.WriteLine("4. Scale Recipe");
                Console.WriteLine("5. Reset Quantities");
                Console.WriteLine("6. Clear Recipe");
                Console.WriteLine("7. Start a New Recipe");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                // Get user choice
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Set text color to yellow for invalid input message
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ResetColor(); // Reset text color to default
                    continue;
                }

                // Perform action based on user choice
                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddNewRecipe(recipeManager); // Add a new recipe
                            break;
                        case 2:
                            recipeManager.DisplayRecipes(); // Display all recipes
                            break;
                        case 3:
                            DisplaySpecificRecipe(recipeManager); // Display a specific recipe
                            break;
                        case 4:
                            ScaleRecipe(recipeManager); // Scale recipe
                            break;
                        case 5:
                            ResetRecipeQuantities(recipeManager); // Reset quantities
                            break;
                        case 6:
                            ClearRecipe(recipeManager); // Clear recipe
                            break;
                        case 7:
                            StartNewRecipe(recipeManager); // Start a new recipe
                            break;
                        case 0:
                            Console.WriteLine("Exiting..."); // Exit application
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Yellow; // Set text color to yellow for invalid choice message
                            Console.WriteLine("Invalid choice. Please choose a valid option.");
                            Console.ResetColor(); // Reset text color to default
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Set text color to red for exception message
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.ResetColor(); // Reset text color to default  
                }

                } while (choice != 0);
        }

        // Method to add a new recipe
        static void AddNewRecipe(RecipeManager recipeManager)
        {
            Console.Write("Enter the name of the recipe: ");
            string recipeName = Console.ReadLine();

            Recipes recipe = new Recipes(recipeName);

            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            // Prompt user to enter details for each ingredient
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write("Enter the name of ingredient: ");
                string ingredientName = Console.ReadLine();

                Console.Write("Enter the quantity: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write("Enter the unit of measurement: ");
                string unit = Console.ReadLine();

                Console.Write("Enter the number of calories: ");
                int calories = int.Parse(Console.ReadLine());

                Console.Write("Enter the food group: ");
                string foodGroup = Console.ReadLine();

                // Add the ingredient to the recipe
                recipe.AddIngredient(ingredientName, quantity, unit, calories, foodGroup);
            }

            Console.Write("Enter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            // Prompt user to enter details for each step
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write("Enter the description of the step: ");
                string stepDescription = Console.ReadLine();
                recipe.AddStep(stepDescription);
            }

            // Add the recipe to the recipe manager
            recipeManager.AddRecipe(recipe);
            Console.WriteLine("Recipe added successfully!");
        }

        // Method to display a specific recipe
        static void DisplaySpecificRecipe(RecipeManager recipeManager)
        {
            Console.Write("Enter the name of the recipe to display: ");
            string recipeName = Console.ReadLine();

            Recipes recipe = recipeManager.SelectRecipe(recipeName);
            if (recipe != null)
            {
                // Display the selected recipe details
                recipe.Display();

                // Check if the total calories exceed 300 and notify the user if so
                recipeManager.CheckCalories(recipe);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to scale a recipe
        static void ScaleRecipe(RecipeManager recipeManager)
        {
            Console.Write("Enter the name of the recipe to scale: ");
            string recipeName = Console.ReadLine();

            Recipes recipe = recipeManager.SelectRecipe(recipeName);
            if (recipe != null)
            {
                Console.Write("Enter the scaling factor (0.5, 2, or 3): ");
                double factor = double.Parse(Console.ReadLine());

                // Scale the quantities of ingredients in the recipe by the given factor
                recipe.ScaleRecipe(factor);
                Console.WriteLine("Recipe scaled successfully!");

                // Display the scaled recipe details
                recipe.Display();

                // Check if the total calories exceed 300 and notify the user if so
                recipeManager.CheckCalories(recipe);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to reset the ingredient quantities of a recipe
        static void ResetRecipeQuantities(RecipeManager recipeManager)
        {
            Console.Write("Enter the name of the recipe to reset: ");
            string recipeName = Console.ReadLine();

            Recipes recipe = recipeManager.SelectRecipe(recipeName);
            if (recipe != null)
            {
                // Reset the quantities of ingredients to their original values
                recipe.ResetQuantities();
                Console.WriteLine("Recipe quantities reset successfully!");

                // Display the recipe details after resetting quantities
                recipe.Display();

                // Check if the total calories exceed 300 and notify the user if so
                recipeManager.CheckCalories(recipe);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to clear a recipe
        static void ClearRecipe(RecipeManager recipeManager)
        {
            Console.Write("Enter the name of the recipe to clear: ");
            string recipeName = Console.ReadLine();

            Recipes recipe = recipeManager.SelectRecipe(recipeName);
            if (recipe != null)
            {
                // Clear the recipe (remove all ingredients and steps)
                recipe.Clear();
                Console.WriteLine("Recipe cleared successfully!");
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to start a new recipe
        static void StartNewRecipe(RecipeManager recipeManager)
        {
            Console.WriteLine("Starting a new recipe. Existing recipes will not be deleted.");
            AddNewRecipe(recipeManager); // Call the method to add a new recipe
        }
    }
}
