using ObjectOrientedProgramming.Lab1.Ship;

namespace ObjectOrientedProgramming.Lab1.Obstacle;

public class SmallAsteroid : BaseObstacle
{
    public SmallAsteroid(int count = 0, Status status = Status.Destroyed)
        : base(count, status)
    {
    }

    public override int GetTypeHashCode()
    {
        return new SmallAsteroid().GetType().GetHashCode();
    }
}