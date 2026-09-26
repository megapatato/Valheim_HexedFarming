using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace HexedFarming
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class HexedFarming : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.HexedFarming";
        public const string PluginName = "HexedFarming";
        public const string PluginVersion = "0.0.1";
        
        // Use this class to add your own localization to the game
        // https://valheim-modding.github.io/Jotunn/tutorials/localization.html
        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

        private void Awake()
        {
            // Jotunn comes with its own Logger class to provide a consistent Log style for all mods using it
            Jotunn.Logger.LogInfo("HexedFarming has landed");

            // To learn more about Jotunn's features, go to
            // https://valheim-modding.github.io/Jotunn/tutorials/overview.html

            PrefabManager.OnVanillaPrefabsAvailable += CreateHexedFarmingGrids;
        }

        private void CreateHexedFarmingGrids()
        {
            CreateHexedFarming_Carrot();
            PrefabManager.OnVanillaPrefabsAvailable -= CreateHexedFarmingGrids;
        }

        private void CreateHexedFarming_Carrot()
        {
            PieceConfig hex_carrot = new PieceConfig();
            hex_carrot.Name = "$piece_hex_carrot_display_name";
            hex_carrot.Description = "$piece_hex_carrot_description";
            hex_carrot.PieceTable = PieceTables.Cultivator;
            hex_carrot.Category = PieceCategories.Misc;
            hex_carrot.AddRequirement("CarrotSeeds", 7);

            PieceManager.Instance.AddPiece(new CustomPiece("piece_hex_carrot", "sapling_carrot", hex_carrot));
        }
    }
}

