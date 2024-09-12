using System;
using ObjectOrientedProgramming.Lab4.CustomExceptions;
using ObjectOrientedProgramming.Lab4.TreePrinter;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler;

public abstract class BaseCommandHandler : IHandable
{
    protected BaseCommandHandler(BaseCommandHandler? nextHandler, AbstractTreePrinter? treePrinter = null)
    {
        NextHandle = nextHandler;
        TreePrinter = treePrinter;
    }

    public AbstractTreePrinter? TreePrinter { get; private set; }
    public BaseCommandHandler? NextHandle { get; private set; }
    public string? Path { get; protected set; }

    public abstract string? Handle(string[]? command);

    protected string GetFullPath(string path)
    {
        if (System.IO.Path.IsPathRooted(path))
        {
            return path;
        }

        if (Path != null) return System.IO.Path.Combine(Path, path);
        throw new ArgumentNullException(Path);
    }

    protected string? CallNext(string[]? command)
    {
        if (NextHandle is not null) return NextHandle.Handle(command);
        throw new UnsupportedCommandException();
    }
}