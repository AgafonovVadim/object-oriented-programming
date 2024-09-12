using System.IO;
using System.Text;

namespace ObjectOrientedProgramming.Lab4.TreePrinter;

public class AbstractTreePrinter : IPrintable
{
    private string _fileSymbol;
    private string _directorySymbol;
    private string _indentationSymbol;

    public AbstractTreePrinter(string fileSymbol, string directorySymbol, string indentationSymbol)
    {
        _fileSymbol = fileSymbol;
        _directorySymbol = directorySymbol;
        _indentationSymbol = indentationSymbol;
    }

    public void ParametrizeFileSymbol(string symbol) => _fileSymbol = symbol;

    public void ParametrizeDirectorySymbol(string symbol) => _directorySymbol = symbol;

    public void ParametrizeIndentationSymbol(string symbol) => _indentationSymbol = symbol;
    public string? Print(string path, int deep = 1)
    {
        var currentDirectory = new DirectoryInfo(path);
        var tree = new StringBuilder();
        tree.Append(_directorySymbol).Append(' ').Append(currentDirectory.Name).Append('\n');
        foreach (FileInfo file in currentDirectory.GetFiles())
        {
            tree.Append(_indentationSymbol).Append(' ');
            if (File.GetAttributes(file.FullName).HasFlag(FileAttributes.Directory))
            {
                tree.Append(_directorySymbol);
                if (deep > 1) tree.Append(Print(file.FullName, deep - 1));
            }
            else
            {
                tree.Append(_fileSymbol).Append(' ').Append(file.Name).Append('\n');
            }
        }

        return tree.ToString();
    }
}