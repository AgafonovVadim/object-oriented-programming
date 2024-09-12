using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Engine;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Protection.Deflector;
using ObjectOrientedProgramming.Lab1.Protection.Hull;

namespace ObjectOrientedProgramming.Lab1.Ship;

public class Vaclas : BaseShip
{
    public Vaclas(ReadOnlyCollection<IMovable>? engines = null, BaseHull? hull = null, int sizeClass = 2, BaseDeflector? deflector = null)
        : base(engines ?? ConstantHolder.VaclasEngines, hull ?? ConstantHolder.VaclasHull, sizeClass, deflector ?? ConstantHolder.VaclasDeflector)
    {
    }
}