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
			return "";
		}

		public void addIngredient(ConstructionTree ingredient)
		{
			ingredients.Add(ingredient);
		}

	}

}

