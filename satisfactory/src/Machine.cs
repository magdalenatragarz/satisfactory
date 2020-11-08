using System;

namespace Satisfactory
{
	public class Machine
	{
		private double powerUsageAfterModifications;
		private double clockSpeedAfterModifications;

		public Machine(MachineInfo info)
		{
			this.powerUsageAfterModifications = info.basePowerUsage;
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
