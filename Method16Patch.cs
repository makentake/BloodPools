using Aki.Reflection.Patching;
using EFT.Interactive;
using System.Reflection;

namespace BloodPools
{
    public class Method16Patch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(Corpse).GetMethod("method_16");
        }
    }
}
