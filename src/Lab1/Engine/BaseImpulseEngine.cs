using ObjectOrientedProgramming.Lab1.Logic;

namespace ObjectOrientedProgramming.Lab1.Engine;

public abstract class BaseImpulseEngine : IMovable
{
    private int _consumption;
    private int _startConsumption;
    private int _speed;
    private double _petrolPrice;

    protected BaseImpulseEngine(int consumption, int startConsumption, int speed, double petrolPrice = ConstantHolder.PetrolPrice, int possibleDistance = ConstantHolder.LongRoute)
    {
        _consumption = consumption;
        _startConsumption = startConsumption;
        _speed = speed;
        PossibleDistance = possibleDistance;
        _petrolPrice = petrolPrice;
    }

    public int PossibleDistance { get; }
    public virtual int ConsumptionCount(int distance)
    {
        return (TimeCount(distance, _speed) * _consumption) + _startConsumption;
    }

    public abstract int GetTypeHashCode();
    public double PetrolPriceCount(int distance)
    {
        return ConsumptionCount(distance) * _petrolPrice;
    }

    protected virtual int TimeCount(int distance, int speed)
    {
        throw new System.NotImplementedException();
    }
}