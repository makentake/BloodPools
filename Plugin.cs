using BepInEx;

namespace BloodPools
{
    [BepInPlugin("com.takenmake.bloodpools", "Blood Pools", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin com.takenmake.bloodpools is loaded!");
        }
    }
}
