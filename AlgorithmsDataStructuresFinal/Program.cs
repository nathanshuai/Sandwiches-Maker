// Final Assignment
//Create a simple console application that allows a user to "make a sandwich" within a set caloric range.
//A list of available sandwich ingredients, along with their associated calories, is provided in the starter code.
using System;
using System.Collections.Generic;

Dictionary<string, int> ingredients = new Dictionary<string, int>()
        {
            { "Bread", 66 },
            { "Ham", 72 },
            { "Bologna", 57 },
            { "Chicken", 17 },
            { "Corned Beef", 53 },
            { "Salami", 40 },
            { "Cheese, American", 104 },
            { "Cheese, Cheddar", 113 },
            { "Cheese, Havarti", 105 },
            { "Mayonnaise", 94 },
            { "Mustard", 10 },
            { "Butter", 102 },
            { "Garlic Aioli", 100 },
            { "Sriracha", 15 },
            { "Dressing, Ranch", 73 },
            { "Dressing, 1000 Island", 59 },
            { "Lettuce", 5 },
            { "Tomato", 4 },
            { "Cucumber", 4 },
            { "Banana Pepper", 10 },
            { "Green Pepper", 3 },
            { "Red Onion", 6 },
            { "Spinach", 7 },
            { "Avocado", 64 }
        };

int lowestIngredient = Int32.MaxValue;
int lowestCalories = Int32.MaxValue;

foreach (KeyValuePair<string, int> ingredient in ingredients)
{
    if (ingredient.Key != "Bread" && ingredient.Value < lowestIngredient)
    {
        lowestIngredient = ingredient.Value;
        lowestCalories = 2 * ingredients["Bread"] + lowestIngredient;
    }
}

bool validCaloInput = false;
int userMiniCalo = 0;
int userMaxCalo = 0;

while (!validCaloInput)
{
    Console.Write("Enter the minimum number of calories you would like in your sandwich: ");
    string miniCaloInput = Console.ReadLine().ToUpper().Trim();
    validCaloInput = Int32.TryParse(miniCaloInput, out userMiniCalo);
}
//add response
if (userMiniCalo < lowestCalories)
{
    Console.WriteLine("A sandwich cannot be made within the given calorie range based on the available ingredients.");
    return;
}

validCaloInput = false;

while (!validCaloInput)
{
    Console.Write("Enter the maximum number of calories you would like in your sandwich: ");
    string maxCaloInput = Console.ReadLine().ToUpper().Trim();
    validCaloInput = Int32.TryParse(maxCaloInput, out userMaxCalo);
}

if (userMaxCalo <= userMiniCalo)
{
    Console.WriteLine("The maximum number of calories must be greater than the minimum number of calories.");
    return;
}


List<string> excludedIngredients = new List<string>();

bool excludeBread = true;

while (excludeBread)
{
    Console.WriteLine("Do you want to exclude any ingredients? (Separate multiple ingredients with commas)");

    string excludedIngredientsInput = Console.ReadLine().ToUpper().Trim();
    excludedIngredients.Clear(); // Clear the list before populating it again
    excludedIngredients.AddRange(excludedIngredientsInput.Split(','));

    excludeBread = false; // Assume the user won't exclude bread by default

    foreach (string excludedIngredient in excludedIngredients)
    {
        if (excludedIngredient.Trim() == "BREAD")
        {
            excludeBread = true; // User wants to exclude bread, so set the flag to true
            break;
        }
    }

    if (excludeBread)
    {
        Console.WriteLine("Sandwiches must include bread. Bread cannot be excluded.");
        // You can prompt the user again here to enter excluded ingredients
    }
}


List<string> sandwichIngredients = new List<string>();
int totalCalories = 0;
bool isCaloriesInRange = true;
sandwichIngredients.Add("Bread");// Add 2 slices of bread at the start and end

while (isCaloriesInRange)
{
    string previousIngredient = sandwichIngredients.LastOrDefault();

    foreach (KeyValuePair<string, int> ingredient in ingredients)
    {
        bool isExcluded = excludedIngredients.Contains(ingredient.Key.ToUpper());
        if (isExcluded || ingredient.Key.ToUpper() == "BREAD")
        {
            continue;
        } else

        if (ingredient.Key == previousIngredient)
        {
            continue; // Skip adding the ingredient if it is the same as the previous one
        }

        sandwichIngredients.Add(ingredient.Key);
        totalCalories += ingredient.Value;
        break;

    }

    if (totalCalories > userMiniCalo)
    {
        isCaloriesInRange = false;
        
    }
    else
    {
        isCaloriesInRange = true;
    }

}

sandwichIngredients.Add("Bread"); // Add 2 slices of bread at the start and end

Console.WriteLine("Making your sandwich\n");

foreach (string ingredient in sandwichIngredients)
{
    Console.WriteLine("Adding " + ingredient + " (" + ingredients[ingredient] + " calories)");
}

Console.WriteLine("\nYour sandwich, with " + totalCalories + " calories, is ready. Enjoy!");



















