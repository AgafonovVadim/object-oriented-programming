using System.Collections.Generic;
using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Engine;
using ObjectOrientedProgramming.Lab1.Obstacle;
using ObjectOrientedProgramming.Lab1.Route;
using ObjectOrientedProgramming.Lab1.Ship;

namespace ObjectOrientedProgramming.Lab1.Logic;

public static class Service
{
    public static SortedDictionary<int, int> ObstacleHandler(ReadOnlyCollection<BaseObstacle>? protectableObstacles)
    {
        var compiledDictionary = new SortedDictionary<int, int>();
        if (protectableObstacles is not null)
        {
            foreach (BaseObstacle obstacle in protectableObstacles)
            {
                compiledDictionary.Add(obstacle.GetTypeHashCode(), obstacle.Count);
            }
        }

        return compiledDictionary;
    }

    public static SortedSet<int> EngineHandler(ReadOnlyCollection<IMovable>? requiredEngines)
    {
        var compiledSet = new SortedSet<int>();
        if (requiredEngines is not null)
        {
            foreach (IMovable engine in requiredEngines)
            {
                compiledSet.Add(engine.GetTypeHashCode());
            }
        }

        return compiledSet;
    }

    public static KeyValuePair<BaseShip?, double> Compare(IList<BaseShip>? ships, BaseRoute route)
    {
        double currentPrice = double.MaxValue;
        int index = 0;
        if (ships is not null)
        {
            for (int i = 0; i < ships.Count; i++)
            {
                if (route is not null)
                {
                    double price = route.PassTheRoute(ships[i]);
                    if (price < currentPrice)
                    {
                        currentPrice = price;
                        index = i;
                    }
                }
            }
        }

        return new KeyValuePair<BaseShip?, double>(ships?[index], currentPrice);
    }
}