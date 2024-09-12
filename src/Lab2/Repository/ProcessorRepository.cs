using ObjectOrientedProgramming.Lab2.Component;

namespace ObjectOrientedProgramming.Lab2.Repository;

public class ProcessorRepository : AbstractReporitory<Processor>
{
    private static ProcessorRepository? _instance;
    private ProcessorRepository()
    { }
    public static IRepository<Processor> Instance()
    {
        if (_instance is null)
            _instance = new ProcessorRepository();
        return _instance;
    }
}