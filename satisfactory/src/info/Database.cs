using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfactory
{
    public static class Database
    {

        private static Dictionary<MachineType, double> powerUsages = new Dictionary<MachineType, double>();
        private static Dictionary<ItemType, Recipe> recipes = new Dictionary<ItemType, Recipe>();

        private static Recipe modularFrame = new Recipe(
            new Item(ItemType.modularFrame, 2),
            new List<Item>() { new Item(ItemType.reinforcedIronPlate, 3), new Item(ItemType.ironRod, 12) },
            60, MachineType.assembler
        );

        private static Recipe ironRod = new Recipe(
            new Item(ItemType.ironRod, 1),
            new List<Item>() { new Item(ItemType.ironInglot, 1)},
            4, MachineType.constructor
        );

        private static Recipe ironInglot = new Recipe(
            new Item(ItemType.ironInglot, 1),
            new List<Item>() { new Item(ItemType.ironOre, 1)},
            2, MachineType.smelter
        );

        private static Recipe reinforcedIronPlate = new Recipe(
            new Item(ItemType.reinforcedIronPlate, 1),
            new List<Item>() { new Item(ItemType.ironPlate, 6), new Item(ItemType.screw, 12), },
            12, MachineType.assembler
        );

        private static Recipe screw = new Recipe(
            new Item(ItemType.screw, 4),
            new List<Item>() { new Item(ItemType.ironRod, 1) },
            6, MachineType.constructor
        );

        private static Recipe ironPlate = new Recipe(
            new Item(ItemType.ironPlate, 2),
            new List<Item>() { new Item(ItemType.ironInglot, 3) },
            6, MachineType.constructor
        );

        private static Recipe ironOre = new Recipe(
            new Item(ItemType.ironOre, 30),
            new List<Item>() { },
            60, MachineType.minerMK1
        );


        static Database()
        {
            powerUsages[MachineType.assembler] = 15.0;
            powerUsages[MachineType.minerMK1] = 15.0;
            powerUsages[MachineType.smelter] = 15.0;
            powerUsages[MachineType.constructor] = 15.0;

            recipes[ItemType.modularFrame] = modularFrame;
            recipes[ItemType.ironRod] = ironRod;
            recipes[ItemType.ironInglot] = ironInglot;
            recipes[ItemType.reinforcedIronPlate] = reinforcedIronPlate;
            recipes[ItemType.screw] = screw;
            recipes[ItemType.ironPlate] = ironPlate;
            recipes[ItemType.ironOre] = ironOre;
        }

        public static double getBasePowerUsage(MachineType type)
        {
            return powerUsages[type];
        }

        public static Recipe getRecipe(ItemType type)
        {
            return recipes[type];
        }

        public static ConstructionNode get(ItemType type)
        {
            return new ConstructionNode(Database.getRecipe(type));
        }

    }
}
