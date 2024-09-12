using System.Text;
using ObjectOrientedProgramming.Lab2.Product;

namespace ObjectOrientedProgramming.Lab2.Service;

public class Validation : Order
{
    public Validation(Computer order)
        : base(order)
    {
        OrderStatus = Status.Valid;
    }

    public Status OrderStatus { get; private set; }

    public string CheckList()
    {
        var comment = new StringBuilder();
        comment.Append(ContainsFormatter(NotContainsAllNecessaryComponents()));
        if (OrderStatus == Status.Invalid)
        {
            return comment.ToString();
        }

        comment.Append(CheckCompabilityMotherBoardWithProcessor());
        comment.Append(CheckCompabilityProcessorWithCoolingSystem());
        comment.Append(CheckCompabilityMotherBoardWithDram());
        comment.Append(CheckCompabilityComputerCaseWithCoolingSystem());
        comment.Append(CheckCompabilityComputerCaseWithGrphicCard());
        comment.Append(CheckCompabilityComputerCaseWithMotherBoard());
        comment.Append(CheckCompabilityPowerSupply());
        comment.Append(CheckCompabilityWiFiAdapter());
        comment.Append(CheckXmpProfile());

        return comment.ToString();
    }

    private string? NotContainsAllNecessaryComponents()
    {
        if (IsNull(CurrentOrder.MotherBoard))
            return "motherboard";
        if (IsNull(CurrentOrder.Processor))
            return "processor";
        if (IsNull(CurrentOrder.CoolingSystem))
            return "cooling system";
        if (IsNull(CurrentOrder.Dram))
            return "dram";
        if (IsNull(CurrentOrder.ComputerCase))
            return "case";
        if (IsNull(CurrentOrder.PowerSupply))
            return "power supply";
        if (IsNull(CurrentOrder.Hdd) && IsNull(CurrentOrder.Ssd))
            return "driver";
        return GraphicCheck();
    }

    private string? GraphicCheck()
    {
        if (CurrentOrder.Processor is not null && !CurrentOrder.Processor.EmbeddedVideoCore && IsNull(CurrentOrder.GraphicCard))
            return IsNull(CurrentOrder.GraphicCard) ? "graphic card" : "video core";
        return null;
    }

    private string? CheckCompabilityMotherBoardWithProcessor()
    {
        if (CurrentOrder.Processor?.Socket != null && CurrentOrder.MotherBoard?.ProcessorSocket is not null && CurrentOrder.MotherBoard.ProcessorSocket is not null)
        {
            if (!(CurrentOrder.Processor is not null && CurrentOrder.MotherBoard.Bios is not null &&
                 CurrentOrder.MotherBoard.Bios.SupportedProcessors.Contains(CurrentOrder.Processor.GetConfig())))
            {
                OrderStatus = Status.Invalid;
                return "Bios and processor are incompatible (Bios doesnt support this processor) \n";
            }
        }
        else
        {
            OrderStatus = Status.Invalid;
            return "MotherBoard and processor are incopatible (Different sockets) \n";
        }

        return null;
    }

    private string? CheckCompabilityProcessorWithCoolingSystem()
    {
        if (CurrentOrder.CoolingSystem is not null && CurrentOrder.Processor is not null && CurrentOrder.Processor.HeatDissipation < CurrentOrder.CoolingSystem.Tdp)
        {
            return null;
        }

        OrderStatus = Status.Warning;
        return "Insufficient heat dissipation \n";
    }

    private string? CheckCompabilityMotherBoardWithDram()
    {
        object? mother = CurrentOrder.MotherBoard?.SupportedDdrStandard;
        object? dram = CurrentOrder.Dram?.StandardVersion;

        if (mother != null && dram != null && !mother.Equals(dram))
        {
            OrderStatus = Status.Invalid;
            return "MotherBoard dont support Dram standard  \n";
        }

        return null;
    }

