using System.Linq;
using System.Threading.Tasks;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;

namespace NecrobinderRework.Patches;

/// SoulStorm OnPlay Postfix: 原伤害后施加Doom=Soul数/2 (Soul→Doom)
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
        int doomAmount = soulCount / 2;
        if (doomAmount > 0)
            await PowerCmd.Apply<DoomPower>(target, doomAmount, target, null, false);
    }
}
