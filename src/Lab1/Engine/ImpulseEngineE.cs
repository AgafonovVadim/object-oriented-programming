using System;
using ObjectOrientedProgramming.Lab1.Logic;

namespace ObjectOrientedProgramming.Lab1.Engine;

public class ImpulseEngineE : BaseImpulseEngine
{
    public ImpulseEngineE(int consumption = ConstantHolder.ImpulseEngineClassEConsumption, int startConsumption = ConstantHolder.ImpulseEngineStart, int speed = ConstantHolder.EngineClassESpeed)
        : base(consumption, startConsumption, speed)
    {
    }

    public override int GetTypeHashCode()
    {
        return new ImpulseEngineE().GetType().GetHashCode();
    }

    protected override int TimeCount(int distance, int speed)
    {
        return (int)Math.Ceiling(Math.Log(distance, speed * Math.E));
    }
}