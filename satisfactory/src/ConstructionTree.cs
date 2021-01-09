using System;
using System.Collections.Generic;

namespace Satisfactory
{
	public class ConstructionTree
	{
		public ConstructionNode root;
		public List<ConstructionTree> ingredients;

		public ConstructionTree(ConstructionNode root) 
		{
			this.root = root;
			ingredients = new List<ConstructionTree>();
		}

		public string getComponentTreeDescription()
		{
			var initialDepth = 1;


			return "Power usage: " + Math.Round(getTotalPowerUsage(), 2) + "\n" + root.toString() + getIngredientsDescription(initialDepth);
		}

		private string getIngredientsDescription(int depth)
		{
			var str = "";
			var tabs = "";

			for (var i = 0; i < depth; i++)
				tabs = tabs + "\t";

			foreach(var ingredient in ingredients)
				str = str + "\n" + tabs + ingredient.root.toString() + ingredient.getIngredientsDescription(depth + 1);

			return str;
		}

		public void addIngredient(ConstructionTree ingredient)
		{
			ingredients.Add(ingredient);
		}

		private double getTotalPowerUsage()
		{
			var powerUsage = root.getTotalPowerUsage();
			foreach (var ingredient in ingredients)
				powerUsage = powerUsage + ingredient.getTotalPowerUsage();

			return powerUsage;
		}

	}

}

