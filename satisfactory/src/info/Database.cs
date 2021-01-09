using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfactory
{
    public static class Database
    {
        private static Dictionary<MachineType, double> powerUsages = new Dictionary<MachineType, double>();
        private static Dictionary<ItemType, List<Recipe>> recipes = new Dictionary<ItemType, List<Recipe>>();

        static Database()
        {
            var parser = new DatabaseParser("D:\\projekty\\satisfactory\\satisfactory\\satisfactory\\recipes_tier1.json");

            powerUsages = parser.getMachines();
            recipes = parser.getRecipes();
        }

        public static double getBasePowerUsage(MachineType type)
        {
            return powerUsages[type];
        }

        public static List<Recipe> getRecipes(ItemType type)
        {
            return recipes[type];
        }
        public static Dictionary<ItemType, List<Recipe>> getRecipes()
        {
            return recipes;
        }


    }
}
