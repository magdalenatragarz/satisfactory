using Microsoft.VisualStudio.TestTools.UnitTesting;
using Satisfactory;

namespace SatisfactoryTests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void realModularFrame()
        {

            var ironOreForIronInglotForIronPlateTree = new ConstructionTree(Database.get(ItemType.ironOre));
            var ironOreForIronInglotForIronRodForScrewTree = new ConstructionTree(Database.get(ItemType.ironOre));
            var ironOreForIronInglotForIronRodForModularFrameTree = new ConstructionTree(Database.get(ItemType.ironOre));

            var ironInglotForIronPlateTree = new ConstructionTree(Database.get(ItemType.ironInglot));
            var ironInglotForIronRodForScrewTree = new ConstructionTree(Database.get(ItemType.ironInglot));
            var ironInglotForIronRodForModularFrameTree = new ConstructionTree(Database.get(ItemType.ironInglot));

            var ironPlateForReinforcedIronPlateTree = new ConstructionTree(Database.get(ItemType.ironPlate));
            var ironRodForScrewTree = new ConstructionTree(Database.get(ItemType.ironRod));
            var ironRodForModularFrameTree = new ConstructionTree(Database.get(ItemType.ironRod));
            var screwForReinforcedIronPlateTree = new ConstructionTree(Database.get(ItemType.screw));

            var modularFrameTree = new ConstructionTree(Database.get(ItemType.modularFrame));
            var reinforcedIronPlateForModularFrameTree = new ConstructionTree(Database.get(ItemType.reinforcedIronPlate));

            ironInglotForIronPlateTree.addIngredient(ironOreForIronInglotForIronPlateTree);
            ironPlateForReinforcedIronPlateTree.addIngredient(ironInglotForIronPlateTree);
            reinforcedIronPlateForModularFrameTree.addIngredient(ironPlateForReinforcedIronPlateTree);
            modularFrameTree.addIngredient(reinforcedIronPlateForModularFrameTree);

            ironInglotForIronRodForScrewTree.addIngredient(ironOreForIronInglotForIronRodForScrewTree);
            ironRodForScrewTree.addIngredient(ironInglotForIronRodForScrewTree);
            screwForReinforcedIronPlateTree.addIngredient(ironRodForScrewTree);
            reinforcedIronPlateForModularFrameTree.addIngredient(screwForReinforcedIronPlateTree);

            ironInglotForIronRodForModularFrameTree.addIngredient(ironOreForIronInglotForIronRodForModularFrameTree);
            ironRodForModularFrameTree.addIngredient(ironInglotForIronRodForModularFrameTree);
            modularFrameTree.addIngredient(ironRodForModularFrameTree);

            var wantedProductionPerMinute = 2;
            var basicCalculator = new BasicCalculator();
            basicCalculator.adjustComponentTreeToWantedProduction(modularFrameTree, wantedProductionPerMinute);

            Assert.AreEqual(reinforcedIronPlateForModularFrameTree.root.buildingDevices.Count, 2);
            Assert.AreEqual(reinforcedIronPlateForModularFrameTree.root.buildingDevices[0].getClockSpeed(), 60.0);

            Assert.AreEqual(ironRodForModularFrameTree.root.buildingDevices.Count, 2);
            Assert.AreEqual(ironRodForModularFrameTree.root.buildingDevices[0].getClockSpeed(), 80.0);

            Assert.AreEqual(ironInglotForIronPlateTree.root.buildingDevices.Count, 4);
            Assert.AreEqual(ironInglotForIronPlateTree.root.buildingDevices[0].getClockSpeed(), 90.0);

            Assert.AreEqual(screwForReinforcedIronPlateTree.root.buildingDevices.Count, 2);
            Assert.AreEqual(screwForReinforcedIronPlateTree.root.buildingDevices[0].getClockSpeed(), 90.0);

            Assert.AreEqual(ironOreForIronInglotForIronRodForScrewTree.root.buildingDevices.Count, 3);
            Assert.AreEqual(ironOreForIronInglotForIronRodForScrewTree.root.buildingDevices[0].getClockSpeed(), 80.0);

        }

    }
}
