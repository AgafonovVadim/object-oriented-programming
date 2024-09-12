using System.Collections.Generic;
using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab2.Component;
using ObjectOrientedProgramming.Lab2.Product;
using ObjectOrientedProgramming.Lab2.Service;
using Xunit;

namespace ObjectOrientedProgramming.Lab2.Tests.BasicTestCases;

public class Tests
{
    [Fact]
    public void Test1()
    {
        ReadOnlyCollection<int> frequencies = new(new List<int> { 12 });
        Processor processor = new Processor.Builder().
            SetSocket("t1").
            SetCoreFrequency(12).
            SetCoreNumber(8)
            .SetHeatDissipation(95).
            SetPowerConsumption(15).
            SetMemoryFrequencies(frequencies).
            WithEmbeddedVideoCore()
            .Build();

        ReadOnlyCollection<string?> support = new(new List<string?> { processor.GetConfig() });
        var bios = new Bios("a1", "v12", support);

        var chipset = new Chipset(frequencies, true);

        MotherBoard motherBoard = new MotherBoard.Builder().
            SetFormFactor("v1").
            SetPcieLanes(16).
            SetRamSlots(4)
            .SetProcessorSocket("t1").
            SetSataPorts(16).
            SetSupportedDdrStandard("vdd4").
            SetBios(bios)
            .WithWiFiModule().
            SetChipset(chipset).
            Build();

        var supply = new PowerSupply(150);
        Hdd hdd = new Hdd.Builder().
            SetCapacity(2048).
            SetPowerConsumption(5).
            SetSpindleSpeed(300).
            Build();

        ReadOnlyCollection<string> sockets = new(new List<string> { "t1" });

        CoolingSystem coolingSystem = new CoolingSystem.Builder()
            .SetDimensions(15)
            .SetSockets(sockets)
            .SetTdp(150)
            .Build();

        ReadOnlyCollection<string> factors = new(new List<string> { "v1" });
        ComputerCase computerCase = new ComputerCase.Builder()
            .SetHeight(400)
            .SetWidth(30)
            .SetSuppordedFormFactors(factors)
            .Build();

        Dram dram = new Dram.Builder()
            .SetCapacity(15)
            .SetFormFactor("v5")
            .SetPowerConsumption(3)
            .SetStandardVersion(motherBoard.SupportedDdrStandard).Build();

        Computer computer = new Computer.Builder()
            .SetProccesor(processor)
            .SetComputerCase(computerCase)
            .SetCoolingSystem(coolingSystem)
            .SetMotherBoard(motherBoard)
            .SetHdd(hdd).SetDram(dram)
            .SetPowerSupply(supply).Build();

        var order = new Order(computer);
        order.SendOrderToSell();
        Assert.Equal(Status.Valid, order.SellOrderStatus);
    }

    [Fact]
    public void Test2()
    {
        ReadOnlyCollection<int> frequencies = new(new List<int> { 12 });

        Processor processor = new Processor.Builder()
            .SetSocket("t1").
            SetCoreFrequency(12)
            .SetCoreNumber(8)
            .SetHeatDissipation(95)
            .SetPowerConsumption(400)
            .SetMemoryFrequencies(frequencies)
            .WithEmbeddedVideoCore()
            .Build();

        ReadOnlyCollection<string?> support = new(new List<string?> { processor.GetConfig() });
        var bios = new Bios("a1", "v12", support);

        var chipset = new Chipset(frequencies, true);

        MotherBoard motherBoard = new MotherBoard.Builder()
            .SetFormFactor("v1")
            .SetPcieLanes(16)
            .SetRamSlots(4)
            .SetProcessorSocket("t1")
            .SetSataPorts(16)
            .SetSupportedDdrStandard("vdd4")
            .SetBios(bios)
            .WithWiFiModule()
            .SetChipset(chipset)
            .Build();

        var supply = new PowerSupply(150);
        Hdd hdd = new Hdd.Builder()
            .SetCapacity(2048)
            .SetPowerConsumption(5)
            .SetSpindleSpeed(300)
            .Build();

        ReadOnlyCollection<string> sockets = new(new List<string> { "t1" });

        CoolingSystem coolingSystem = new CoolingSystem.Builder().
            SetDimensions(15)
            .SetSockets(sockets)
            .SetTdp(150)
            .Build();

        ReadOnlyCollection<string> factors = new(new List<string> { "v1" });
        ComputerCase computerCase = new ComputerCase.Builder().
            SetHeight(400)
            .SetWidth(30)
            .SetSuppordedFormFactors(factors)
            .Build();

        Dram dram = new Dram.Builder().
            SetCapacity(15)
            .SetFormFactor("v5")
            .SetPowerConsumption(3)
            .SetStandardVersion(motherBoard.SupportedDdrStandard).Build();

        Computer computer = new Computer.Builder()
            .SetProccesor(processor)
            .SetComputerCase(computerCase)
            .SetCoolingSystem(coolingSystem)
            .SetMotherBoard(motherBoard)
            .SetHdd(hdd).SetDram(dram)
            .SetPowerSupply(supply)
            .Build();

        var order = new Order(computer);
        order.SendOrderToSell();
        Assert.Equal(Status.Warning, order.SellOrderStatus);
    }

