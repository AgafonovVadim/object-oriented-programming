using ObjectOrientedProgramming.Lab2.Component;

namespace ObjectOrientedProgramming.Lab2.Repository;

public class DramRepository : AbstractReporitory<Dram>
{
    private static DramRepository? _instance;
    private DramRepository()
    { }
    public static IRepository<Dram> Instance()
    {
        if (_instance is null)
            _instance = new DramRepository();
        return _instance;
    }
}