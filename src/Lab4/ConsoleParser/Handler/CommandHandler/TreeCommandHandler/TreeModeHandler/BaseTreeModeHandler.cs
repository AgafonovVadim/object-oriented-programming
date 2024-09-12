using ObjectOrientedProgramming.Lab4.TreePrinter;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.TreeCommandHandler.TreeModeHandler;

public abstract class BaseTreeModeHandler : BaseCommandHandler
{
    protected BaseTreeModeHandler(BaseTreeModeHandler? nextMode, AbstractTreePrinter? treePrinter)
        : base(nextMode, treePrinter)
    {
    }
}