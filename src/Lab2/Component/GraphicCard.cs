using System;
using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public class GraphicCard : AbstractComponent
{
    private GraphicCard(Builder builder)
    {
        Height = builder.Height;
        Width = builder.Width;
        PciExpressVersion = builder.PciExpressVersion;
        ChipFrequency = builder.ChipFrequency;
        PowerConsumption = builder.PowerConsumption;
    }

    public int Height { get; private set; }
    public int Width { get; private set; }
    public string? PciExpressVersion { get; private set; }
    public double ChipFrequency { get; private set; }
    public double PowerConsumption { get; private set; }

    public override string CountConfig()
    {
        return new Guid(new StringBuilder()
            .Append(Height)
            .Append(Width)
            .Append(PciExpressVersion ?? "null")
            .Append(ChipFrequency)
            .Append(PowerConsumption)
            .ToString())
            .ToString();
    }

    public class Builder
    {
        public int Height { get;  private set;  }
        public int Width { get;   private set;  }
        public string? PciExpressVersion { get;  private set; }
        public double ChipFrequency { get;  private set; }
        public double PowerConsumption { get;  private set;  }

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

        public Builder SetPciExpressVersion(string? version)
        {
            PciExpressVersion = version;
            return this;
        }

        public Builder SetChipFrequency(double frequency)
        {
            ChipFrequency = frequency;
            return this;
        }

        public Builder SetPowerConsumption(double consumption)
        {
            PowerConsumption = consumption;
            return this;
        }

        public GraphicCard Build()
        {
            return new GraphicCard(this);
        }
    }
}