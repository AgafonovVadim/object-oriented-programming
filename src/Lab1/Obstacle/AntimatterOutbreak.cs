using ObjectOrientedProgramming.Lab1.Ship;

namespace ObjectOrientedProgramming.Lab1.Obstacle;

public class AntimatterOutbreak : BaseObstacle
{
    public AntimatterOutbreak(int count = 0, Status status = Status.TeamDead)
        : base(count, status)
    {
    }

    public override int GetTypeHashCode()
    {
        return new AntimatterOutbreak().GetType().GetHashCode();
    }
}