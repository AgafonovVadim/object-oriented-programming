using System;
using ObjectOrientedProgramming.Lab1.Logic;

namespace ObjectOrientedProgramming.Lab1.Engine;

public class JumpingEngineGamma : BaseJumpingEngine
{
    public JumpingEngineGamma(int possibleDistance = ConstantHolder.MediumRoute, int consumption = ConstantHolder.JumpingEngineGammaConsumption, int jump = ConstantHolder.JumpingEngineGammaJump)
        : base(possibleDistance, consumption, jump)
    {
    }

    public override int ConsumptionCount(int distance)
    {
        int time = TimeCount(distance);
        return Consumption * 2 * time * time * (int)Math.Sqrt(time) / 5;
    }

    public override int GetTypeHashCode()
    {
        return new JumpingEngineGamma().GetType().GetHashCode();
    }
}