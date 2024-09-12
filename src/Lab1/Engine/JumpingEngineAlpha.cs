using ObjectOrientedProgramming.Lab1.Logic;

namespace ObjectOrientedProgramming.Lab1.Engine;

public class JumpingEngineAlpha : BaseJumpingEngine
{
    public JumpingEngineAlpha(int possibleDistance = ConstantHolder.ShortRoute, int consumption = ConstantHolder.JumpingEngineAlphaConsumption, int jump = ConstantHolder.JumpingEngineAlphaJump)
        : base(possibleDistance, consumption, jump)
    {
    }

    public override int ConsumptionCount(int distance)
    {
        int time = TimeCount(distance);
        return Consumption * time * time / 2;
    }

    public override int GetTypeHashCode()
    {
        return new JumpingEngineAlpha().GetType().GetHashCode();
    }
}
