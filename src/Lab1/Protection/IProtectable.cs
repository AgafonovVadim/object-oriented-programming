using ObjectOrientedProgramming.Lab1.Obstacle;

namespace ObjectOrientedProgramming.Lab1.Protection;

public interface IProtectable
{
    protected int GetDamage(BaseObstacle obstacle, int protectedDamage = 0);
}