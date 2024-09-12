using System;
using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Engine;
using ObjectOrientedProgramming.Lab1.Environment;
using ObjectOrientedProgramming.Lab1.Obstacle;
using ObjectOrientedProgramming.Lab1.Ship;
namespace ObjectOrientedProgramming.Lab1.Route;

public abstract class BaseRoute
{
    private ReadOnlyCollection<BaseEnvironment> _path;

    protected BaseRoute(ReadOnlyCollection<BaseEnvironment> path)
    {
        _path = path;
    }

    public double PassTheRoute(BaseShip ship)
    {
        double result = double.MaxValue;
        foreach (BaseEnvironment environment in _path)
        {
            IMovable? engine = HasEngine(ship, environment);
            if (engine is not null)
            {
                if (DamageAlive(ship, environment))
                {
                    if (environment.GetTypeHashCode() == new DensityNebulae().GetTypeHashCode() &&
                        environment.Distance >= engine.PossibleDistance)
                    {
                        ship.Status = Status.Lost;
                        return double.MaxValue;
                    }

                    result = Math.Abs(result - double.MaxValue) < 1 ? 0 : result;
                    result += engine.PetrolPriceCount(environment.Distance);
                }
            }
        }

        return result;
    }

    private static IMovable? HasEngine(BaseShip? ship, BaseEnvironment environment)
    {
        IMovable? currentEngine = null;
        if (ship is not null && ship.Engines is not null)
        {
            foreach (IMovable engine in ship.Engines)
            {
                if (environment.RequiredEngine.Contains(engine.GetTypeHashCode()))
                {
                    currentEngine = engine;
                    break;
                }
            }
        }

        if (currentEngine is null)
        {
            if (ship is not null)
                ship.Status = Status.HasNotRequiredEngine;
        }

        return currentEngine;
    }

    private static bool DamageAlive(BaseShip? ship, BaseEnvironment environment)
    {
        bool deflectorIsAlive = ship?.Deflector is not null;
        if (environment.PossibleObstacles is not null && ship is not null)
        {
            foreach (BaseObstacle obstacle in environment.PossibleObstacles)
            {
                obstacle.ConsiderDodgeRatio(ship.SizeClass);
                int notprotectedDamage = 0;
                if (deflectorIsAlive && ship.Deflector is not null)
                {
                    notprotectedDamage = ship.Deflector.GetDamage(obstacle);
                    if (notprotectedDamage != 0)
                        deflectorIsAlive = false;
                }

                if (!deflectorIsAlive)
                {
                    if (ship.Hull is not null && ship.Hull.GetDamage(obstacle, notprotectedDamage) != 0)
                    {
                        ship.Status = obstacle.Status;
                        return false;
                    }
                }
            }
        }

        return true;
    }
}