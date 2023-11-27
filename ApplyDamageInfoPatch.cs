using Aki.Reflection.Patching;
using EFT;
using System.Reflection;

namespace BloodPools
{
    public class ApplyDamageInfoPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(Player).GetMethod("ApplyDamageInfo");
        }

        [PatchPostfix]
        static void Postfix(Player __instance)
        {
            if (!__instance.ActiveHealthController.IsAlive)
            {
                Plugin.log.LogMessage("bot died?");
                //Plugin.log.LogMessage($"toBleed = {Plugin.toBleed.Value}, bloodRadiusInterval = {Plugin.bloodRadiusInterval.Value}, bleedInterval = {Plugin.bleedInterval.Value}");

                var bleedingBody = __instance.gameObject.AddComponent<BleedingBody>();
                bleedingBody.toBleed = Plugin.toBleed.Value;
                bleedingBody.bloodRadiusInterval = Plugin.bloodRadiusInterval.Value;
                bleedingBody.bleedInterval = Plugin.bleedInterval.Value;
            }
        }
    }
}
