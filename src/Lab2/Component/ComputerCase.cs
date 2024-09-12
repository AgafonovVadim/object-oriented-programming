using System.Collections.ObjectModel;
using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public class ComputerCase : AbstractComponent
{
    private ComputerCase(Builder builder)
    {
        Height = builder.Height;
        Width = builder.Width;
        GraphicCardHeight = builder.GraphicCardHeight;
        GraphicCardWidth = builder.GraphicCardWidth;
        SuppordedFormFactors = builder.SuppordedFormFactors;
    }

    public int GraphicCardHeight { get; private set; }
    public int GraphicCardWidth { get; private set; }
    public ReadOnlyCollection<string>? SuppordedFormFactors { get; private set; }
    public int Height { get; private set; }
    public int Width { get; private set; }

    public override string CountConfig()
    {
        StringBuilder config = new StringBuilder().Append(Height).Append(Width).Append(GraphicCardHeight).Append(GraphicCardWidth);
        if (SuppordedFormFactors is not null)
        {
            foreach (string? factor in SuppordedFormFactors)
            {
                config.Append(factor);
            }
        }

        return config.ToString();
    }

    public class Builder
    {
        public int GraphicCardHeight { get;  private set; }
        public int GraphicCardWidth { get;   private set;  }
        public ReadOnlyCollection<string>? SuppordedFormFactors { get;  private set; }
        public int Height { get;  private set; }
        public int Width { get; private set; }

        public Builder SetGraphicCardHeight(int maxHeight)
        {
            GraphicCardHeight = maxHeight;
            return this;
        }

        public Builder SetGraphicCardWidth(int maxWidth)
        {
            GraphicCardWidth = maxWidth;
            return this;
        }

        public Builder SetSuppordedFormFactors(ReadOnlyCollection<string>? factors)
        {
            SuppordedFormFactors = factors;
            return this;
        }

        public Builder SetHeight(int height)
        {
            Height = height;
            return this;
        }

        public Builder SetWidth(int width)
        {
            Width = width;
            return this;
        }

        public ComputerCase Build()
        {
            return new ComputerCase(this);
        }
    }
}