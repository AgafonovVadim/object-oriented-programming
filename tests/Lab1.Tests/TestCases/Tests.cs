using System.Collections.Generic;
using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Environment;
using ObjectOrientedProgramming.Lab1.Logic;
using ObjectOrientedProgramming.Lab1.Protection.Deflector;
using ObjectOrientedProgramming.Lab1.Protection.Deflector.Modification;
using ObjectOrientedProgramming.Lab1.Route;
using ObjectOrientedProgramming.Lab1.Ship;
using Xunit;

namespace ObjectOrientedProgramming.Lab1.Tests.TestCases;

public class Tests
{
    [Fact]
    public void Test1()
    {
        var path = new List<BaseEnvironment>();
        BaseShip shuttle = new PleasureShuttle();
        BaseShip augur = new Augur();
        path.Add(new DensityNebulae(ConstantHolder.MediumRoute, ConstantHolder.ClearEnvironment));
        BaseRoute route = new Route.Route(new ReadOnlyCollection<BaseEnvironment>(path));
        route.PassTheRoute(augur);
        Assert.Equal(Status.Lost, augur.Status);
        route.PassTheRoute(shuttle);
        Assert.Equal(Status.HasNotRequiredEngine, shuttle.Status);
    }

    [Fact]
    public void Test2()
    {
        var path = new List<BaseEnvironment>();
        BaseShip vaclas = new Vaclas(ConstantHolder.VaclasEngines, ConstantHolder.VaclasHull, ConstantHolder.MediumRoute, new DeflectorFirstClass(ConstantHolder.DeflectorFirstClassDefend, new PhotonicProtection()));
        BaseShip vaclas1 = new Vaclas();
        path.Add(new DensityNebulae(ConstantHolder.ShortRoute, ConstantHolder.Test2Obstacles));
        BaseRoute route = new Route.Route(new ReadOnlyCollection<BaseEnvironment>(path));
        route.PassTheRoute(vaclas);
        route.PassTheRoute(vaclas1);
        Assert.Equal(Status.Active, vaclas.Status);
        Assert.Equal(Status.TeamDead, vaclas1.Status);
    }

    [Fact]
    public void Test3()
    {
        var path = new List<BaseEnvironment>();
        BaseShip vaclas = new Vaclas();
        BaseShip augur = new Augur();
        BaseShip meredian = new Meredian();
        path.Add(new NitrideNebulae());
        BaseRoute route = new Route.Route(new ReadOnlyCollection<BaseEnvironment>(path));
        route.PassTheRoute(vaclas);
        Assert.Equal(Status.Destroyed, vaclas.Status);

        route.PassTheRoute(augur);
        Assert.Equal(Status.Active, augur.Status);

        route.PassTheRoute(meredian);
        Assert.Equal(Status.Active, meredian.Status);
    }

    [Fact]
    public void Test4()
    {
        var path = new List<BaseEnvironment>();
        BaseShip pleasureShuttle = new PleasureShuttle();
        BaseShip vaclas = new Vaclas();
        path.Add(new SimpleSpace(ConstantHolder.ShortRoute, ConstantHolder.ClearEnvironment));
        BaseRoute route = new Route.Route(new ReadOnlyCollection<BaseEnvironment>(path));
        var ships = new List<BaseShip>();
        ships.Add(pleasureShuttle);
        ships.Add(vaclas);
        KeyValuePair<BaseShip?, double> result = Service.Compare(new ReadOnlyCollection<BaseShip>(ships), route);
        Assert.Equal(result.Key, pleasureShuttle);
    }

    [Fact]
    public void Test5()
    {
        var path = new List<BaseEnvironment>();
        BaseShip augur = new Augur();
        BaseShip stella = new Stella();
        var ships = new List<BaseShip>();
        ships.Add(augur);
        ships.Add(stella);
        path.Add(new DensityNebulae(ConstantHolder.ShortRoute, ConstantHolder.ClearEnvironment));
        BaseRoute route = new Route.Route(new ReadOnlyCollection<BaseEnvironment>(path));
        KeyValuePair<BaseShip?, double> result = Service.Compare(new ReadOnlyCollection<BaseShip>(ships), route);
        Assert.Equal(result.Key, stella);
    }

    [Fact]
    public void Test6()
    {
        var path = new List<BaseEnvironment>();
        BaseShip pleasureShuttle = new PleasureShuttle();
        BaseShip vaclas = new Vaclas();
        var ships = new List<BaseShip>();
        ships.Add(vaclas);
        ships.Add(pleasureShuttle);
        path.Add(new NitrideNebulae(ConstantHolder.ShortRoute, ConstantHolder.ClearEnvironment));
        BaseRoute route = new Route.Route(new ReadOnlyCollection<BaseEnvironment>(path));
        KeyValuePair<BaseShip?, double> result = Service.Compare(new ReadOnlyCollection<BaseShip>(ships), route);
        Assert.Equal(result.Key, vaclas);
    }

    [Fact]
    public void StudentTest()
    {
        var path = new List<BaseEnvironment>();
        BaseShip augur = new Augur();
        path.Add(new NitrideNebulae(ConstantHolder.ShortRoute, ConstantHolder.ClearEnvironment));
        path.Add(new SimpleSpace(ConstantHolder.MediumRoute, ConstantHolder.OwnTestObstacles));
        BaseRoute route = new Route.Route(new ReadOnlyCollection<BaseEnvironment>(path));
        route.PassTheRoute(augur);
        Assert.Equal(Status.Active, augur.Status);
    }
}