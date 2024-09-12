using System;
using System.IO;
using ObjectOrientedProgramming.Lab4.ConsoleParser;
using ObjectOrientedProgramming.Lab4.Logger;

namespace ObjectOrientedProgramming.Lab4.ConsoleHandler;

public abstract class AbstractHandler : IReadable
{
    private AbstractParser _parser;
    private ConsoleLogger _logger;

    protected AbstractHandler(StreamReader? reader)
    {
        Reader = reader ?? new StreamReader(Console.OpenStandardInput());
        _logger = new ConsoleLogger();
        _parser = new Parser("-", "/", "    ");
    }

    public StreamReader Reader { get; }
    public void Start()
    {
        while (Reader.Peek() != -1)
        {
            string currentLine = Reader.ReadLine() ?? string.Empty;
            _logger.Log(_parser.Parse(currentLine));
        }
    }

    public void ParametrizeFileSymbol(string symbol) => _parser.ParametrizeFileSymbol(symbol);

    public void ParametrizeDirectorySymbol(string symbol) => _parser.ParametrizeDirectorySymbol(symbol);

    public void ParametrizeIndentationSymbol(string symbol) => _parser.ParametrizeIndentationSymbol(symbol);
}