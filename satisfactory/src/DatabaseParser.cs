using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;


namespace Satisfactory
{
    public class DatabaseParser
    {
        private Dictionary<string, ItemType> itemNames;
        private Dictionary<string, MachineType> machineNames;
        private JObject satisfactoryDatabase;

        public DatabaseParser(string path)
        {
            satisfactoryDatabase = loadFromFile(path);

            initializeItemNames();
            initializeMachineNames();
        }

        private JObject loadFromFile(string path)
        {
            var jsonObject = JObject.Parse(File.ReadAllText(path));
            return jsonObject;
        }

        public Dictionary<ItemType, List<Recipe>> getRecipes()
        {
            var recipes = new Dictionary<ItemType, List<Recipe>>();

            foreach (JObject itemRecipe in satisfactoryDatabase["recipes"])
            {
                var inMachine = itemRecipe["inMachine"].ToString() == "True";

                if (inMachine)
                {
                    var product = createItem(itemRecipe["products"][0]);
                    var input = new List<Item>();

                    foreach (JObject ingredient in itemRecipe["ingredients"])
                        input.Add(createItem(ingredient));

                    var timeInSeconds = (int) itemRecipe["time"];
                    var machine = machineNames[itemRecipe["producedIn"][0].ToString()];

                    if (!recipes.ContainsKey(product.type))
                        recipes[product.type] = new List<Recipe>();

                    recipes[product.type].Add(new Recipe(product, input, timeInSeconds, machine));
                }
            }

            foreach(JObject miner in satisfactoryDatabase["miners"])
            {
                var minerType = machineNames[miner["className"].ToString()];
                var timeInSeconds = (int) ((double) miner["extractCycleTime"] * 100);
                var amount = (int) ((double) miner["itemsPerCycle"] * 100);

                foreach (var allowedResource in miner["allowedResources"])
                {
                    var resourceType = itemNames[allowedResource.ToString()];

                    if (!recipes.ContainsKey(resourceType))
                        recipes[resourceType] = new List<Recipe>();

                    recipes[resourceType].Add(new Recipe(new Item(resourceType, amount), timeInSeconds, minerType));
                }
            }

            return recipes;
        }

        public Dictionary<MachineType, double> getMachines()
        {
            var machines = new Dictionary<MachineType, double>();

            foreach (JObject building in satisfactoryDatabase["buildings"])
            {
                var key = building["className"].ToString();

                if (machineNames.ContainsKey(key))
                {
                    var powerConsumption = (double) building["metadata"]["powerConsumption"];
                    machines[machineNames[key]] = powerConsumption;
                }
            }

            return machines;
        }

        private Item createItem(JToken jsonItemObject)
        {
            var name = jsonItemObject["item"].ToString();
            var itemType = itemNames[name];
            var itemAmount = (int) jsonItemObject["amount"];
            return new Item(itemType, itemAmount);
        }

        private void initializeMachineNames()
        {
            machineNames = new Dictionary<string, MachineType>();

            machineNames["Desc_AssemblerMk1_C"] =  MachineType.assemblerMK1;
            machineNames["Desc_ManufacturerMk1_C"] = MachineType.manufacturerMK1;
            machineNames["Desc_ConstructorMk1_C"] = MachineType.constructorMK1;
            machineNames["Desc_OilRefinery_C"] = MachineType.refinery;
            machineNames["Desc_FoundryMk1_C"] = MachineType.foundryMK1;
            machineNames["Desc_Packager_C"] = MachineType.packager;
            machineNames["Desc_SmelterMk1_C"] = MachineType.smelterMK1;
            machineNames["Build_MinerMk1_C"] = MachineType.minerMK1;
            machineNames["Build_MinerMk2_C"] = MachineType.minerMK2;
            machineNames["Build_MinerMk3_C"] = MachineType.minerMK3;
            machineNames["Build_OilPump_C"] = MachineType.oilPump;
            machineNames["Build_WaterPump_C"] = MachineType.waterPump;
            machineNames["Desc_MinerMk1_C"] = MachineType.minerMK1;
            machineNames["Desc_MinerMk2_C"] = MachineType.minerMK2;
            machineNames["Desc_MinerMk3_C"] = MachineType.minerMK3;
            machineNames["Desc_OilPump_C"] = MachineType.oilPump;
            machineNames["Desc_WaterPump_C"] = MachineType.waterPump;

        }

