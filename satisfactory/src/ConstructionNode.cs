using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfactory
{
    public class ConstructionNode
    {
        private Recipe recipe;
        public List<Machine> buildingDevices;
        public double wantedProductionPerMinute;
        
        public ConstructionNode(Recipe recipe)
        {
            this.recipe = recipe;
            this.buildingDevices = new List<Machine>();
        }

        public void addMachine()
        {
            buildingDevices.Add(new Machine(recipe.buildingDeviceType));
        }

        public void updateBuildingDevicesClockSpeedAndAlignPowerUsage(double clockSpeed)
        {
            foreach (var buildingDevice in buildingDevices)
                buildingDevice.updateClockSpeedAndAlignPowerUsage(clockSpeed);

        }

        public ItemType getItemType()
        {
            return recipe.getProducedItem();
        }

        public int getIngredientQuantity(ItemType type)
        {
            return recipe.getIngredientQuantity(type);
        }



        public double getBaseProductionPerMinute()
        {
            return recipe.getProductionPerMinute();
        }
    }
}
