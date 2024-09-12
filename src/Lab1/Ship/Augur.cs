using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Engine;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Protection.Deflector;
using ObjectOrientedProgramming.Lab1.Protection.Hull;

namespace ObjectOrientedProgramming.Lab1.Ship;

public class Augur : BaseShip
{
    public Augur(ReadOnlyCollection<IMovable>? engines = null, BaseHull? hull = null, double sizeClass = ConstantHolder.AugurSize, BaseDeflector? deflector = null)
        : base(engines ?? ConstantHolder.AugurEngines, hull ?? ConstantHolder.AugurHull, sizeClass, deflector ?? ConstantHolder.AugurDeflector)
    {
    }
}