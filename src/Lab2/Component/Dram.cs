using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public class Dram : AbstractComponent
{
    private Dram(Builder builder)
    {
        Capacity = builder.Capacity;
        XmpProfiles = builder.XmpProfiles;
        JedecVoltPairs = builder.JedecVoltPairs;
        FormFactor = builder.FormFactor;
        StandardVersion = builder.StandardVersion;
        PowerConsumption = builder.PowerConsumption;
    }

    public int Capacity { get; private set; }
    public ReadOnlyCollection<XmpProfile>? XmpProfiles { get; private set; }
    public ReadOnlyCollection<KeyValuePair<int, double>>? JedecVoltPairs { get; private set; }
    public string? FormFactor { get; private set; }
    public string? StandardVersion { get; private set; }
    public double PowerConsumption { get; private set; }
    public override string CountConfig()
    {
        StringBuilder config = new StringBuilder().Append(Capacity).Append(FormFactor ?? "null").Append(StandardVersion ?? "null")
            .Append(PowerConsumption);
        if (JedecVoltPairs is not null)
        {
            foreach (KeyValuePair<int, double> pair in JedecVoltPairs)
            {
                config.Append(pair.Key).Append(pair.Value);
            }
        }

        if (XmpProfiles is not null)
        {
            foreach (XmpProfile profile in XmpProfiles)
            {
                config.Append(profile.GetConfig());
            }
        }

        return config.ToString();
    }

    public class Builder
    {
        public int Capacity { get;   private set; }
        public ReadOnlyCollection<XmpProfile>? XmpProfiles { get;  private set;  }
        public ReadOnlyCollection<KeyValuePair<int, double>>? JedecVoltPairs { get;  private set;  }
        public string? FormFactor { get;  private set; }
        public string? StandardVersion { get;  private set; }
        public double PowerConsumption { get;  private set; }

        public Builder SetCapacity(int capacity)
        {
            Capacity = capacity;
            return this;
        }

        public Builder SetJedecVoltPairs(ReadOnlyCollection<KeyValuePair<int, double>>? pairs)
        {
            JedecVoltPairs = pairs;
            return this;
        }

        public Builder SetProfiles(ReadOnlyCollection<XmpProfile>? profiles)
        {
            XmpProfiles = profiles;
            return this;
        }

        public Builder SetFormFactor(string? formFactor)
        {
            FormFactor = formFactor;
            return this;
        }

        public Builder SetStandardVersion(string? version)
        {
            StandardVersion = version;
            return this;
        }

        public Builder SetPowerConsumption(double consumption)
        {
            PowerConsumption = consumption;
            return this;
        }

        public Dram Build()
        {
            return new Dram(this);
        }
    }
}