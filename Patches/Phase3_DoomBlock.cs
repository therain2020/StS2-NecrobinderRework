using HarmonyLib;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// Phase 3.2: Doom 格挡提升

[HarmonyPatch(typeof(NegativePulse), "get_CanonicalVars")]
public static class NegativePulsePatch
{
    public static void Postfix(ref IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "Block", 7);
}

[HarmonyPatch(typeof(DeathsDoor), "get_CanonicalVars")]
public static class DeathsDoorPatch
{
    public static void Postfix(ref IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "Block", 8);
}
