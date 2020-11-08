using System;
using System.Collections.Generic;
using System.Text;
using Satisfactory;

namespace Satisfactory
{
    public abstract class Calculator
    {

        public ConstructionTree adjustComponentTreeToWantedProduction(ConstructionTree component, int wantedProductionPerMinute)
        {
            //TO DO clean
            component.wantedProductionPerMinute = wantedProductionPerMinute;

            double machinesCount = (double) component.wantedProductionPerMinute / (double) component.info.baseProductionPerMinute;
            double newClockSpeedSum = machinesCount * 100.0;
            int newMachinesCount = (int) Math.Ceiling(machinesCount);


            for (var i = component.buildingDevices.Count; i < newMachinesCount; i++)
                component.addMachine();

            component.updateMachinesClockSpeedAndAlignPowerUsage(newClockSpeedSum / newMachinesCount);

            foreach (var ingredient in component.ingredients)
                adjustComponentTreeToWantedProduction(ingredient, component.wantedProductionPerMinute * ingredient.quantity);

            return adjustComponentTreeToAdditionalCondition(component);
        }

        public abstract ConstructionTree adjustComponentTreeToAdditionalCondition(ConstructionTree component);

    }
}
