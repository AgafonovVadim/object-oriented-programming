namespace ObjectOrientedProgramming.Lab1.Engine;

public interface IMovable
{
    public int PossibleDistance { get; }
    public int ConsumptionCount(int distance);
    public int GetTypeHashCode();
    public double PetrolPriceCount(int distance);
}