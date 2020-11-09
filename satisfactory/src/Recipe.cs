using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfactory
{
    public class Recipe
    {
        public MachineType buildingDeviceType;
        private Item output;
        private List<Item> input;
        private int timeInSeconds;

        public Recipe(Item output, List<Item> input, int timeInSeconds, MachineType buildingDeviceType)
        {
            this.output = output;
            this.input = input;
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

        public ItemType getProducedItem()
        {
            return output.type;
        }

        public double getProductionPerMinute()
        {
            return (output.quantity * 60) / timeInSeconds;
        }
    }
}
