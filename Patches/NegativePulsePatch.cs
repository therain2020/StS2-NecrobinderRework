using System.Threading.Tasks;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// NegativePulse OnPlay Postfix: Block+Doom 后召唤 1 (Doom→Osty)
[HarmonyPatch(typeof(NegativePulse), "OnPlay")]
public static class NegativePulseOnPlayPatch
{
    public static async Task Postfix(Task __result, PlayerChoiceContext choiceContext,
        NegativePulse __instance, CardPlay cardPlay)
    {
        await __result;
        var player = __instance.Owner;
        if (player != null)
            await OstyCmd.Summon(choiceContext, player, 1m, __instance);
    }
}
