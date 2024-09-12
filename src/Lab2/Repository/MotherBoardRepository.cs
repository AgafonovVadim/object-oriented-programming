using ObjectOrientedProgramming.Lab2.Component;

namespace ObjectOrientedProgramming.Lab2.Repository;

public class MotherBoardRepository : AbstractReporitory<MotherBoard>
{
    private static MotherBoardRepository? _instance;
    private MotherBoardRepository()
    { }
    public static IRepository<MotherBoard> Instance()
    {
        if (_instance is null)
            _instance = new MotherBoardRepository();
        return _instance;
    }
}