    [Fact]
    public void Test3()
    {
        ReadOnlyCollection<int> frequencies = new(new List<int> { 12 });

        Processor processor = new Processor.Builder()
            .SetSocket("t1")
            .SetCoreFrequency(12)
            .SetCoreNumber(8)
            .SetHeatDissipation(95)
            .SetPowerConsumption(15)
            .SetMemoryFrequencies(frequencies)
            .WithEmbeddedVideoCore()
            .Build();

        ReadOnlyCollection<string?> support = new(new List<string?> { processor.GetConfig() });

        var bios = new Bios("a1", "v12", support);

        var chipset = new Chipset(frequencies, true);

        MotherBoard motherBoard = new MotherBoard.Builder()
            .SetFormFactor("v1")
            .SetPcieLanes(16)
            .SetRamSlots(4)
            .SetProcessorSocket("t1")
            .SetSataPorts(16)
            .SetSupportedDdrStandard("vdd4")
            .SetBios(bios)
            .WithWiFiModule()
            .SetChipset(chipset)
            .Build();

        var supply = new PowerSupply(150);
        Hdd hdd = new Hdd.Builder()
            .SetCapacity(2048)
            .SetPowerConsumption(5)
            .SetSpindleSpeed(300)
            .Build();

        ReadOnlyCollection<string> sockets = new(new List<string> { "t1" });
        CoolingSystem coolingSystem = new CoolingSystem.Builder()
            .SetDimensions(15)
            .SetSockets(sockets)
            .SetTdp(5)
            .Build();

        ReadOnlyCollection<string> factors = new(new List<string> { "v1" });

        ComputerCase computerCase = new ComputerCase.Builder()
            .SetHeight(400)
            .SetWidth(30)
            .SetSuppordedFormFactors(factors)
            .Build();

        Dram dram = new Dram.Builder()
            .SetCapacity(15)
            .SetFormFactor("v5")
            .SetPowerConsumption(3)
            .SetStandardVersion(motherBoard.SupportedDdrStandard).Build();

        Computer computer = new Computer.Builder()
            .SetProccesor(processor)
            .SetComputerCase(computerCase)
            .SetCoolingSystem(coolingSystem)
            .SetMotherBoard(motherBoard)
            .SetHdd(hdd)
            .SetDram(dram)
            .SetPowerSupply(supply).Build();

        var order = new Order(computer);
        order.SendOrderToSell();
        Assert.Equal(Status.Warning, order.SellOrderStatus);
    }

    [Fact]
    public void Test4()
    {
        ReadOnlyCollection<int> frequencies = new(new List<int> { 12 });

        Processor processor = new Processor.Builder()
            .SetSocket("t1")
            .SetCoreFrequency(12)
            .SetCoreNumber(8)
            .SetHeatDissipation(95)
            .SetPowerConsumption(15)
            .SetMemoryFrequencies(frequencies)
            .Build();

        ReadOnlyCollection<string?> support = new(new List<string?> { processor.GetConfig() });
        var bios = new Bios("a1", "v12", support);

        var chipset = new Chipset(frequencies, true);

        MotherBoard motherBoard = new MotherBoard.Builder()
            .SetFormFactor("v1")
            .SetPcieLanes(16)
            .SetRamSlots(4)
            .SetProcessorSocket("t1")
            .SetSataPorts(16)
            .SetSupportedDdrStandard("vdd4")
            .SetBios(bios)
            .WithWiFiModule()
            .SetChipset(chipset)
            .Build();

        var supply = new PowerSupply(150);
        Hdd hdd = new Hdd.Builder()
            .SetCapacity(2048)
            .SetPowerConsumption(5)
            .SetSpindleSpeed(300)
            .Build();

        ReadOnlyCollection<string> sockets = new(new List<string> { "t1" });
        CoolingSystem coolingSystem = new CoolingSystem.Builder()
            .SetDimensions(15)
            .SetSockets(sockets)
            .SetTdp(5)
            .Build();

        ReadOnlyCollection<string> factors = new(new List<string> { "v1" });
        ComputerCase computerCase = new ComputerCase.Builder()
            .SetHeight(400)
            .SetWidth(30)
            .SetSuppordedFormFactors(factors)
            .Build();

        Dram dram = new Dram.Builder()
            .SetCapacity(15)
            .SetFormFactor("v5")
            .SetPowerConsumption(3)
            .SetStandardVersion(motherBoard.SupportedDdrStandard).Build();

        Computer computer = new Computer.Builder()
            .SetProccesor(processor)
            .SetComputerCase(computerCase)
            .SetCoolingSystem(coolingSystem)
            .SetMotherBoard(motherBoard)
            .SetHdd(hdd).SetDram(dram)
            .SetPowerSupply(supply)
            .Build();

        var order = new Order(computer);
        order.SendOrderToSell();
        Assert.Equal(Status.Invalid, order.SellOrderStatus);
    }
}