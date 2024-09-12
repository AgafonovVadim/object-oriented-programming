using System.Collections.ObjectModel;
using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public class XmpProfile : AbstractComponent
{
    public XmpProfile(ReadOnlyCollection<int> timings, double voltage, int frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public ReadOnlyCollection<int> Timings { get; private set; }
    public double Voltage { get; private set; }
    public int Frequency { get; private set; }
    public override string CountConfig()
    {
        StringBuilder config = new StringBuilder().Append(Voltage).Append(Frequency);
        foreach (int timing in Timings)
        {
            config.Append(timing);
        }

        return config.ToString();
    }
}