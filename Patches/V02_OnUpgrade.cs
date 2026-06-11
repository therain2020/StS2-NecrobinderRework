using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// OnUpgrade patches
/// Time's Up 升级标记（Cards=1，OnPlay Postfix 据此判断是否追加 Summon）

[HarmonyPatch(typeof(TimesUp), "OnUpgrade")]
public static class TimesUpUpgradePatch
{
    public static void Postfix(TimesUp __instance) =>
        CardVarHelper.TryUpgrade(__instance.DynamicVars, "Cards", 1m);
}

[HarmonyPatch(typeof(DrainPower), "OnUpgrade")]
public static class DrainPowerUpgradePatch
{
    public static void Postfix(DrainPower __instance) =>
        CardVarHelper.TryUpgrade(__instance.DynamicVars, "Cards", 1m);
}
