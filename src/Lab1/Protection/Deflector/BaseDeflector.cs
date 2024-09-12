using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Obstacle;

namespace ObjectOrientedProgramming.Lab1.Protection.Deflector;

public abstract class BaseDeflector : BaseProtection
{
    protected BaseDeflector(ReadOnlyCollection<BaseObstacle>? protectableObstacles, BaseProtection? modification = null)
        : base(protectableObstacles, modification)
    {
    }
}