using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfactory
{
    public class BasicCalculator : Calculator
    {
        public override ConstructionTree adjustComponentTreeToAdditionalCondition(ConstructionTree component)
        {
           while (!areMachineCountsEqual(component))
           {
                adjustComponentTree(component);
           }

            return component;

        }

        private bool areMachineCountsEqual(ConstructionTree component)
        {
            var flag = true;

            foreach (var ingredient in component.ingredients)
            {
                if (component.root.buildingDevices.Count != ingredient.root.buildingDevices.Count)
                    flag = false;
            }

            return flag;
        }

        private ConstructionTree adjustComponentTree(ConstructionTree component)
        {
            foreach (var ingredient in component.ingredients)
            {
                if (ingredient.root.buildingDevices.Count > component.root.buildingDevices.Count)
                    setBuildingDevicesCount(component.root, ingredient.root.buildingDevices.Count);
                else
                    setBuildingDevicesCount(ingredient.root, component.root.buildingDevices.Count);

                adjustComponentTree(ingredient);
            }

            return component;
        }

        private void setBuildingDevicesCount(ConstructionNode node, int newBuildingDevicesCount)
        {
            var clockSpeedSum = 0.0;
            foreach (var device in node.buildingDevices)
                clockSpeedSum = clockSpeedSum + device.getClockSpeed();

            for (var i = node.buildingDevices.Count; i < newBuildingDevicesCount; i++)
                node.addMachine();

            node.updateBuildingDevicesClockSpeedAndAlignPowerUsage(clockSpeedSum / newBuildingDevicesCount);
        }
    }
}
