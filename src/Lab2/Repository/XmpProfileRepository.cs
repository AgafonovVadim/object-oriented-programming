using ObjectOrientedProgramming.Lab2.Component;

namespace ObjectOrientedProgramming.Lab2.Repository;

public class XmpProfileRepository : AbstractReporitory<XmpProfile>
{
    private static XmpProfileRepository? _instance;
    private XmpProfileRepository()
    { }
    public static IRepository<XmpProfile> Instance()
    {
        if (_instance is null)
            _instance = new XmpProfileRepository();
        return _instance;
    }
}