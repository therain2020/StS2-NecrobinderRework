using HarmonyLib;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// v0.3.0: 流派交叉
/// Bodyguard/NegativePulse/TimesUp/SoulStorm 已迁移至 CustomCardModel
/// CaptureSpirit 用 Harmony Postfix 追加 Summon + V02 数值 patch
/// Calcify/Countdown/Haunt 保留纯数值 patch

[HarmonyPatch(typeof(CaptureSpirit), "get_CanonicalVars")]
public static class CaptureSpiritCrossPatch
{
    public static void Postfix(ref System.Collections.Generic.IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "Cards", 5);
}

[HarmonyPatch(typeof(Haunt), "get_CanonicalVars")]
public static class HauntVarsPatch
{
    public static void Postfix(ref System.Collections.Generic.IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "Haunt", 8);
}

[HarmonyPatch(typeof(Countdown), "get_CanonicalVars")]
public static class CountdownCrossPatch
{
    public static void Postfix(ref System.Collections.Generic.IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "Cards", 1);
}
