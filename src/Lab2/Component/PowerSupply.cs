using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public class PowerSupply : AbstractComponent
{
    public PowerSupply(int peakPower)
    {
        PeakPower = peakPower;
    }

    public int PeakPower { get; private set; }

    public override string CountConfig()
    {
        return new StringBuilder().Append(PeakPower).ToString();
    }
}