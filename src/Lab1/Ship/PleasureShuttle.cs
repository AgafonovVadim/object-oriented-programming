using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Engine;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Protection.Deflector;
using ObjectOrientedProgramming.Lab1.Protection.Hull;

namespace ObjectOrientedProgramming.Lab1.Ship;

public class PleasureShuttle : BaseShip
{
    public PleasureShuttle(ReadOnlyCollection<IMovable>? engines = null, BaseHull? hull = null, double sizeClass = ConstantHolder.PleasureShuttleSize, BaseDeflector? deflector = null)
        : base(engines ?? ConstantHolder.PleasureShuttleEngines, hull ?? ConstantHolder.PleasureShuttleHull, sizeClass, deflector /* ?? ConstantHolder.PleasureShuttleDeflector */)
    {
    }
}