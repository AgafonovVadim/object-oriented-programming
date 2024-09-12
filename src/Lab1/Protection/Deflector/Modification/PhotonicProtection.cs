using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Obstacle;

namespace ObjectOrientedProgramming.Lab1.Protection.Deflector.Modification;

public class PhotonicProtection : BaseDeflector
{
    public PhotonicProtection(ReadOnlyCollection<BaseObstacle>? protectableObstacles = null)
        : base(protectableObstacles ?? ConstantHolder.PhotonicDeflectorOutbreakDefend)
    {
    }
}