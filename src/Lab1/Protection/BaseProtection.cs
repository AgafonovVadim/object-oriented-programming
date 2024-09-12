using System.Collections.Generic;
using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Obstacle;

namespace ObjectOrientedProgramming.Lab1.Protection;

public abstract class BaseProtection : IProtectable
{
    private BaseProtection? _modification;

    protected BaseProtection(ReadOnlyCollection<BaseObstacle>? protectableObstacles, BaseProtection? modification = null)
    {
        ProtectableObstacles = Service.ObstacleHandler(protectableObstacles);
        _modification = modification;
    }

    private SortedDictionary<int, int>? ProtectableObstacles { get; }

    public int GetDamage(BaseObstacle? obstacle, int protectedDamage = 0)
    {
        if (obstacle is not null)
        {
            int obstacleHash = obstacle.GetTypeHashCode();
            try
            {
                if (_modification is not null && _modification.ProtectableObstacles is not null)
                {
                    int tmpDamage = _modification.ProtectableObstacles[obstacleHash] - obstacle.Count;
                    _modification.ProtectableObstacles[obstacleHash] = tmpDamage;
                    if (tmpDamage >= 0)
                    {
                        if (tmpDamage == 0)
                        {
                            _modification = null;
                        }

                        return 0;
                    }

                    return GetDamage(obstacle, -tmpDamage);
                }
            }
            catch (KeyNotFoundException)
            {
                return BaseDamaging(obstacle, protectedDamage);
            }

            return BaseDamaging(obstacle, protectedDamage);
        }

        return 0;
    }

    private int BaseDamaging(BaseObstacle? obstacle, int protectedDamage = 0)
    {
        if (ProtectableObstacles is not null && obstacle is not null)
        {
            int obstacleHash = obstacle.GetTypeHashCode();
            try
            {
                int tmpObstacleNumber = ProtectableObstacles[obstacleHash] - (obstacle.Count - protectedDamage);
                ProtectableObstacles[obstacleHash] = tmpObstacleNumber;
                if (tmpObstacleNumber >= 0)
                    return 0;
                return -tmpObstacleNumber;
            }
            catch (KeyNotFoundException)
            {
                return obstacle.Count;
            }
        }

        return obstacle?.Count ?? 0;
    }
}