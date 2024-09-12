using ObjectOrientedProgramming.Lab2.Component;

namespace ObjectOrientedProgramming.Lab2.Repository;

public class ComputerCaseRepository : AbstractReporitory<ComputerCase>
{
    private static ComputerCaseRepository? _instance;
    private ComputerCaseRepository()
    { }
    public static IRepository<ComputerCase> Instance()
    {
        if (_instance is null)
            _instance = new ComputerCaseRepository();
        return _instance;
    }
}