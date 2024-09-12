using System;
using System.IO;
using Crayon;
using ObjectOrientedProgramming.Lab3.Mail;
using static Crayon.Output;

namespace ObjectOrientedProgramming.Lab3.Recipient.Display;

public class DisplayDriver
{
    private readonly string _color;
    public DisplayDriver(string color)
    {
        _color = color;
    }

    private delegate IOutput Draw(string text);

    public static void Clear() => Console.Clear();

    public void Print(Message? message)
    {
        Clear();
        Draw draw = ParseColor;
        if (message is not null)
        {
            Console.WriteLine(draw(message.GetText()));
            WriteToFile(message);
        }
    }

    private static void WriteToFile(Message message)
    {
        TextWriter writer = new StreamWriter("TextFile.txt", false);
        writer.Write(message.GetText());
        writer.Close();
    }

    private IOutput ParseColor(string text)
    {
        switch (_color)
        {
            case "Green": return Green();
            case "Black": return Black();
            case "Red": return Red();
            case "Yellow": return Yellow();
            case "Blue": return Blue();
            case "Magenta": return Magenta();
            case "Cyan": return Cyan();
            case "White": return White();
            default:
                return White();
        }
    }
}