using ObjectOrientedProgramming.Lab4.ConsoleParser.Handler;
using ObjectOrientedProgramming.Lab4.TreePrinter;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser;

public abstract class AbstractParser : IParsable
{
    private AbstractTreePrinter _printer;

    protected AbstractParser(string fileSymbol, string directorySymbol, string indentationSymbol)
    {
        _printer = new AbstractTreePrinter(fileSymbol, directorySymbol, indentationSymbol);
    }

    public string? Parse(string? line = null)
    {
        if (line is not null)
        {
            string[] command = line.Split(' ');

            var fileHandler = new FileHandler();
            var treeHandler = new TreeHandler(fileHandler, _printer);
            var disconnectHandler = new DisconnectHandler(treeHandler, _printer);
            var connectHandler = new ConnectHandler(disconnectHandler, _printer);
            string? result = connectHandler.Handle(command);
            return result;
        }

        return "noting added";
    }

    public void ParametrizeFileSymbol(string symbol) => _printer.ParametrizeFileSymbol(symbol);

    public void ParametrizeDirectorySymbol(string symbol) => _printer.ParametrizeDirectorySymbol(symbol);

    public void ParametrizeIndentationSymbol(string symbol) => _printer.ParametrizeIndentationSymbol(symbol);
}