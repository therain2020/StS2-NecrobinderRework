using System.Threading.Tasks;
using BaseLib.Utils;
using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;

namespace NecrobinderRework.Patches;

/// Bodyguard OnPlay Postfix: Summon 后施加 Doom (Osty→Doom)
[HarmonyPatch(typeof(Bodyguard), "OnPlay")]
public static class BodyguardOnPlayPatch
{
    public static async Task Postfix(Task __result, PlayerChoiceContext choiceContext,
        Bodyguard __instance, CardPlay cardPlay)
    {
        await __result;
        var target = cardPlay.Target;
        if (target != null)
            await CommonActions.Apply<DoomPower>(choiceContext, target, __instance, 1m, false);
    }
}
