using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Obstacle;

namespace ObjectOrientedProgramming.Lab1.Protection.Deflector;

public class DeflectorThirdClass : BaseDeflector
{
    public DeflectorThirdClass(ReadOnlyCollection<BaseObstacle>? protectableObstacles = null, BaseProtection? modification = null)
        : base(protectableObstacles ?? ConstantHolder.DeflectorThirdClassDefend, modification)
    {
    }
}