    private string? CheckCompabilityComputerCaseWithGrphicCard()
    {
        if (CurrentOrder.ComputerCase is not null && CurrentOrder.GraphicCard is not null && (CurrentOrder.GraphicCard.Height >= CurrentOrder.ComputerCase.GraphicCardHeight ||
                                                                          CurrentOrder.GraphicCard.Width >= CurrentOrder.ComputerCase.GraphicCardWidth))
        {
            OrderStatus = Status.Invalid;
            return "Graphic card is bigger than case \n";
        }

        return null;
    }

    private string? CheckCompabilityComputerCaseWithCoolingSystem()
    {
        if (CurrentOrder.ComputerCase is not null && CurrentOrder.CoolingSystem is not null && CurrentOrder.CoolingSystem.Dimensions >= CurrentOrder.ComputerCase.Width)
        {
            OrderStatus = Status.Warning;
            return "The cooling system will not work correctly \n";
        }

        return null;
    }

    private string? CheckCompabilityComputerCaseWithMotherBoard()
    {
        if (CurrentOrder.MotherBoard?.FormFactor is not null &&
            CurrentOrder.ComputerCase?.SuppordedFormFactors is not null &&
            CurrentOrder.MotherBoard is not null &&
            CurrentOrder.ComputerCase.SuppordedFormFactors.Contains(CurrentOrder.MotherBoard.FormFactor))
        {
            return null;
        }

        OrderStatus = Status.Invalid;
        return "Computer case doesnt support motherboard form-factor \n";
    }

    private string? CheckXmpProfile()
    {
        if (CurrentOrder.XmpProfile is not null)
        {
            if (CurrentOrder.Processor?.MemoryFrequencies != null && CurrentOrder.Processor != null &&
                CurrentOrder.MotherBoard?.Chipset != null && CurrentOrder.MotherBoard != null &&
                CurrentOrder.MotherBoard.Chipset.MemoryFrequencies.Contains(CurrentOrder.XmpProfile.Frequency) &&
                CurrentOrder.Processor.MemoryFrequencies.Contains(CurrentOrder.XmpProfile.Frequency))
            {
                return null;
            }

            OrderStatus = Status.Warning;
            return "Not supported xmp profile \n";
        }

        return null;
    }

    private string? CheckCompabilityPowerSupply()
    {
        double pcConsumption = 0;
        if (CurrentOrder.Processor is not null)
        {
            pcConsumption += CurrentOrder.Processor.PowerConsumption;
        }

        if (CurrentOrder.Dram is not null)
        {
            pcConsumption += CurrentOrder.Dram.PowerConsumption;
        }

        if (CurrentOrder.GraphicCard is not null)
        {
            pcConsumption += CurrentOrder.GraphicCard.PowerConsumption;
        }

        if (CurrentOrder.Ssd is not null)
        {
            pcConsumption += CurrentOrder.Ssd.PowerConsumption;
        }

        if (CurrentOrder.Hdd is not null)
        {
            pcConsumption += CurrentOrder.Hdd.PowerConsumption;
        }

        if (CurrentOrder.WiFiAdapter is not null)
        {
            pcConsumption += CurrentOrder.WiFiAdapter.PowerConsumption;
        }

        if (CurrentOrder.PowerSupply is not null && CurrentOrder.PowerSupply.PeakPower < pcConsumption)
        {
            OrderStatus = Status.Warning;
            return "Not enough power in power supply";
        }

        return null;
    }

    private string? CheckCompabilityWiFiAdapter()
    {
        if (CurrentOrder.MotherBoard != null && CurrentOrder.MotherBoard.HasWiFiModule && CurrentOrder.WiFiAdapter is not null)
        {
            OrderStatus = Status.Invalid;
            return "Wi-Fi equipment conflict";
        }

        return null;
    }

    private string? ContainsFormatter(string? component)
    {
        if (component is not null)
        {
            OrderStatus = Status.Invalid;
            return "Not contains main component " + component + " \n";
        }

        return null;
    }
}
