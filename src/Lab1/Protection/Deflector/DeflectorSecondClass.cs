using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Obstacle;

namespace ObjectOrientedProgramming.Lab1.Protection.Deflector;

public class DeflectorSecondClass : BaseDeflector
{
    public DeflectorSecondClass(ReadOnlyCollection<BaseObstacle>? protectableObstacles = null, BaseProtection? modification = null)
        : base(protectableObstacles ?? ConstantHolder.DeflectorSecondClassDefend, modification)
    {
    }
}