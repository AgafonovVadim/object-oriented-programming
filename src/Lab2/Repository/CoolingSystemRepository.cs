using ObjectOrientedProgramming.Lab2.Component;

namespace ObjectOrientedProgramming.Lab2.Repository;

public class CoolingSystemRepository : AbstractReporitory<CoolingSystem>
{
    private static CoolingSystemRepository? _instance;
    private CoolingSystemRepository()
    { }
    public static IRepository<CoolingSystem> Instance()
    {
        if (_instance is null)
            _instance = new CoolingSystemRepository();
        return _instance;
    }
}