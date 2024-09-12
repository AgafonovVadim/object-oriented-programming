using ObjectOrientedProgramming.Lab2.Component;

namespace ObjectOrientedProgramming.Lab2.Repository;

public class GraphicCardRepository : AbstractReporitory<GraphicCard>
{
    private static GraphicCardRepository? _instance;
    private GraphicCardRepository()
    { }
    public static IRepository<GraphicCard> Instance()
    {
        if (_instance is null)
            _instance = new GraphicCardRepository();
        return _instance;
    }
}