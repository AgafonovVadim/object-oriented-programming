using System.Collections.Generic;
using System.Collections.ObjectModel;
using ObjectOrientedProgramming.Lab1.Engine;
using ObjectOrientedProgramming.Lab1.Obstacle;
using ObjectOrientedProgramming.Lab1.Protection.Deflector;
using ObjectOrientedProgramming.Lab1.Protection.Hull;

namespace ObjectOrientedProgramming.Lab1.Logic;

internal class ConstantHolder
{
    internal const int DeflectorFirstClassAsteroidsProtection = 2;
    internal const int DeflectorFirstClassMeteoritesProtection = 1;
    internal const int DeflectorSecondClassAsteroidsProtection = 10;
    internal const int DeflectorSecondClassMeteoritesProtection = 3;
    internal const int DeflectorThirdClassAsteroidsProtection = 40;
    internal const int DeflectorThirdClassMeteoritesProtection = 10;
    internal const int DeflectorThirdClassWhaleProtection = 1;
    internal const int HullFirstClassAsteroidsProtection = 1;
    internal const int HullFirstClassMeteoritesProtection = 0;
    internal const int HullSecondClassAsteroidsProtection = 5;
    internal const int HullSecondClassMeteoritesProtection = 2;
    internal const int HullThirdClassAsteroidsProtection = 20;
    internal const int HullThirdClassMeteoritesProtection = 5;
    internal const int PhotonicDeflectorOutbreakProtection = 3;
    internal const int RandomMeteoriteCount = 1000;
    internal const int RandomSmallAsteroidCount = 10;
    internal const int RandomAntimattedOutbreakCount = 2;
    internal const int RandomCosmoWhaleCount = 1;
    internal const double PetrolPrice = 54.91; // AI-95
    internal const double SpecialPetrolPrice = 60.32; // AI-100
    internal const int ImpulseEngineClassCConsumption = 150;
    internal const int ImpulseEngineClassEConsumption = 375;
    internal const int JumpingEngineAlphaConsumption = 100;
    internal const int JumpingEngineOmegaConsumption = 100;
    internal const int JumpingEngineGammaConsumption = 100;
    internal const int ImpulseEngineStart = 1;
    internal const int ShortRoute = 10000;
    internal const int MediumRoute = 100000;
    internal const int LongRoute = 1000000;
    internal const double SmallSizeRatio = 0.01;
    internal const double MediumSizeRatio = 0.03;
    internal const double BigSizeRatio = 0.1;
    internal const double PleasureShuttleSize = SmallSizeRatio;
    internal const double VaclasSize = MediumSizeRatio;
    internal const double MeredianSize = MediumSizeRatio;
    internal const double StellaSize = SmallSizeRatio;
    internal const double AugurSize = BigSizeRatio;
    internal const int EngineClassCSpeed = 2500;
    internal const int EngineClassESpeed = 1;
    internal const int JumpingEngineAlphaJump = 500;
    internal const int JumpingEngineGammaJump = 10000;
    internal const int JumpingEngineOmegaJump = 1000000;

    internal static readonly ReadOnlyCollection<BaseObstacle> HullFirstClassDefend = new(new List<BaseObstacle> { new SmallAsteroid(HullFirstClassAsteroidsProtection), new Meteorite(HullFirstClassMeteoritesProtection) });
    internal static readonly ReadOnlyCollection<BaseObstacle> HullSecondClassDefend = new(new List<BaseObstacle> { new SmallAsteroid(HullSecondClassAsteroidsProtection), new Meteorite(HullSecondClassMeteoritesProtection) });
    internal static readonly ReadOnlyCollection<BaseObstacle> HullThirdClassDefend = new(new List<BaseObstacle> { new SmallAsteroid(HullThirdClassAsteroidsProtection), new Meteorite(HullThirdClassMeteoritesProtection) });
    internal static readonly ReadOnlyCollection<BaseObstacle> DeflectorFirstClassDefend = new(new List<BaseObstacle> { new SmallAsteroid(DeflectorFirstClassAsteroidsProtection), new Meteorite(DeflectorFirstClassMeteoritesProtection) });
    internal static readonly ReadOnlyCollection<BaseObstacle> DeflectorSecondClassDefend = new(new List<BaseObstacle> { new SmallAsteroid(DeflectorSecondClassAsteroidsProtection), new Meteorite(DeflectorSecondClassMeteoritesProtection) });
    internal static readonly ReadOnlyCollection<BaseObstacle> DeflectorThirdClassDefend = new(new List<BaseObstacle> { new SmallAsteroid(DeflectorThirdClassAsteroidsProtection), new Meteorite(DeflectorThirdClassMeteoritesProtection), new CosmoWhale(DeflectorThirdClassWhaleProtection) });
    internal static readonly ReadOnlyCollection<BaseObstacle> PhotonicDeflectorOutbreakDefend = new(new List<BaseObstacle> { new AntimatterOutbreak(PhotonicDeflectorOutbreakProtection) });

