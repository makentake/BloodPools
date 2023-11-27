using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using EFT;
using EFT.Interactive;
using UnityEngine;

namespace BloodPools
{
    [BepInPlugin("com.takenmake.bloodpools", "Blood Pools", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<int> bloodFactor;
        public static ConfigEntry<float> bloodMaxFallDistance;

        public static ConfigEntry<int> toBleed;
        public static ConfigEntry<int> bloodRadiusInterval;
        public static ConfigEntry<float> bleedInterval;

        internal static ManualLogSource log;

        private void Awake()
        {
            // Plugin startup logic
            toBleed = Config.Bind("General", "To Bleed", 3, "The number of bleed cycles to do.");
            bloodRadiusInterval = Config.Bind("General", "Blood Radius Interval", 1, "By how much the bleed radius expands after every bleed cycle.");
            bleedInterval = Config.Bind("General", "Bleed Interval", 1f, "Number of seconds between each bleed cycle.");

            bloodFactor = Config.Bind("General", "Blood Factor", 3, "Multiplies the amount of blood to bleed each bleed cylce.");
            bloodMaxFallDistance = Config.Bind("General", "Blood Max Fall Distance", 100f, "The maximum distance below the body blood will be drawn.");

            log = Logger;

            new ApplyDamageInfoPatch().Enable();

            log.LogInfo($"Plugin com.takenmake.bloodpools is loaded!");
        }
    }
}
