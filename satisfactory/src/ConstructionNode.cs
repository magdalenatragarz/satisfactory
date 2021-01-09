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
            return recipe.getProducedItemType();
        }

        public int getIngredientQuantity(ItemType type)
        {
            return recipe.getIngredientQuantity(type);
        }

        public int getProducedProduct()
        {
            return recipe.product.quantity;
        }

        public double getTotalPowerUsage()
        {
            var powerUsage = 0.0;

            foreach (var machine in buildingDevices)
                powerUsage = powerUsage + machine.getPowerUsage();

            return powerUsage;
        }

        public double getBaseProductionPerMinute()
        {
            return recipe.getProductionPerMinute();
        }

        public string toString()
        {
            return "To build " + recipe.getProducedItemType() + ", machines (" + recipe.buildingDeviceType + ") used: " + buildingDevices.Count
                + ", clockSpeed set to " + buildingDevices[0].getClockSpeed() + ", " + "wanted production per minute " + wantedProductionPerMinute + "\n";
        }

    }
}
