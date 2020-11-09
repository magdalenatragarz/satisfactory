using System;

namespace Satisfactory
{
	public class Machine
	{
		private MachineType type;
		private double powerUsageAfterModifications;
		private double clockSpeedAfterModifications;

		public Machine(MachineType type)
		{
			this.type = type;
			this.powerUsageAfterModifications = Database.getBasePowerUsage(type);
			this.clockSpeedAfterModifications = 100.0;
		}

		public void updateClockSpeedAndAlignPowerUsage(double clockSpeed)
		{
			this.clockSpeedAfterModifications = clockSpeed;
			alignPowerUsage(clockSpeed);
		}

		public double getClockSpeed()
		{
			return clockSpeedAfterModifications;
		}

		private void alignPowerUsage(double clockSpeed)
		{

		}

	}
}
