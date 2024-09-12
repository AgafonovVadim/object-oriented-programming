using ObjectOrientedProgramming.Lab1.Ship;

namespace ObjectOrientedProgramming.Lab1.Obstacle;

public abstract class BaseObstacle
{
    protected BaseObstacle(int count, Status status)
    {
        Count = count;
        Status = status;
    }

    public Status Status { get; }
    public int Count { get; private set; }

    public void ConsiderDodgeRatio(double sizeRatio)
    {
        Count = (int)(Count * sizeRatio);
    }

    public abstract int GetTypeHashCode();
}