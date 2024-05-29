using System;

namespace RecipeApp
{
    class Recipe
    {
        private string[] ingredients; // Array for ingredient storage
        private string[] steps; // An array for steps
        private bool recipeEntered = false; // Mark to monitor the entry of recipe details
        private string[] originalIngredients; // Array to store original ingredient quantities

        // How to input recipe information
        public void EnterDetails()
        {
            Console.WriteLine("Enter the number of ingredients:");
            int ingredientCount = int.Parse(Console.ReadLine());
            ingredients = new string[ingredientCount];

            originalIngredients = new string[ingredientCount]; // Maintain initial amounts

            // Repeat to insert information for every ingredient
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter name of ingredient {i + 1}:");
                string name = Console.ReadLine();
                Console.WriteLine($"Enter quantity of {name}:");
                string quantity = Console.ReadLine();
                Console.WriteLine($"Enter unit of measurement for {name}:");
                string unit = Console.ReadLine();

                ingredients[i] = $"{quantity} {unit} of {name}";
                originalIngredients[i] = ingredients[i]; // Store the original ingredient
            }

            Console.WriteLine("Enter the number of steps:");
            int stepCount = int.Parse(Console.ReadLine());
            steps = new string[stepCount];

            // Enter information for each stage in a loop
            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                steps[i] = Console.ReadLine();
            }

            recipeEntered = true; // Indicate that recipe details have been supplied by setting a flag.
        }

        // How to present the recipe
        public void DisplayRecipe()
        {
            // Verify that the recipe's details are entered.
            if (!recipeEntered)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Change text color to red for error message
                Console.WriteLine("Recipe not entered yet.");
                Console.ResetColor(); // Reset text color to default
                return;
            }

            // Change text color for recipe display
            Console.ForegroundColor = ConsoleColor.Green;
            // Present the ingredients
            Console.WriteLine("\nRecipe:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ingredients:");
            foreach (string ingredient in ingredients)
            {
                Console.WriteLine(ingredient);
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            // Show the steps
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
            Console.ResetColor();
        }

        // How to scale a recipe by a specified amount
        public void ScaleRecipe(double factor)
        {
            // Verify that the recipe's information has been entered.
            if (!recipeEntered)
            {
                Console.WriteLine("Recipe not entered yet.");
                return;
            }

            // Adjust ingredient amounts.
            for (int i = 0; i < ingredients.Length; i++)
            {
                string ingredient = ingredients[i];
                string[] parts = ingredient.Split(' ');
                double quantity = double.Parse(parts[0]);
                quantity *= factor;
                ingredients[i] = $"{quantity} {parts[1]} of {string.Join(' ', parts, 2, parts.Length - 2)}";
            }
        }

        // Technique for returning ingredient quantities to initial values
        public void ResetQuantities()
        {
            // Verify that the recipe's details are entered.
            if (!recipeEntered)
            {
                Console.WriteLine("Recipe not entered yet.");
                return;
            }

            // Restore original quantities
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i] = originalIngredients[i]; // Restore the original ingredient string
            }
        }

        // How to remove recipe specifics
        public void ClearRecipe()
        {
            ingredients = null;
            steps = null;
            originalIngredients = null; // Clear the original ingredients array
            recipeEntered = false; // Clear the recipe details by resetting the flag.
        }
    }
}
