using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10230097_PROG6221
{
    internal class Program
    {
        struct Ingredient
        {
            public string Name;
            public double OriginalQuantity;
            public double Quantity;
            public string Unit;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter the name of the recipe");
            String recipe = Console.ReadLine();

            // Prompt the user to enter the number of ingredients
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            // Create an array to store the ingredients
            Ingredient[] ingredients = new Ingredient[numIngredients];

            // Prompt the user to enter details for each ingredient and store them in the array
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"\nEnter details for ingredient {i + 1}:");

                Console.Write("Name of Ingredient: ");
                string name = Console.ReadLine();

                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write("Unit of Measurement: ");
                string unit = Console.ReadLine();

                // Create a new Ingredient struct and add it to the array
                ingredients[i] = new Ingredient { Name = name, OriginalQuantity = quantity, Quantity = quantity, Unit = unit };
            }

            Console.Write("\nEnter the number of steps: ");
            int numOfSteps = int.Parse(Console.ReadLine());

            // Create an array to store the steps
            string[] steps = new string[numOfSteps];

            // Prompt the user to enter description for each step and store them in the array
            for (int i = 0; i < numOfSteps; i++)
            {
                Console.WriteLine($"\nEnter description for step {i + 1}:");
                steps[i] = Console.ReadLine();
            }

            Console.WriteLine("\n", recipe);

            Console.WriteLine("\nIngredients:");
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"{i + 1}. {ingredients[i].Quantity} {ingredients[i].Unit} of {ingredients[i].Name}");
            }

            // Display the steps entered by the user
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < numOfSteps; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }

            Console.WriteLine("\nChoose scaling factor:");
            Console.WriteLine("1. 0.5 (Half)");
            Console.WriteLine("2. 2 (Double)");
            Console.WriteLine("3. 3 (Triple)");
            Console.Write("Enter your choice: ");
            int scalingChoice = int.Parse(Console.ReadLine());

            double scaleFactor = GetScaleFactor(scalingChoice);

            // Scale the quantities of ingredients
            for (int i = 0; i < numIngredients; i++)
            {
                ingredients[i].Quantity *= scaleFactor;
            }

            // Display the scaled ingredients
            Console.WriteLine("\nModified Ingredients:");
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"{i + 1}. {ingredients[i].Quantity} {ingredients[i].Unit} of {ingredients[i].Name}");
            }

            // Ask the user if they want to reset the quantities to original values
            Console.Write("\nDo you want to reset quantities to original values? (yes/no): ");
            string resetChoice = Console.ReadLine();

            if (resetChoice.ToLower() == "yes")
            {
                // Reset quantities to original values
                for (int i = 0; i < numIngredients; i++)
                {
                    ingredients[i].Quantity = ingredients[i].OriginalQuantity;
                }

                // Display the ingredients with original quantities
                Console.WriteLine("\nOriginal Ingredients:");
                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"{i + 1}. {ingredients[i].Quantity} {ingredients[i].Unit} of {ingredients[i].Name}");
                }
            }
            Console.ReadKey();
        }

        // Method to get scaling factor based on user choice
        static double GetScaleFactor(int choice)
        {
            switch (choice)
            {
                case 1: return 1.5; // Half increase
                case 2: return 2.0; // Double increase
                case 3: return 3.0; // Triple increase
                default: return 1.0; // Default (no scaling)
            }
        }

    }


        }
    
