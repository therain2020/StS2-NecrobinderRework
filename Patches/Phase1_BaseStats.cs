using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Characters;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace NecrobinderRework.Patches;

/// Phase 1: 角色基础数值 — HP 66→72, Osty HP 1→2

[HarmonyPatch(typeof(Necrobinder), nameof(Necrobinder.StartingHp), MethodType.Getter)]
public static class StartingHpPatch
{
    public static void Postfix(ref int __result) => __result = 72;
}

// BoundPhylactery CanonicalVars 的 Summon var 控制 Osty HP
[HarmonyPatch(typeof(MegaCrit.Sts2.Core.Models.Relics.BoundPhylactery), "get_CanonicalVars")]
public static class BoundPhylacteryPatch
{
    public static void Postfix(ref System.Collections.Generic.IEnumerable<DynamicVar> __result)
    {
        foreach (var dv in __result)
        {
            if (dv.Name == "Summon")
                dv.UpgradeValueBy(1m); // 1→2
        }
    }
}
