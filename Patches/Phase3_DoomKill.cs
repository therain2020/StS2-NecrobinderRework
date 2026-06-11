using HarmonyLib;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// Phase 3.1: Countdown Doom 6→9

[HarmonyPatch(typeof(Countdown), "get_CanonicalVars")]
public static class CountdownPatch
{
    public static void Postfix(ref IEnumerable<DynamicVar> __result) =>
        CardVarHelper.SetBase(__result, "Countdown", 9);
}
