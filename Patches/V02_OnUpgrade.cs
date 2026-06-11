using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// v0.3.0: OnUpgrade + OnPlay 改动
/// Time's Up 已迁移至 CustomCardModel (TimesUpRework)，移除对应 patch
/// 保留 DrainPower 升级 patch

// DrainPower: 升级后追加额外升级
[HarmonyPatch(typeof(DrainPower), "OnUpgrade")]
public static class DrainPowerUpgradePatch
{
    public static void Postfix(DrainPower __instance)
    {
        CardVarHelper.TryUpgrade(__instance.DynamicVars, "Cards", 1m);
    }
}
