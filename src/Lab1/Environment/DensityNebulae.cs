using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Engine;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Obstacle;

namespace ObjectOrientedProgramming.Lab1.Environment;

public class DensityNebulae : BaseEnvironment
{
    public DensityNebulae(int distance = 0, ReadOnlyCollection<BaseObstacle>? possibleObstacles = null, ReadOnlyCollection<IMovable>? requiredEngine = null)
        : base(distance, possibleObstacles ?? ConstantHolder.DensityNebulaeObstacles, requiredEngine ?? ConstantHolder.DensityNebulaeRequiredEngines)
    {
    }

    public override int GetTypeHashCode()
    {
        return new DensityNebulae().GetType().GetHashCode();
    }
}