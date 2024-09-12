using System.Text;

namespace ObjectOrientedProgramming.Lab2.Component;

public class MotherBoard : AbstractComponent
{
    private MotherBoard(Builder builder)
    {
        ProcessorSocket = builder.ProcessorSocket;
        PcieLanes = builder.PcieLanes;
        SataPorts = builder.SataPorts;
        Chipset = builder.Chipset;
        SupportedDdrStandard = builder.SupportedDdrStandard;
        RamSlots = builder.RamSlots;
        FormFactor = builder.FormFactor;
        Bios = builder.Bios;
        HasWiFiModule = builder.HasWiFiModule;
    }

    public string? ProcessorSocket { get; private set; }
    public int PcieLanes { get; private set; }
    public int SataPorts { get; private set; }
    public Chipset? Chipset { get; private set; }
    public string? SupportedDdrStandard { get; private set; }
    public int RamSlots { get; private set; }
    public string? FormFactor { get; private set; }
    public Bios? Bios { get; private set; }
    public bool HasWiFiModule { get; private set; }

    public override string CountConfig()
    {
        return new StringBuilder()
            .Append(ProcessorSocket ?? "null")
            .Append(PcieLanes)
            .Append(SataPorts)
            .Append(Chipset is not null ? Chipset.GetConfig() : "null")
            .Append(SupportedDdrStandard ?? "null")
            .Append(RamSlots).Append(FormFactor ?? "null")
            .Append(Bios is not null ? Bios.GetConfig() : "null")
            .ToString();
    }

    public class Builder
    {
        public string? ProcessorSocket { get; private set; }
        public int PcieLanes { get; private set; }
        public int SataPorts { get; private set; }
        public Chipset? Chipset { get; private set; }
        public string? SupportedDdrStandard { get; private set; }
        public int RamSlots { get; private set; }
        public string? FormFactor { get; private set; }
        public Bios? Bios { get; private set; }
        public bool HasWiFiModule { get; private set; }

        public Builder SetProcessorSocket(string? socket)
        {
            ProcessorSocket = socket;
            return this;
        }

        public Builder SetSupportedDdrStandard(string? ddr)
        {
            SupportedDdrStandard = ddr;
            return this;
        }

        public Builder SetPcieLanes(int lanes)
        {
            PcieLanes = lanes;
            return this;
        }

        public Builder SetSataPorts(int ports)
        {
            SataPorts = ports;
            return this;
        }

        public Builder SetChipset(Chipset chipset)
        {
            Chipset = chipset;
            return this;
        }

        public Builder SetRamSlots(int slots)
        {
            RamSlots = slots;
            return this;
        }

        public Builder SetFormFactor(string formFactor)
        {
            FormFactor = formFactor;
            return this;
        }

        public Builder SetBios(Bios bios)
        {
            Bios = bios;
            return this;
        }

        public Builder WithWiFiModule()
        {
            HasWiFiModule = true;
            return this;
        }

        public MotherBoard Build()
        {
            return new MotherBoard(this);
        }
    }
}