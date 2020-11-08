using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfactory
{
    public static class Database
    {


        public static MachineInfo assembler = new MachineInfo(MachineType.assembler, 15.0);
        public static MachineInfo minerMK1 = new MachineInfo(MachineType.minerMK1, 15.0);
        public static MachineInfo smelter = new MachineInfo(MachineType.smelter, 15.0);
        public static MachineInfo constructor = new MachineInfo(MachineType.constructor, 15.0);

        public static ComponentInfo modularFrameInfo = new ComponentInfo(ItemType.modularFrame, assembler, 2);
        public static ComponentInfo ironOreInfo = new ComponentInfo(ItemType.ironOre, minerMK1, 30);
        public static ComponentInfo screwInfo = new ComponentInfo(ItemType.screw, constructor, 40);
        public static ComponentInfo ironInglotInfo = new ComponentInfo(ItemType.ironInglot, smelter, 30);
        public static ComponentInfo ironPlateInfo = new ComponentInfo(ItemType.ironPlate, constructor, 20);
        public static ComponentInfo ironRodInfo = new ComponentInfo(ItemType.ironRod, constructor, 15);
        public static ComponentInfo reinforcedIronPlateInfo = new ComponentInfo(ItemType.reinforcedIronPlate, assembler, 5);



    }
}
