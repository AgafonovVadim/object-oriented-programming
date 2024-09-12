using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Environment;

namespace ObjectOrientedProgramming.Lab1.Route;

public class Route : BaseRoute
{
    public Route(ReadOnlyCollection<BaseEnvironment> path)
        : base(path)
    {
    }
}