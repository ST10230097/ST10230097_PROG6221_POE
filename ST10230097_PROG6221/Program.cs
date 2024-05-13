using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This is my whole application in a class

class Program
{
    static void Main(string[] args)
    {
        RecipeManager recipeManager = new RecipeManager();
        recipeManager.Run();
    }
}

class RecipeManager
{
    private List<Recipe> recipes = new List<Recipe>();

    public void Run()
    {
        bool continueLoop = true;
        while (continueLoop)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Enter a new recipe");
            Console.WriteLine("2. Display recipes");
            Console.WriteLine("3. Scale a recipe");
            Console.WriteLine("4. Exit");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter your choice: ");
            Console.ResetColor();
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    EnterRecipe();
                    break;
                case 2:
                    DisplayRecipes();
                    break;
                case 3:
                    ScaleRecipe();
                    break;
                case 4:
                    continueLoop = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ResetColor();
                    break;
            }
        }
    }

    public void EnterRecipe()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Please enter the name of the recipe");
        Console.ResetColor();
        string recipeName = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter the number of ingredients: ");
        Console.ResetColor();
        int numIngredients = int.Parse(Console.ReadLine());

        Ingredient[] ingredients = new Ingredient[numIngredients];

        for (int i = 0; i < numIngredients; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nEnter details for ingredient {i + 1}:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Name of Ingredient: ");
            Console.ResetColor();
            string name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Quantity: ");
            Console.ResetColor();
            double quantity = double.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Unit of Measurement: ");
            Console.ResetColor();
            string unit = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Number of Calories: ");
            Console.ResetColor();
            int calories = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Food Group: ");
            Console.ResetColor();
            string foodGroup = Console.ReadLine();

            ingredients[i] = new Ingredient { Name = name, OriginalQuantity = quantity, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup };
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nEnter the number of steps: ");
        Console.ResetColor();
        int numOfSteps = int.Parse(Console.ReadLine());

        string[] steps = new string[numOfSteps];

        for (int i = 0; i < numOfSteps; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nEnter description for step {i + 1}:");
            Console.ResetColor();
            steps[i] = Console.ReadLine();
        }

        Recipe recipe = new Recipe
        {
            Name = recipeName,
            Ingredients = ingredients,
            Steps = steps
        };

        recipes.Add(recipe);
    }

    private void DisplayRecipes()
    {
        if (recipes.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No recipes have been entered yet.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nRecipes:");
        Console.ResetColor();

        for (int i = 0; i < recipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {recipes[i].Name}");
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nEnter the recipe number to display: ");
        Console.ResetColor();
        int recipeIndex = int.Parse(Console.ReadLine()) - 1;

        if (recipeIndex < 0 || recipeIndex >= recipes.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid recipe number.");
            Console.ResetColor();
            return;
        }

        DisplayRecipe(recipes[recipeIndex]);
    }
    // to display the recipe that is stored
    private void DisplayRecipe(Recipe recipe)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\n{recipe.Name}");

        Console.WriteLine("\nIngredients:");
        int totalCalories = 0;
        for (int i = 0; i < recipe.Ingredients.Length; i++)
        {
            int caloriesForIngredient = (int)(recipe.Ingredients[i].Calories * recipe.Ingredients[i].Quantity);
            Console.WriteLine($"{i + 1}. {recipe.Ingredients[i].Quantity} {recipe.Ingredients[i].Unit} of {recipe.Ingredients[i].Name} ({caloriesForIngredient} calories, {recipe.Ingredients[i].FoodGroup})");
            totalCalories += caloriesForIngredient;
        }

        Console.WriteLine($"\nTotal Calories: {totalCalories}");

        if (totalCalories > 300)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Warning: This recipe exceeds 300 calories.");
            Console.ResetColor();
        }

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < recipe.Steps.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
        }
        Console.ResetColor();
    }
    //scaling factor for the recipe engredients
    private void ScaleRecipe()
    {
        if (recipes.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No recipes have been entered yet.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nRecipes:");
        Console.ResetColor();

        for (int i = 0; i < recipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {recipes[i].Name}");
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nEnter the recipe number to scale: ");
        Console.ResetColor();
        int recipeIndex = int.Parse(Console.ReadLine()) - 1;

        if (recipeIndex < 0 || recipeIndex >= recipes.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid recipe number.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nChoose scaling factor:");
        Console.WriteLine("1. 0.5 (Half)");
        Console.WriteLine("2. 2 (Double)");
        Console.WriteLine("3. 3 (Triple)");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter your choice: ");
        Console.ResetColor();
        int scalingChoice = int.Parse(Console.ReadLine());

        double scaleFactor = GetScaleFactor(scalingChoice);

        Recipe recipe = recipes[recipeIndex];
        Ingredient[] scaledIngredients = ScaleIngredients(recipe.Ingredients, scaleFactor);

        Recipe scaledRecipe = new Recipe
        {
            Name = recipe.Name,
            Ingredients = scaledIngredients,
            Steps = recipe.Steps
        };

        DisplayRecipe(scaledRecipe);
    }

    private Ingredient[] ScaleIngredients(Ingredient[] ingredients, double scaleFactor)
    {
        Ingredient[] scaledIngredients = new Ingredient[ingredients.Length];

        for (int i = 0; i < ingredients.Length; i++)
        {
            scaledIngredients[i] = new Ingredient
            {
                Name = ingredients[i].Name,
                OriginalQuantity = ingredients[i].OriginalQuantity,
                Quantity = ingredients[i].Quantity * scaleFactor,
                Unit = ingredients[i].Unit,
                Calories = ingredients[i].Calories,
                FoodGroup = ingredients[i].FoodGroup
            };
        }

        return scaledIngredients;
    }

    static double GetScaleFactor(int choice)
    {
        switch (choice)
        {
            case 1: return 0.5;
            case 2: return 2.0;
            case 3: return 3.0;
            default: return 1.0;
        }
    }
}

//this is where all the recipes the user enter stay
class Recipe
{
    public string Name { get; set; }
    public Ingredient[] Ingredients { get; set; }
    public string[] Steps { get; set; }
}

struct Ingredient
{
    public string Name;
    public double OriginalQuantity;
    public double Quantity;
    public string Unit;
    public int Calories;
    public string FoodGroup;
}