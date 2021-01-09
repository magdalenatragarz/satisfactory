using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfactory
{
    public class UserInputParser
    {
        private Dictionary<int, ItemType> itemMapping;

        public UserInputParser()
        {
            itemMapping = new Dictionary<int, ItemType>();
        }

        public ConstructionTree getTree()
        {
            Console.WriteLine(getPossibleToBuildItemsListString());
            Console.WriteLine(getNewLine());
            Console.WriteLine(getChooseMenuString());
            var userInput = Console.ReadLine();

            Console.Clear();

            return chooseRecipe("Choose main recipe", itemMapping[Convert.ToInt32(userInput)]);
        }

        public double getWantedProductionPerMinute()
        {
            Console.Clear();
            Console.WriteLine("Specify wanted production per minute");
            var input = Console.ReadLine();

            Console.Clear();

            return Convert.ToDouble(input);
        }

        private ConstructionTree chooseRecipe(string desc, ItemType item)
        {
            Console.Clear();

            Console.WriteLine(desc.ToUpper() + "\n");

            var recipeIndex = 0;

            foreach (var recipe in (Database.getRecipes(item)))
            {
                Console.WriteLine("[" + recipeIndex + "] " + recipe.toString());
                recipeIndex++;
            }

            var chosenRecipeIndex = 0;

            if (Database.getRecipes(item).Count > 1)
            {
                Console.WriteLine("Choose number of recipe");
                chosenRecipeIndex = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("========= CHOSEN RECIPE ========= \n" + Database.getRecipes(item)[chosenRecipeIndex].toString() + "\n");

            var tree = new ConstructionTree(new ConstructionNode(Database.getRecipes(item)[chosenRecipeIndex]));

            foreach (var ingredient in Database.getRecipes(item)[chosenRecipeIndex].input)
            {
                tree.addIngredient(chooseRecipe("Specify recipe for " + ingredient.type + " for building " + item, ingredient.type));
            }

            return tree;

        }


        private string getPossibleToBuildItemsListString()
        {
            string possibleItemsListString = "";
            int itemId = 1;

            foreach(var recipe in Database.getRecipes())
            {
                var ending = "";
                if (itemId % 4 == 0)
                    ending = "\n";

                var add = string.Format("{0,-30}", "[" + itemId + "] " + recipe.Key);

                possibleItemsListString = possibleItemsListString + add + ending;

                itemMapping[itemId] = recipe.Key;
                itemId++;
            }
            return possibleItemsListString;
        }

        private string getChooseMenuString()
        {
            return "Specify choosen number";
        }

        private string getNewLine()
        {
            return "\n";
        }
        
    }
}
