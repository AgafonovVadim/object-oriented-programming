namespace ObjectOrientedProgramming.Lab4.ConsoleHandler;

public interface IReadable
{
    void Start();
    void ParametrizeFileSymbol(string symbol);
    void ParametrizeDirectorySymbol(string symbol);
    void ParametrizeIndentationSymbol(string symbol);
}