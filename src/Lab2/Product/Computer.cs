using System.Text;
using ObjectOrientedProgramming.Lab2.Component;

namespace ObjectOrientedProgramming.Lab2.Product;

public class Computer : ISellable
{
    private Computer(Builder builder)
    {
        MotherBoard = builder.MotherBoard;
        Processor = builder.Processor;
        CoolingSystem = builder.CoolingSystem;
        Dram = builder.Dram;
        ComputerCase = builder.ComputerCase;
        PowerSupply = builder.PowerSupply;
        GraphicCard = builder.GraphicCard;
        Ssd = builder.Ssd;
        Hdd = builder.Hdd;
        WiFiAdapter = builder.WiFiAdapter;
        BuilderConfig = builder;
        XmpProfile = builder.XmpProfile;
    }

    public MotherBoard? MotherBoard { get; private set; }
    public Processor? Processor { get; private set; }
    public CoolingSystem? CoolingSystem { get; private set; }
    public Dram? Dram { get; private set; }
    public ComputerCase? ComputerCase { get; private set; }
    public PowerSupply? PowerSupply { get; private set; }
    public GraphicCard? GraphicCard { get; private set; }
    public Ssd? Ssd { get; private set; }
    public Hdd? Hdd { get; private set; }
    public WiFiAdapter? WiFiAdapter { get; private set; }
    public Builder BuilderConfig { get; private set; }
    public XmpProfile? XmpProfile { get; private set; }

    public string CountConfig()
    {
        return new StringBuilder()
            .Append(TryToGetConfig(MotherBoard))
            .Append(TryToGetConfig(Processor))
            .Append(TryToGetConfig(CoolingSystem))
            .Append(TryToGetConfig(Dram))
            .Append(TryToGetConfig(ComputerCase))
            .Append(TryToGetConfig(PowerSupply))
            .Append(TryToGetConfig(Ssd))
            .Append(TryToGetConfig(Hdd))
            .Append(TryToGetConfig(GraphicCard))
            .Append(TryToGetConfig(WiFiAdapter))
            .Append(TryToGetConfig(XmpProfile))
            .ToString();
    }

    private static string TryToGetConfig(AbstractComponent? component)
    {
        return component?.GetConfig() ?? "null";
    }

    public class Builder
    {
        public MotherBoard? MotherBoard { get; private set; }
        public Processor? Processor { get; private set; }
        public CoolingSystem? CoolingSystem { get; private set; }
        public Dram? Dram { get; private set; }
        public ComputerCase? ComputerCase { get; private set; }
        public PowerSupply? PowerSupply { get; private set; }
        public GraphicCard? GraphicCard { get; private set; }
        public Ssd? Ssd { get; private set; }
        public Hdd? Hdd { get; private set; }
        public WiFiAdapter? WiFiAdapter { get; private set; }
        public XmpProfile? XmpProfile { get; private set; }

        public Builder SetMotherBoard(MotherBoard motherBoard)
        {
            MotherBoard = motherBoard;
            return this;
        }

        public Builder SetProccesor(Processor processor)
        {
            Processor = processor;
            return this;
        }

        public Builder SetCoolingSystem(CoolingSystem coolingSystem)
        {
            CoolingSystem = coolingSystem;
            return this;
        }

        public Builder SetDram(Dram dram)
        {
            Dram = dram;
            return this;
        }

        public Builder SetComputerCase(ComputerCase computerCase)
        {
            ComputerCase = computerCase;
            return this;
        }

        public Builder SetPowerSupply(PowerSupply powerSupply)
        {
            PowerSupply = powerSupply;
            return this;
        }

        public Builder SetGraphicCard(GraphicCard graphicCard)
        {
            GraphicCard = graphicCard;
            return this;
        }

        public Builder SetSsd(Ssd ssd)
        {
            Ssd = ssd;
            return this;
        }

        public Builder SetHdd(Hdd hdd)
        {
            Hdd = hdd;
            return this;
        }

        public Builder SetWifiAdapter(WiFiAdapter wifiAdapter)
        {
            WiFiAdapter = wifiAdapter;
            return this;
        }

        public Builder SetXmpProfile(XmpProfile profile)
        {
            XmpProfile = profile;
            return this;
        }

        public Computer Build()
        {
            return new Computer(this);
        }
    }
}