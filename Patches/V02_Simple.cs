using HarmonyLib;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// v0.2.0: 简单数值改动 — Defile, Reap

// Defile: 13→16 伤
[HarmonyPatch(typeof(Defile), "get_CanonicalVars")]
public static class DefilePatch
{
    public static void Postfix(ref System.Collections.Generic.IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "Damage", 16);
}

// Reap: 27→20 伤
[HarmonyPatch(typeof(Reap), "get_CanonicalVars")]
public static class ReapPatch
{
    public static void Postfix(ref System.Collections.Generic.IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "Damage", 20);
}

// Reap: 费用 3→2（非重写属性，Patch CardModel 基类）
[HarmonyPatch(typeof(CardModel), "get_CanonicalEnergyCost")]
public static class ReapCostPatch
{
    public static void Postfix(CardModel __instance, ref int __result)
    {
        if (__instance is Reap)
            __result = 2;
    }
}
