using ObjectOrientedProgramming.Lab2.Component;

namespace ObjectOrientedProgramming.Lab2.Repository;

public class SsdRepository : AbstractReporitory<Ssd>
{
    private static SsdRepository? _instance;
    private SsdRepository()
    { }
    public static IRepository<Ssd> Instance()
    {
        if (_instance is null)
            _instance = new SsdRepository();
        return _instance;
    }
}