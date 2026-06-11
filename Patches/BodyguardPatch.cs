using System.Threading.Tasks;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// Bodyguard OnPlay Postfix: Summon 后抽 1 张牌 (Osty→Soul)
[HarmonyPatch(typeof(Bodyguard), "OnPlay")]
public static class BodyguardOnPlayPatch
{
    public static async Task Postfix(Task __result, PlayerChoiceContext choiceContext,
        Bodyguard __instance, CardPlay cardPlay)
    {
        await __result;
        var player = __instance.Owner;
        if (player != null)
            await CardPileCmd.Draw(choiceContext, 1m, player, false);
    }
}
