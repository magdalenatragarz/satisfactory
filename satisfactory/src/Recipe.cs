using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfactory
{
    public class Recipe
    {
        public MachineType buildingDeviceType;
        public Item product;
        public List<Item> input;
        private int timeInSeconds;

        public Recipe(Item output, List<Item> input, int timeInSeconds, MachineType buildingDeviceType)
        {
            this.product = output;
            this.input = input;
            this.timeInSeconds = timeInSeconds;
            this.buildingDeviceType = buildingDeviceType;
        }

        public Recipe(Item output, int timeInSeconds, MachineType buildingDeviceType)
        {
            this.product = output;
            this.input = new List<Item>();
            this.timeInSeconds = timeInSeconds;
            this.buildingDeviceType = buildingDeviceType;
        }

        public int getIngredientQuantity(ItemType type)
        {
            foreach(var item in input)
            {
                if (item.type == type)
                    return item.quantity;
            }
            throw new NotImplementedException();
        }

        public ItemType getProducedItemType()
        {
            return product.type;
        }

        public double getProductionPerMinute()
        {
            return (product.quantity * 60) / timeInSeconds;
        }

        public string toString()
        {
            var str = "Product: " + product.quantity + " x " + product.type + "\n";
               
            if (input.Count != 0)
                str = str + "Ingredients: ";

            foreach (var ingridient in input)
                str = str + ingridient.quantity + " x " + ingridient.type + ", ";

            str = str + "\nDevice: " + buildingDeviceType;
            str = str + "\nProduction per minute: " + getProductionPerMinute() + "\n";

            return str;

        }
    }
}
