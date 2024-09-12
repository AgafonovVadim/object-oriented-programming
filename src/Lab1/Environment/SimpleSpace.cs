using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Engine;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Obstacle;

namespace ObjectOrientedProgramming.Lab1.Environment;

public class SimpleSpace : BaseEnvironment
{
    public SimpleSpace(int distance = 0, ReadOnlyCollection<BaseObstacle>? possibleObstacles = null, ReadOnlyCollection<IMovable>? requiredEngine = null)
        : base(distance, possibleObstacles ?? ConstantHolder.SimpleSpaceObstacles, requiredEngine ?? ConstantHolder.SimpleSpaceRequiredEngines)
    {
    }

    public override int GetTypeHashCode()
    {
        return new SimpleSpace().GetType().GetHashCode();
    }
}