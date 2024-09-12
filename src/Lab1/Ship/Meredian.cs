using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Engine;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Protection.Deflector;
using ObjectOrientedProgramming.Lab1.Protection.Hull;

namespace ObjectOrientedProgramming.Lab1.Ship;

public class Meredian : BaseShip
{
    public Meredian(ReadOnlyCollection<IMovable>? engines = null, BaseHull? hull = null, double sizeClass = ConstantHolder.MeredianSize, BaseDeflector? deflector = null)
        : base(engines ?? ConstantHolder.MeredianEngines, hull ?? ConstantHolder.MeredianHull, sizeClass, deflector ?? ConstantHolder.MeredianDeflector)
    {
    }
}