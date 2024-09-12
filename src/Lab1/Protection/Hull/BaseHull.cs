using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Obstacle;

namespace ObjectOrientedProgramming.Lab1.Protection.Hull;

public abstract class BaseHull : BaseProtection
{
    protected BaseHull(ReadOnlyCollection<BaseObstacle>? protectableObstacles, BaseProtection? modification = null)
        : base(protectableObstacles, modification)
    {
    }
}