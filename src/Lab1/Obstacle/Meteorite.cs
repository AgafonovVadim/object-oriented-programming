using ObjectOrientedProgramming.Lab1.Ship;

namespace ObjectOrientedProgramming.Lab1.Obstacle;

public class Meteorite : BaseObstacle
{
    public Meteorite(int count = 0, Status status = Status.Destroyed)
        : base(count, status)
    {
    }

    public override int GetTypeHashCode()
    {
        return new Meteorite().GetType().GetHashCode();
    }
}