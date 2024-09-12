namespace ObjectOrientedProgramming.Lab4.TreePrinter;

public class ConsolePrinter : AbstractTreePrinter
{
    public ConsolePrinter(string fileSymbol, string directorySymbol, string indentationSymbol)
        : base(fileSymbol, directorySymbol, indentationSymbol)
    {
    }
}