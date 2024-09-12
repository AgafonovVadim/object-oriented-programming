using System.Collections.ObjectModel;
using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public class CoolingSystem : AbstractComponent
{
    private CoolingSystem(Builder builder)
    {
        Dimensions = builder.Dimensions;
        Sockets = builder.Sockets;
        Tdp = builder.Tdp;
    }

    public int Dimensions { get; private set; }
    public ReadOnlyCollection<string>? Sockets { get; private set; }
    public int Tdp { get; private set; }

    public override string CountConfig()
    {
        StringBuilder config = new StringBuilder().Append(Dimensions).Append(Tdp);
        if (Sockets is not null)
        {
            foreach (string? socket in Sockets)
            {
                config.Append(socket);
            }
        }

        return config.ToString();
    }

    public class Builder
    {
        public int Dimensions { get; private set; }
        public ReadOnlyCollection<string>? Sockets { get; private set; }
        public int Tdp { get;  private set; }

        public Builder SetDimensions(int dimensions)
        {
            Dimensions = dimensions;
            return this;
        }

        public Builder SetTdp(int warmMass)
        {
            Tdp = warmMass;
            return this;
        }

        public Builder SetSockets(ReadOnlyCollection<string> sockets)
        {
            Sockets = sockets;
            return this;
        }

        public CoolingSystem Build()
        {
            return new CoolingSystem(this);
        }
    }
}