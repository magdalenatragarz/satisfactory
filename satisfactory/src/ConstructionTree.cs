using System;
using System.Collections.Generic;

namespace Satisfactory
{
	public class ConstructionTree
	{
		public int wantedProductionPerMinute;
		public int quantity = 1;
		public ComponentInfo info;
		public List<Machine> buildingDevices;
		public List<ConstructionTree> ingredients;

		public ConstructionTree(ComponentInfo info, int wantedProductionctionPerMinute) 
		{
			this.info = info;
			this.wantedProductionPerMinute = wantedProductionctionPerMinute;

			ingredients = new List<ConstructionTree>();
			buildingDevices = new List<Machine>();
		}
		public ConstructionTree(ComponentInfo info)
		{
			this.info = info;
			this.wantedProductionPerMinute = info.baseProductionPerMinute;

			ingredients = new List<ConstructionTree>();
			buildingDevices = new List<Machine>();
		}

		public string getComponentTreeDescription()
		{
			return "";
		}

		public void addMachine()
		{
			buildingDevices.Add(new Machine(info.buildingDeviceInfo));
		}

		public void updateMachinesClockSpeedAndAlignPowerUsage(double machinesClockSpeed)
		{
			foreach (var buildingDevice in buildingDevices)
				buildingDevice.updateClockSpeedAndAlignPowerUsage(machinesClockSpeed);
		}

		public void addIngredient(ConstructionTree ingredient, int quantity)
		{
			ingredient.quantity = quantity;
			ingredients.Add(ingredient);
		}

	}

}

