using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public class WiFiAdapter : AbstractComponent
{
    private WiFiAdapter(Builder builder)
    {
        StandardVersion = builder.StandardVersion;
        SupportedBluetooth = builder.SupportedBluetooth;
        PCIexpressVersion = builder.PCIexpressVersion;
        PowerConsumption = builder.PowerConsumption;
    }

    public string? StandardVersion { get; private set; }
    public bool SupportedBluetooth { get; private set; }
    public string? PCIexpressVersion { get; private set; }
    public int PowerConsumption { get; private set; }

    public override string CountConfig()
    {
        return new StringBuilder()
            .Append(StandardVersion ?? "null")
            .Append(SupportedBluetooth)
            .Append(PCIexpressVersion ?? "null")
            .Append(PowerConsumption).ToString();
    }

    public class Builder
    {
        public string? StandardVersion { get;  private set; }
        public bool SupportedBluetooth { get;   private set;  }
        public string? PCIexpressVersion { get;   private set;  }
        public int PowerConsumption { get;   private set;  }

        public Builder SetStandardVersion(string version)
        {
            StandardVersion = version;
            return this;
        }

        public Builder WithBluetooth()
        {
            SupportedBluetooth = true;
            return this;
        }

        public Builder SetPCIexpressVersion(string version)
        {
            PCIexpressVersion = version;
            return this;
        }

        public Builder SetPowerConsumption(int consumption)
        {
            PowerConsumption = consumption;
            return this;
        }

        public WiFiAdapter Build()
        {
            return new WiFiAdapter(this);
        }
    }
}