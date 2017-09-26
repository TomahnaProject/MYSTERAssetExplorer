using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Core
{
    public class ZoneMap
    {

        public string Scene { get; set; }

    }

    // numbers are explicitly set because they are used in mapping from a nice name to the proper folder structure
    public enum GameEnum
    {
        Exile,
        Revelation
    }

    public enum ExileSceneProperName
    {
        Voltaic = 1,
        Jnanin = 2,
        Edanna = 3,
        Amateria = 4,
        Narayan = 5,
        Tomahna = 6,
    }
    public enum ExileSceneCode
    {
        EN = 1, //Voltaic
        LE = 2, //Jnanin
        LI = 3, //Edanna
        MA = 4, //Amateria
        NA = 5, //Narayan
        TO = 6, //Tomahna
    }
    public enum ExileVoltaicZoneCode
    {
        CH = 1, //CHasm
        DD = 2, //DryDock
        EM = 3, //EnergyManagement
        LC = 4, //LavaCave
        LI = 5, //LastIsland
        PP = 6, //PowerPlant
        SI = 7, //StartingIsland
    }
    public enum ExileJnaninZoneCode
    {
        ET = 1, //EnergyTusk
        IS = 2, //ISland
        LT = 3, //LifeTusk
        MT = 4, //MaterialTusk
        OF = 5, //ObservationFloor
        OS = 6, //ObservationSummit
    }
    public enum ExileEdannaZoneCode
    {
        DR = 1, //DeadwoodRidge
        FO = 2, //FOrest
        NE = 3, //NearEnd
        SP = 4, //SwamP
        SW = 5, //SWing
    }
    public enum ExileAmateriaZoneCode
    {
        CA = 1, //CAve
        IS = 2, //ISland
        LL = 3, //LibrasLever
        SS = 4, //SpiderSpinner
        WW = 5, //WheelsofWonder
    }
    public enum ExileNarayanZoneCode
    {
        CH = 1, //NArayanCHamber
    }
    public enum ExileTomahnaZoneCode
    {
        HB = 1, //HouseBurned
        HO = 2, //HouseOriginal
    }

    public enum RevelationScene
    {
        TomahnaNight = 1,
        Haven = 2,
        Spire = 3,
        Serenia = 4,
        TomahnaDay = 5,
        Menu = 6,
    }

    // day and night versions share same zones
    public enum RevelationTomahnaZone
    {
        Exterior = 1,
        Lab = 2,
        Study = 3,
        Greenhouse = 4,
        Kitchen = 5,
        Vault = 6,
        YeeshaRoom = 7,
        MasterBedroom = 9,
    }
    public enum RevelationHavenZone
    {
        Ship = 1,
        Gap = 2,
        MainForest = 3,
        Swamp = 4,
        SouthForest = 5,
        Lake = 6,
        Grassland = 7,
        Gate = 12,
    }

    public enum RevelationSpireZone
    {
        Peak = 1,
        Garden = 2,
        Dwelling = 3,
        Island = 4,
        Cavern = 5,
        Factory = 6
    }
    public enum RevelationSereniaZone
    {
        Cave = 1,
        Forest = 2,
        Temple = 3,
        Flower = 4,
        Basin = 5,
        DeadFlower = 6,
    }
}
