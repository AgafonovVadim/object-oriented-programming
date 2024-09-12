using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Obstacle;

namespace ObjectOrientedProgramming.Lab1.Protection.Hull.Modification;

public class AntineutrinoEmitter : BaseHull
{
    public AntineutrinoEmitter(ReadOnlyCollection<BaseObstacle>? protectableObstacles = null)
        : base(protectableObstacles ?? ConstantHolder.AntineutrinoEmitterDefend)
    {
    }
}