using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfactory
{
    public class MachineInfo
    {
        public MachineInfo(MachineType type, double basePowerUsage)
        {
            this.type = type;
            this.basePowerUsage = basePowerUsage;
        }

        public MachineType type;
        public double basePowerUsage;
    }
}
