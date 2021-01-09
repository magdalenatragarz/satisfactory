using System;
using System.Collections.Generic;
using System.Text;
using Satisfactory;

namespace Satisfactory
{
    public abstract class Calculator
    {

        public ConstructionTree adjustComponentTreeToWantedProduction(ConstructionTree tree, double wantedProductionPerMinute)
        {
            //TO DO clean
            tree.root.wantedProductionPerMinute = wantedProductionPerMinute;

            double machinesCount = (double)tree.root.wantedProductionPerMinute / (double)tree.root.getBaseProductionPerMinute();
            double newClockSpeedSum = machinesCount * 100.0;
            int newMachinesCount = (int) Math.Ceiling(machinesCount);


            for (var i = tree.root.buildingDevices.Count; i < newMachinesCount; i++)
                tree.root.addMachine();

            tree.root.updateBuildingDevicesClockSpeedAndAlignPowerUsage(newClockSpeedSum / newMachinesCount);

            foreach (var ingredient in tree.ingredients)
            {
                var ingredientQuantity = tree.root.getIngredientQuantity(ingredient.root.getItemType());
                var ingredientBaseProduction = wantedProductionPerMinute;
                var produced = tree.root.getProducedProduct();
                var productionForIngredientToBeAligned = ingredientQuantity * ingredientBaseProduction / produced;
                adjustComponentTreeToWantedProduction(ingredient, productionForIngredientToBeAligned);
            }
                

            return adjustComponentTreeToAdditionalCondition(tree);
        }

        public abstract ConstructionTree adjustComponentTreeToAdditionalCondition(ConstructionTree tree);

    }
}
