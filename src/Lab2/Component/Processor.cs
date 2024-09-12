using System.Collections.ObjectModel;
using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public class Processor : AbstractComponent
{
    private Processor(Builder builder)
    {
        CoreFrequency = builder.CoreFrequency;
        CoreNumber = builder.CoreNumber;
        Socket = builder.Socket;
        EmbeddedVideoCore = builder.EmbeddedVideoCore;
        MemoryFrequencies = builder.MemoryFrequencies;
        HeatDissipation = builder.HeatDissipation;
        PowerConsumption = builder.PowerConsumption;
    }

    public double CoreFrequency { get; private set; }
    public int CoreNumber { get; private set; }
    public string? Socket { get; private set; }
    public bool EmbeddedVideoCore { get; private set; }
    public ReadOnlyCollection<int>? MemoryFrequencies { get; private set; }
    public int HeatDissipation { get; private set; }
    public double PowerConsumption { get; private set; }

    public override string CountConfig()
    {
        StringBuilder config = new StringBuilder()
            .Append(CoreFrequency)
            .Append(CoreNumber)
            .Append(Socket ?? "null")
            .Append(EmbeddedVideoCore)
            .Append(HeatDissipation)
            .Append(PowerConsumption);

        if (MemoryFrequencies is not null)
        {
            foreach (int frequency in MemoryFrequencies)
            {
                config.Append(frequency);
            }
        }

        return config.ToString();
    }

    public class Builder
    {
        public double CoreFrequency { get;  private set; }
        public int CoreNumber { get;  private set; }
        public string? Socket { get;  private set;  }
        public bool EmbeddedVideoCore { get;  private set; }
        public ReadOnlyCollection<int>? MemoryFrequencies { get;  private set;  }
        public int HeatDissipation { get;  private set; }
        public double PowerConsumption { get;  private set;  }

        public Builder SetCoreFrequency(double frequency)
        {
            CoreFrequency = frequency;
            return this;
        }

        public Builder SetCoreNumber(int number)
        {
            CoreNumber = number;
            return this;
        }

        public Builder SetSocket(string socket)
        {
            Socket = socket;
            return this;
        }

        public Builder WithEmbeddedVideoCore()
        {
            EmbeddedVideoCore = true;
            return this;
        }

        public Builder SetMemoryFrequencies(ReadOnlyCollection<int>? memoryFrequencies)
        {
            MemoryFrequencies = memoryFrequencies;
            return this;
        }

        public Builder SetHeatDissipation(int heatDissipation)
        {
            HeatDissipation = heatDissipation;
            return this;
        }

        public Builder SetPowerConsumption(double powerConsumption)
        {
            PowerConsumption = powerConsumption;
            return this;
        }

        public Processor Build()
        {
            return new Processor(this);
        }
    }
}