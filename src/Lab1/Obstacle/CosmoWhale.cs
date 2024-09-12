using ObjectOrientedProgramming.Lab1.Ship;

namespace ObjectOrientedProgramming.Lab1.Obstacle;

public class CosmoWhale : BaseObstacle
{
    public CosmoWhale(int count = 0, Status status = Status.Destroyed)
        : base(count, status)
    {
    }

    public override int GetTypeHashCode()
    {
        return new CosmoWhale().GetType().GetHashCode();
    }
}