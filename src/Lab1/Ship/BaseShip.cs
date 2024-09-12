using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Engine;
using ObjectOrientedProgramming.Lab1.Protection.Deflector;
using ObjectOrientedProgramming.Lab1.Protection.Hull;

namespace ObjectOrientedProgramming.Lab1.Ship;

public abstract class BaseShip
{
    protected BaseShip(ReadOnlyCollection<IMovable>? engines, BaseHull? hull, double sizeClass, BaseDeflector? deflector, Status status = Status.Active)
    {
        Engines = engines;
        Hull = hull;
        Deflector = deflector;
        SizeClass = sizeClass;
        Status = status;
    }

    public ReadOnlyCollection<IMovable>? Engines { get; }
    public BaseHull? Hull { get; }
    public BaseDeflector? Deflector { get; }
    public double SizeClass { get; }
    public Status Status { get; set; }
}