using ObjectOrientedProgramming.Lab2.Product;

namespace ObjectOrientedProgramming.Lab2.Repository;

public class ComputerRepository : AbstractReporitory<Computer>
{
    private static ComputerRepository? _instance;
    private ComputerRepository()
    { }
    public static IRepository<Computer> Instance()
    {
        if (_instance is null)
            _instance = new ComputerRepository();
        return _instance;
    }
}