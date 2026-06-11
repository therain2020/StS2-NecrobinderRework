using System.Linq;
using System.Threading.Tasks;
using BaseLib.Utils;
using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;

namespace NecrobinderRework.Patches;

/// SoulStorm OnPlay Postfix: 原伤害后施加 Doom=Soul数 (Soul→Doom)
[HarmonyPatch(typeof(SoulStorm), "OnPlay")]
public static class SoulStormOnPlayPatch
{
    public static async Task Postfix(Task __result, PlayerChoiceContext choiceContext,
        SoulStorm __instance, CardPlay cardPlay)
    {
        await __result;
        var player = __instance.Owner;
        var target = cardPlay.Target;
        if (player == null || target == null) return;

        int soulCount = player.PlayerCombatState?.ExhaustPile.Cards.Count(c => c is Soul) ?? 0;
        if (soulCount > 0)
            await CommonActions.Apply<DoomPower>(choiceContext, target, __instance, soulCount, false);
    }
}
