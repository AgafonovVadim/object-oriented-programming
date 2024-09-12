using ObjectOrientedProgramming.Lab2.Component;

namespace ObjectOrientedProgramming.Lab2.Repository;

public class WiFiAdapterRepository : AbstractReporitory<WiFiAdapter>
{
    private static WiFiAdapterRepository? _instance;
    private WiFiAdapterRepository()
    { }
    public static IRepository<WiFiAdapter> Instance()
    {
        if (_instance is null)
            _instance = new WiFiAdapterRepository();
        return _instance;
    }
}