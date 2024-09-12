using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public class Ssd : AbstractComponent
{
    private Ssd(Builder builder)
    {
        ConnectionType = builder.ConnectionType;
        Capacity = builder.Capacity;
        MaxSpeed = builder.MaxSpeed;
        PowerConsumption = builder.PowerConsumption;
    }

    public string? ConnectionType { get; private set; }
    public int Capacity { get; private set; }
    public int MaxSpeed { get; private set; }
    public double PowerConsumption { get; private set; }

    public override string CountConfig()
    {
        return new StringBuilder()
            .Append(ConnectionType)
            .Append(Capacity)
            .Append(MaxSpeed)
            .Append(PowerConsumption)
            .ToString();
    }

    public class Builder
    {
        public string? ConnectionType { get;  private set;  }
        public int Capacity { get; private set;  }
        public int MaxSpeed { get;  private set;  }
        public double PowerConsumption { get;  private set;  }

        public Builder SetConnectionType(string type)
        {
            ConnectionType = type;
            return this;
        }

        public Builder SetCapacity(int capacity)
        {
            Capacity = capacity;
            return this;
        }

        public Builder SetMaxSpeed(int speed)
        {
            MaxSpeed = speed;
            return this;
        }

        public Builder SetPowerConsumption(double consumption)
        {
            PowerConsumption = consumption;
            return this;
        }

        public Ssd Build()
        {
            return new Ssd(this);
        }
    }
}