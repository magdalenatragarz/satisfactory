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
            var ironOreForIronInglotForIronPlate = new ConstructionTree(Database.ironOreInfo);
            var ironInglotForIronPlate = new ConstructionTree(Database.ironInglotInfo);
            ironInglotForIronPlate.addIngredient(ironOreForIronInglotForIronPlate, 1);

            var ironPlateForReinforcedIronPlate = new ConstructionTree(Database.ironPlateInfo);
            ironPlateForReinforcedIronPlate.addIngredient(ironInglotForIronPlate, 3);

            var ironOreForIronInglotForScrew = new ConstructionTree(Database.ironOreInfo);
            var ironInglotForIronRodForScrew = new ConstructionTree(Database.ironInglotInfo);
            ironInglotForIronRodForScrew.addIngredient(ironOreForIronInglotForScrew, 1);

            var ironRodForScrew = new ConstructionTree(Database.ironRodInfo);
            ironRodForScrew.addIngredient(ironInglotForIronRodForScrew, 1);

            var screwForReinforcedIronPlate = new ConstructionTree(Database.screwInfo);
            screwForReinforcedIronPlate.addIngredient(ironRodForScrew, 1);

            var reinforcedIronPlateForModularFrame = new ConstructionTree(Database.reinforcedIronPlateInfo);
            reinforcedIronPlateForModularFrame.addIngredient(ironPlateForReinforcedIronPlate, 6);
            reinforcedIronPlateForModularFrame.addIngredient(screwForReinforcedIronPlate, 12);

            var ironOreForIronRod = new ConstructionTree(Database.ironOreInfo);
            var ironInglotForIronRod = new ConstructionTree(Database.ironInglotInfo);
            ironInglotForIronRod.addIngredient(ironOreForIronRod, 1);

            var ironRodForModularFrame = new ConstructionTree(Database.ironRodInfo);
            ironRodForModularFrame.addIngredient(ironInglotForIronRod, 12);

            var modularFrame = new ConstructionTree(Database.modularFrameInfo);
            modularFrame.addIngredient(reinforcedIronPlateForModularFrame, 3);
            modularFrame.addIngredient(ironRodForModularFrame, 12);

            var wantedProductionPerMinute = 2;
            var basicCalculator = new BasicCalculator();
            basicCalculator.adjustComponentTreeToWantedProduction(modularFrame, wantedProductionPerMinute);

            Assert.AreEqual(reinforcedIronPlateForModularFrame.buildingDevices.Count, 2);
            Assert.AreEqual(reinforcedIronPlateForModularFrame.buildingDevices[0].getClockSpeed(), 60.0);

            Assert.AreEqual(ironRodForModularFrame.buildingDevices.Count, 2);
            Assert.AreEqual(ironRodForModularFrame.buildingDevices[0].getClockSpeed(), 80.0);

            Assert.AreEqual(ironInglotForIronPlate.buildingDevices.Count, 4);
            Assert.AreEqual(ironInglotForIronPlate.buildingDevices[0].getClockSpeed(), 90.0);

            Assert.AreEqual(screwForReinforcedIronPlate.buildingDevices.Count, 2);
            Assert.AreEqual(screwForReinforcedIronPlate.buildingDevices[0].getClockSpeed(), 90.0);

            Assert.AreEqual(ironOreForIronInglotForScrew.buildingDevices.Count, 3);
            Assert.AreEqual(ironOreForIronInglotForScrew.buildingDevices[0].getClockSpeed(), 80.0);

        }

    }
}