        private void initializeItemNames()
        {
            itemNames = new Dictionary<string, ItemType>();

            itemNames["Desc_FlowerPetals_C"] = ItemType.flowerPetals;
            itemNames["Desc_OreUranium_C"] = ItemType.uraniumOre;
            itemNames["Desc_Crystal_mk3_C"] = ItemType.crystalMK3;
            itemNames["Desc_Crystal_mk2_C"] = ItemType.crystalMK2;
            itemNames["Desc_Crystal_C"] = ItemType.crystal;
            itemNames["Desc_Mycelia_C"] = ItemType.mycelia;
            itemNames["Desc_Leaves_C"] = ItemType.leaves;
            itemNames["Desc_SpitterParts_C"] = ItemType.spitterParts;
            itemNames["Desc_HogParts_C"] = ItemType.hogParts;
            itemNames["Desc_OreBauxite_C"] = ItemType.bauxiteOre;
            itemNames["Desc_RawQuartz_C"] = ItemType.rawQuartz;
            itemNames["Desc_OreGold_C"] = ItemType.goldOre;
            itemNames["Desc_Sulfur_C"] = ItemType.sulfur;
            itemNames["BP_EquipmentDescriptorBeacon_C"] = ItemType.equipmentDescriptorBeacon;
            itemNames["Desc_AluminaSolution_C"] = ItemType.aluminaSolution;
            itemNames["Desc_AluminumIngot_C"] = ItemType.aluminumIngot;
            itemNames["Desc_AluminumPlateReinforced_C"] = ItemType.aluminumPlateReinforced;
            itemNames["Desc_AluminumPlate_C"] = ItemType.aluminumPlate;
            itemNames["Desc_AluminumScrap_C"] = ItemType.aluminumScrap;
            itemNames["Desc_Battery_C"] = ItemType.battery;
            itemNames["Desc_Biofuel_C"] = ItemType.biofuel;
            itemNames["Desc_Cable_C"] = ItemType.cable;
            itemNames["Desc_CartridgeStandard_C"] = ItemType.cartridgeStandard;
            itemNames["Desc_Cement_C"] = ItemType.cement;
            itemNames["Desc_CircuitBoardHighSpeed_C"] = ItemType.circuitBoardHighSpeed;
            itemNames["Desc_CircuitBoard_C"] = ItemType.circuitBoard;
            itemNames["Desc_Coal_C"] = ItemType.coal;
            itemNames["Desc_ColorCartridge_C"] = ItemType.colorCartridge;
            itemNames["Desc_CompactedCoal_C"] = ItemType.compactedCoal;
            itemNames["Desc_ComputerSuper_C"] = ItemType.computerSuper;
            itemNames["Desc_Computer_C"] = ItemType.computer;
            itemNames["Desc_CopperIngot_C"] = ItemType.copperIngot;
            itemNames["Desc_CopperSheet_C"] = ItemType.copperSheet;
            itemNames["Desc_CrystalOscillator_C"] = ItemType.crystalOscillator;
            itemNames["Desc_CrystalShard_C"] = ItemType.crystalShard;
            itemNames["Desc_ElectromagneticControlRod_C"] = ItemType.electromagneticControlRod;
            itemNames["Desc_Fabric_C"] = ItemType.fabric;
            itemNames["Desc_Filter_C"] = ItemType.filter;
            itemNames["Desc_FluidCanister_C"] = ItemType.fluidCanister;
            itemNames["Desc_Fuel_C"] = ItemType.fuel;
            itemNames["Desc_GenericBiomass_C"] = ItemType.genericBiomass;
            itemNames["Desc_GoldIngot_C"] = ItemType.goldIngot;
            itemNames["Desc_Gunpowder_C"] = ItemType.gunpowder;
            itemNames["Desc_HazmatFilter_C"] = ItemType.hazmatFilter;
            itemNames["Desc_HeavyOilResidue_C"] = ItemType.heavyOilResidue;
            itemNames["Desc_HighSpeedConnector_C"] = ItemType.highSpeedConnector;
            itemNames["Desc_HighSpeedWire_C"] = ItemType.highSpeedWire;
            itemNames["Desc_IronIngot_C"] = ItemType.ironIngot;
            itemNames["Desc_IronPlateReinforced_C"] = ItemType.ironPlateReinforced;
            itemNames["Desc_IronPlate_C"] = ItemType.ironPlate;
            itemNames["Desc_IronRod_C"] = ItemType.ironRod;
            itemNames["Desc_IronScrew_C"] = ItemType.ironScrew;
            itemNames["Desc_LiquidBiofuel_C"] = ItemType.liquidBiofuel;
            itemNames["Desc_LiquidFuel_C"] = ItemType.liquidFuel;
            itemNames["Desc_LiquidOil_C"] = ItemType.liquidOil;
            itemNames["Desc_LiquidTurboFuel_C"] = ItemType.liquidTurboFuel;
            itemNames["Desc_ModularFrameHeavy_C"] = ItemType.modularFrameHeavy;
            itemNames["Desc_ModularFrameLightweight_C"] = ItemType.modularFrameLightweight;
            itemNames["Desc_ModularFrame_C"] = ItemType.modularFrame;
            itemNames["Desc_MotorLightweight_C"] = ItemType.motorLightweight;
            itemNames["Desc_Motor_C"] = ItemType.motor;
            itemNames["Desc_NobeliskExplosive_C"] = ItemType.nobeliskExplosive;
            itemNames["Desc_NuclearFuelRod_C"] = ItemType.nuclearFuelRod;
            itemNames["Desc_PackagedBiofuel_C"] = ItemType.packagedBiofuel;
            itemNames["Desc_PackagedOilResidue_C"] = ItemType.packagedOilResidue;
            itemNames["Desc_PackagedOil_C"] = ItemType.packagedOil;
            itemNames["Desc_PackagedWater_C"] = ItemType.packagedWater;
            itemNames["Desc_PetroleumCoke_C"] = ItemType.petroleumCoke;
            itemNames["Desc_Plastic_C"] = ItemType.plastic;
            itemNames["Desc_PolymerResin_C"] = ItemType.polymerResin;
            itemNames["Desc_QuartzCrystal_C"] = ItemType.quartzCrystal;
            itemNames["Desc_Rotor_C"] = ItemType.rotor;
            itemNames["Desc_Rubber_C"] = ItemType.rubber;
            itemNames["Desc_Silica_C"] = ItemType.silica;
            itemNames["Desc_SpaceElevatorPart_1_C"] = ItemType.spaceElevatorPart1;
            itemNames["Desc_SpaceElevatorPart_2_C"] = ItemType.spaceElevatorPart2;
            itemNames["Desc_SpaceElevatorPart_3_C"] = ItemType.spaceElevatorPart3;
            itemNames["Desc_SpaceElevatorPart_4_C"] = ItemType.spaceElevatorPart4;
            itemNames["Desc_SpaceElevatorPart_5_C"] = ItemType.spaceElevatorPart5;
            itemNames["Desc_SpikedRebar_C"] = ItemType.spikedRebar;
            itemNames["Desc_Stator_C"] = ItemType.stator;
            itemNames["Desc_SteelIngot_C"] = ItemType.steelIngot;
            itemNames["Desc_SteelPipe_C"] = ItemType.steelPipe;
            itemNames["Desc_SteelPlateReinforced_C"] = ItemType.steelPlateReinforced;
            itemNames["Desc_SteelPlate_C"] = ItemType.steelPlate;
            itemNames["Desc_SulfuricAcid_C"] = ItemType.sulfuricAcid;
            itemNames["Desc_TurboFuel_C"] = ItemType.turboFuel;
            itemNames["Desc_UraniumCell_C"] = ItemType.uraniumCell;
            itemNames["Desc_UraniumPellet_C"] = ItemType.uraniumPellet;
            itemNames["Desc_Water_C"] = ItemType.water;
            itemNames["Desc_Wood_C"] = ItemType.wood;
            itemNames["Desc_OreIron_C"] = ItemType.ironOre;
            itemNames["Desc_Wire_C"] = ItemType.wire;
            itemNames["Desc_Stone_C"] = ItemType.stone;
            itemNames["Desc_OreCopper_C"] = ItemType.copperOre;
        }


    }
}
