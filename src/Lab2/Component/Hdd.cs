using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public class Hdd : AbstractComponent
{
    private Hdd(Builder builder)
    {
        Capacity = builder.Capacity;
        SpindleSpeed = builder.SpindleSpeed;
        PowerConsumption = builder.PowerConsumption;
    }

    public int Capacity { get; private set; }
    public int SpindleSpeed { get; private set; }
    public double PowerConsumption { get; private set; }

    public override string CountConfig()
    {
        return new StringBuilder()
            .Append(Capacity)
            .Append(SpindleSpeed)
            .Append(PowerConsumption)
            .ToString();
    }

    public class Builder
    {
        public int Capacity { get;  private set;  }
        public int SpindleSpeed { get;  private set; }
        public double PowerConsumption { get;  private set;  }

        public Builder SetCapacity(int capacity)
        {
            Capacity = capacity;
            return this;
        }

        public Builder SetSpindleSpeed(int speed)
        {
            SpindleSpeed = speed;
            return this;
        }

        public Builder SetPowerConsumption(double consumption)
        {
            PowerConsumption = consumption;
            return this;
        }

        public Hdd Build()
        {
            return new Hdd(this);
        }
    }
}