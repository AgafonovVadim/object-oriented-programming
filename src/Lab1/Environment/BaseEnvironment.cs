using System.Collections.Generic;
using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Engine;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Obstacle;

namespace ObjectOrientedProgramming.Lab1.Environment;

public abstract class BaseEnvironment
{
    protected BaseEnvironment(int distance, ReadOnlyCollection<BaseObstacle>? possibleObstacles = null, ReadOnlyCollection<IMovable>? requiredEngine = null)
    {
        Distance = distance;
        RequiredEngine = Service.EngineHandler(requiredEngine);
        PossibleObstacles = possibleObstacles;
    }

    public SortedSet<int> RequiredEngine { get; }
    public int Distance { get; }
    public ReadOnlyCollection<BaseObstacle>? PossibleObstacles { get; }
    public abstract int GetTypeHashCode();
}