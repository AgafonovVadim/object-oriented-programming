using ObjectOrientedProgramming.Lab2.Component;

namespace ObjectOrientedProgramming.Lab2.Repository;

public class PowerSupplyRepository : AbstractReporitory<PowerSupply>
{
    private static PowerSupplyRepository? _instance;
    private PowerSupplyRepository()
    { }
    public static IRepository<PowerSupply> Instance()
    {
        if (_instance is null)
            _instance = new PowerSupplyRepository();
        return _instance;
    }
}