using ObjectOrientedProgramming.Lab2.Component;
using ObjectOrientedProgramming.Lab2.Product;
using ObjectOrientedProgramming.Lab2.Repository;

namespace ObjectOrientedProgramming.Lab2.Service;

public class Order
{
    private IRepository<Computer> _computerRepository = ComputerRepository.Instance();
    private IRepository<Bios> _biosRepository = BiosRepository.Instance();
    private IRepository<ComputerCase> _computerCaseRepository = ComputerCaseRepository.Instance();
    private IRepository<CoolingSystem> _coolingSystemRepository = CoolingSystemRepository.Instance();
    private IRepository<Dram> _dramRepository = DramRepository.Instance();
    private IRepository<GraphicCard> _graphicCardRepository = GraphicCardRepository.Instance();
    private IRepository<Hdd> _hddRepository = HddRepository.Instance();
    private IRepository<MotherBoard> _motherBoardRepository = MotherBoardRepository.Instance();
    private IRepository<Processor> _processorRepository = ProcessorRepository.Instance();
    private IRepository<PowerSupply> _powerSupplyRepository = PowerSupplyRepository.Instance();
    private IRepository<Ssd> _ssdRepository = SsdRepository.Instance();
    private IRepository<WiFiAdapter> _wifiAdapterRepository = WiFiAdapterRepository.Instance();
    private IRepository<XmpProfile> _xmpProfileRepository = XmpProfileRepository.Instance();
    public Order(Computer order)
    {
        CurrentOrder = order;
        SellOrderStatus = Status.Valid;
    }

    public Computer CurrentOrder { get; private set; }
    public Status SellOrderStatus { get; set; }

    public string SendOrderToSell()
    {
        ToRepository();
        var validator = new Validation(CurrentOrder);
        string comment = validator.CheckList();
        SellOrderStatus = validator.OrderStatus;
        return comment;
    }

    protected static bool IsNull(AbstractComponent? component) => component is null;

    private void ToRepository()
    {
        _computerRepository.Add(CurrentOrder);
        if (CurrentOrder.MotherBoard?.Bios != null) _biosRepository.Add(CurrentOrder.MotherBoard.Bios);
        if (CurrentOrder.MotherBoard != null) _motherBoardRepository.Add(CurrentOrder.MotherBoard);
        if (CurrentOrder.Processor != null) _processorRepository.Add(CurrentOrder.Processor);
        if (CurrentOrder.CoolingSystem != null) _coolingSystemRepository.Add(CurrentOrder.CoolingSystem);
        if (CurrentOrder.PowerSupply != null) _powerSupplyRepository.Add(CurrentOrder.PowerSupply);
        if (CurrentOrder.ComputerCase != null) _computerCaseRepository.Add(CurrentOrder.ComputerCase);
        if (CurrentOrder.Dram != null) _dramRepository.Add(CurrentOrder.Dram);
        if (CurrentOrder.Hdd != null) _hddRepository.Add(CurrentOrder.Hdd);
        if (CurrentOrder.Ssd != null) _ssdRepository.Add(CurrentOrder.Ssd);
        if (CurrentOrder.WiFiAdapter != null) _wifiAdapterRepository.Add(CurrentOrder.WiFiAdapter);
        if (CurrentOrder.GraphicCard != null) _graphicCardRepository.Add(CurrentOrder.GraphicCard);
        if (CurrentOrder.XmpProfile != null) _xmpProfileRepository.Add(CurrentOrder.XmpProfile);
    }
}