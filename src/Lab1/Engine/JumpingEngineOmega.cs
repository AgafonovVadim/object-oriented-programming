using ObjectOrientedProgramming.Lab1.Logic;

namespace ObjectOrientedProgramming.Lab1.Engine;

public class JumpingEngineOmega : BaseJumpingEngine
{
    public JumpingEngineOmega(int possibleDistance = ConstantHolder.LongRoute, int consumption = ConstantHolder.JumpingEngineOmegaConsumption, int jump = ConstantHolder.JumpingEngineOmegaJump)
        : base(possibleDistance, consumption, jump)
    {
    }

    public override int ConsumptionCount(int distance)
    {
        int time = TimeCount(distance);
        return Consumption * time * time * time / 3;
    }

    public override int GetTypeHashCode()
    {
        return new JumpingEngineOmega().GetType().GetHashCode();
    }
}