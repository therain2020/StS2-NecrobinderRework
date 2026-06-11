using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// Phase 2: Osty 卡强化 — Patch get_CanonicalVars（每张卡都重写了，不会叠加）
/// Bodyguard 已迁移至 CustomCardModel (BodyguardRework)，移除对应 patch

[HarmonyPatch(typeof(Unleash), "get_CanonicalVars")]
public static class UnleashPatch
{
    public static void Postfix(ref IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "CalculationBase", 9);
}

[HarmonyPatch(typeof(Fetch), "get_CanonicalVars")]
public static class FetchPatch
{
    public static void Postfix(ref IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "OstyDamage", 5);
}

[HarmonyPatch(typeof(Flatten), "get_CanonicalVars")]
public static class FlattenPatch
{
    public static void Postfix(ref IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "OstyDamage", 15);
}

[HarmonyPatch(typeof(SicEm), "get_CanonicalVars")]
public static class SicEmPatch
{
    public static void Postfix(ref IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "OstyDamage", 7);
}

[HarmonyPatch(typeof(Spur), "get_CanonicalVars")]
public static class SpurPatch
{
    public static void Postfix(IEnumerable<DynamicVar> __result)
    {
        CardVarHelper.SetBase(__result, "Summon", 5);
        CardVarHelper.SetBase(__result, "Heal", 7);
    }
}

[HarmonyPatch(typeof(Squeeze), "get_CanonicalVars")]
public static class SqueezePatch
{
    public static void Postfix(ref IEnumerable<DynamicVar> __result)
    {
        CardVarHelper.SetBase(__result, "CalculationBase", 30);
        CardVarHelper.SetBase(__result, "ExtraDamage", 6);
    }
}

[HarmonyPatch(typeof(Calcify), "get_CanonicalVars")]
public static class CalcifyPatch
{
    public static void Postfix(ref IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "Calcify", 6);
}

[HarmonyPatch(typeof(HighFive), "get_CanonicalVars")]
public static class HighFivePatch
{
    public static void Postfix(ref IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "OstyDamage", 13);
}
