using ObjectOrientedProgramming.Lab1.Logic;

namespace ObjectOrientedProgramming.Lab1.Engine;

public class ImpulseEngineC : BaseImpulseEngine
{
    public ImpulseEngineC(int consumption = ConstantHolder.ImpulseEngineClassCConsumption, int startConsumption = ConstantHolder.ImpulseEngineStart, int speed = ConstantHolder.EngineClassCSpeed)
        : base(consumption, startConsumption, speed)
    {
    }

    public override int GetTypeHashCode()
    {
        return new ImpulseEngineC().GetType().GetHashCode();
    }

    protected override int TimeCount(int distance, int speed)
    {
        return distance / speed;
    }
}