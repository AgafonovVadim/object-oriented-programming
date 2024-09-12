using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Obstacle;

namespace ObjectOrientedProgramming.Lab1.Protection;

public abstract class BaseModification : BaseProtection
{
    protected BaseModification(ReadOnlyCollection<BaseObstacle>? protectableObstacles)
        : base(protectableObstacles)
    {
    }
}