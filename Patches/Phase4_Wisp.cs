using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// Phase 4: Wisp 升级后抽 1 张

[HarmonyPatch(typeof(Wisp), "OnUpgrade")]
public static class WispUpgradePatch
{
    public static void Postfix(Wisp __instance)
    {
        CardVarHelper.TryUpgrade(__instance.DynamicVars, "Cards", 1m);
    }
}
