using ObjectOrientedProgramming.Lab2.Component;

namespace ObjectOrientedProgramming.Lab2.Repository;

public class HddRepository : AbstractReporitory<Hdd>
{
    private static HddRepository? _instance;
    private HddRepository()
    { }
    public static IRepository<Hdd> Instance()
    {
        if (_instance is null)
            _instance = new HddRepository();
        return _instance;
    }
}