    internal static readonly ReadOnlyCollection<BaseObstacle> AntineutrinoEmitterDefend = new(new List<BaseObstacle>() { new CosmoWhale(int.MaxValue) });
    internal static readonly ReadOnlyCollection<BaseObstacle> SimpleSpaceObstacles = new(new List<BaseObstacle> { new SmallAsteroid(RandomSmallAsteroidCount), new Meteorite(RandomMeteoriteCount) });
    internal static readonly ReadOnlyCollection<BaseObstacle> DensityNebulaeObstacles = new(new List<BaseObstacle> { new AntimatterOutbreak(RandomAntimattedOutbreakCount) });
    internal static readonly ReadOnlyCollection<BaseObstacle> ClearEnvironment = new(new List<BaseObstacle>());
    internal static readonly ReadOnlyCollection<BaseObstacle> NitrideNebulaeObstacles = new(new List<BaseObstacle> { new CosmoWhale(RandomCosmoWhaleCount) });
    internal static readonly ReadOnlyCollection<IMovable> PleasureShuttleEngines = new(new List<IMovable> { new ImpulseEngineC() });
    internal static readonly ReadOnlyCollection<IMovable> VaclasEngines = new(new List<IMovable> { new ImpulseEngineE(), new JumpingEngineGamma() });
    internal static readonly ReadOnlyCollection<IMovable> MeredianEngines = new(new List<IMovable> { new ImpulseEngineE() });
    internal static readonly ReadOnlyCollection<IMovable> StellaEngines = new(new List<IMovable> { new ImpulseEngineC(), new JumpingEngineOmega() });
    internal static readonly ReadOnlyCollection<IMovable> AugurEngines = new(new List<IMovable> { new ImpulseEngineE(), new JumpingEngineAlpha() });

    internal static readonly BaseDeflector? VaclasDeflector = new DeflectorFirstClass();
    internal static readonly BaseDeflector? MeredianDeflector = new DeflectorSecondClass();
    internal static readonly BaseDeflector? StellaDeflector = new DeflectorFirstClass();
    internal static readonly BaseDeflector? AugurDeflector = new DeflectorThirdClass();
    internal static readonly BaseHull? PleasureShuttleHull = new HullFirstClass();
    internal static readonly BaseHull? VaclasHull = new HullSecondClass();
    internal static readonly BaseHull? MeredianHull = new HullSecondClass();
    internal static readonly BaseHull? StellaHull = new HullFirstClass();
    internal static readonly BaseHull? AugurHull = new HullThirdClass();

    internal static readonly ReadOnlyCollection<IMovable> SimpleSpaceRequiredEngines = new(new List<IMovable> { new ImpulseEngineC(), new ImpulseEngineE() });
    internal static readonly ReadOnlyCollection<IMovable> DensityNebulaeRequiredEngines = new(new List<IMovable> { new JumpingEngineAlpha(), new JumpingEngineGamma(), new JumpingEngineOmega() });
    internal static readonly ReadOnlyCollection<IMovable> NitrideNebulaeRequiredEngines = new(new List<IMovable> { new ImpulseEngineE() });
    internal static readonly ReadOnlyCollection<BaseObstacle> Test2Obstacles = new(new List<BaseObstacle> { new AntimatterOutbreak(35) });
    internal static readonly ReadOnlyCollection<BaseObstacle> OwnTestObstacles = new(new List<BaseObstacle> { new SmallAsteroid(200) });
}