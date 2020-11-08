using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfactory

{
    public class ComponentInfo
    {
        public int baseProductionPerMinute;
        public ItemType type;
        public MachineInfo buildingDeviceInfo;
        public int quantity;
        public List<ComponentInfo> ingredientsInfo;

        public ComponentInfo(ItemType type, MachineInfo buildingDeviceInfo, int baseProductionPerMinute)
        {
            this.type = type;
            this.buildingDeviceInfo = buildingDeviceInfo;
            this.baseProductionPerMinute = baseProductionPerMinute;
            this.ingredientsInfo = new List<ComponentInfo>();
        }

        private ComponentInfo(ComponentInfo info, int quantity)
        {
            this.baseProductionPerMinute = info.baseProductionPerMinute;
            this.type = info.type;
            this.buildingDeviceInfo = info.buildingDeviceInfo;
            this.quantity = quantity;
            this.ingredientsInfo = new List<ComponentInfo>();
        }

        public void addIngredient(ComponentInfo info, int quantity)
        {
            ingredientsInfo.Add(new ComponentInfo(info, quantity));
        }

    }
}
