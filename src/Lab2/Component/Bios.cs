using System.Collections.ObjectModel;
using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public class Bios : AbstractComponent
{
    public Bios(string type, string version, ReadOnlyCollection<string?> supportedProcessors)
    {
        Type = type;
        Version = version;
        SupportedProcessors = supportedProcessors;
    }

    public string Type { get; private set; }
    public string Version { get; private set; }
    public ReadOnlyCollection<string?> SupportedProcessors { get; private set; }
    public override string CountConfig()
    {
        return new StringBuilder().Append(Type).Append(Version).Append(SupportedProcessors).ToString();
    }
}