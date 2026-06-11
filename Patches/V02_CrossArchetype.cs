using HarmonyLib;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// v0.4.0: 流派交叉 — 全部通过 Harmony Postfix + CanonicalVars 实现
/// OnPlay 交叉: BodyguardPatch, NegativePulsePatch, CaptureSpiritPatch, TimesUpPatch, SoulStormPatch
/// 数值补丁: 以下

[HarmonyPatch(typeof(SoulStorm), "get_CanonicalVars")]
public static class SoulStormVarsPatch
{
    public static void Postfix(ref System.Collections.Generic.IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "ExtraDamage", 3);
}

[HarmonyPatch(typeof(CaptureSpirit), "get_CanonicalVars")]
public static class CaptureSpiritVarsPatch
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
public static class CountdownVarsPatch
{
    public static void Postfix(ref System.Collections.Generic.IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "Cards", 1);
}
