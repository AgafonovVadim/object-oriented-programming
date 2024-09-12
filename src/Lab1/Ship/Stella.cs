using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Engine;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Protection.Deflector;
using ObjectOrientedProgramming.Lab1.Protection.Hull;

namespace ObjectOrientedProgramming.Lab1.Ship;

public class Stella : BaseShip
{
    public Stella(ReadOnlyCollection<IMovable>? engines = null, BaseHull? hull = null, double sizeClass = ConstantHolder.StellaSize, BaseDeflector? deflector = null)
        : base(engines ?? ConstantHolder.StellaEngines, hull ?? ConstantHolder.StellaHull, sizeClass, deflector ?? ConstantHolder.StellaDeflector)
    {
    }
}