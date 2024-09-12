using ObjectOrientedProgramming.Lab4.TreePrinter;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.TreeCommandHandler;
public abstract class BaseTreeCommandHandler : BaseCommandHandler
{
    protected BaseTreeCommandHandler(BaseTreeCommandHandler? nextCommand = null, AbstractTreePrinter? treePrinter = null)
        : base(nextCommand, treePrinter)
    {
    }
}