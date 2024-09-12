using ObjectOrientedProgramming.Lab2.Component;

namespace ObjectOrientedProgramming.Lab2.Repository;

public class BiosRepository : AbstractReporitory<Bios>
{
    private static BiosRepository? _instance;

    private BiosRepository()
    {
    }

    public static IRepository<Bios> Instance()
    {
        if (_instance is null)
            _instance = new BiosRepository();
        return _instance;
    }
}