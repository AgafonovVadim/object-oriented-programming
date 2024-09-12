using System;
using ObjectOrientedProgramming.Lab1.Logic;

namespace ObjectOrientedProgramming.Lab1.Engine;

public abstract class BaseJumpingEngine : IMovable
{
    protected BaseJumpingEngine(int possibleDistance, int consumption, int jump, double petrolPrice = ConstantHolder.SpecialPetrolPrice)
    {
        Consumption = consumption;
        Jump = jump;
        PetrolPrice = petrolPrice;
        PossibleDistance = possibleDistance;
    }

    public double PetrolPrice { get; }
    public int Consumption { get; }

    public int Jump { get; }
    public int PossibleDistance { get; }

    public virtual int ConsumptionCount(int distance)
    {
        throw new NotImplementedException();
    }

    public abstract int GetTypeHashCode();
    public double PetrolPriceCount(int distance)
    {
        return ConsumptionCount(distance) * PetrolPrice;
    }

    public int TimeCount(int distance)
    {
        return distance / Jump;
    }
}