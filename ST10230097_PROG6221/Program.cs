using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This is my whole application in a class
class RecipeManager
{
    struct Ingredient
    {
        public string Name;
        public double OriginalQuantity;
        public double Quantity;
        public string Unit;
    }

    public void EnterRecipe()
    {
        Console.WriteLine("Please enter the name of the recipe");
        string recipe = Console.ReadLine();

        Console.Write("Enter the number of ingredients: ");
        int numIngredients = int.Parse(Console.ReadLine());

        Ingredient[] ingredients = new Ingredient[numIngredients];

        for (int i = 0; i < numIngredients; i++)
        {
            Console.WriteLine($"\nEnter details for ingredient {i + 1}:");

            Console.Write("Name of Ingredient: ");
            string name = Console.ReadLine();

            Console.Write("Quantity: ");
            double quantity = double.Parse(Console.ReadLine());

            Console.Write("Unit of Measurement: ");
            string unit = Console.ReadLine();

            ingredients[i] = new Ingredient { Name = name, OriginalQuantity = quantity, Quantity = quantity, Unit = unit };
        }

        Console.Write("\nEnter the number of steps: ");
        int numOfSteps = int.Parse(Console.ReadLine());

        string[] steps = new string[numOfSteps];

        for (int i = 0; i < numOfSteps; i++)
        {
            Console.WriteLine($"\nEnter description for step {i + 1}:");
            steps[i] = Console.ReadLine();
        }

        Console.WriteLine($"\n{recipe}");

        Console.WriteLine("\nIngredients:");
        for (int i = 0; i < numIngredients; i++)
        {
            Console.WriteLine($"{i + 1}. {ingredients[i].Quantity} {ingredients[i].Unit} of {ingredients[i].Name}");
        }

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

        for (int i = 0; i < numIngredients; i++)
        {
            ingredients[i].Quantity *= scaleFactor;
        }

        Console.WriteLine("\nModified Ingredients:");
        for (int i = 0; i < numIngredients; i++)
        {
            Console.WriteLine($"{i + 1}. {ingredients[i].Quantity} {ingredients[i].Unit} of {ingredients[i].Name}");
        }

        Console.Write("\nDo you want to reset quantities to original values? (yes/no): ");
        string resetChoice = Console.ReadLine();

        if (resetChoice.ToLower() == "yes")
        {
            for (int i = 0; i < numIngredients; i++)
            {
                ingredients[i].Quantity = ingredients[i].OriginalQuantity;
            }

            Console.WriteLine("\nOriginal Ingredients:");
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"{i + 1}. {ingredients[i].Quantity} {ingredients[i].Unit} of {ingredients[i].Name}");
            }
        }
    }

    static double GetScaleFactor(int choice)
    {
        switch (choice)
        {
            // This is the increment factor that the user can choose from
            case 1: return 1.5; 
            case 2: return 2.0; 
            case 3: return 3.0; 
            default: return 1.0; 
        }
    }
}

// To make us run the application again or end it
class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        do
        {
            RecipeManager recipeManager = new RecipeManager();
            recipeManager.EnterRecipe();

            Console.WriteLine("\nDo you want to enter a new recipe? (yes/no)");
            string input = Console.ReadLine();

            if (input.ToLower() != "yes")
            {
                exit = true;
            }

        } while (!exit);
    }
}


