using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Obstacle;

namespace ObjectOrientedProgramming.Lab1.Protection.Hull;

public class HullSecondClass : BaseHull
{
    public HullSecondClass(ReadOnlyCollection<BaseObstacle>? protectableObstacles = null, BaseProtection? modification = null)
        : base(protectableObstacles ?? ConstantHolder.HullSecondClassDefend, modification)
    {
    }
}