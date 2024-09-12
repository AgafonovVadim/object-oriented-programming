using System.Collections.ObjectModel;
using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public class Chipset : AbstractComponent
{
    public Chipset(ReadOnlyCollection<int> memoryFrequencies, bool xmpSupport)
    {
        MemoryFrequencies = memoryFrequencies;
        XmpSupport = xmpSupport;
    }

    public ReadOnlyCollection<int> MemoryFrequencies { get; private set; }
    public bool XmpSupport { get; private set; }
    public override string CountConfig()
    {
        var config = new StringBuilder();
        foreach (int frequency in MemoryFrequencies)
        {
            config.Append(frequency);
        }

        config.Append(XmpSupport);
        return config.ToString();
    }
}