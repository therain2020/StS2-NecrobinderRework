using System.Linq;
using System.Threading.Tasks;
using BaseLib.Utils;
using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;

namespace NecrobinderRework.Patches;

/// Bodyguard OnPlay Postfix: Summon 后给全体敌人施加 1 Doom (Osty→Doom)
[HarmonyPatch(typeof(Bodyguard), "OnPlay")]
public static class BodyguardOnPlayPatch
{
    public static async Task Postfix(Task __result, PlayerChoiceContext choiceContext,
        Bodyguard __instance, CardPlay cardPlay)
    {
        await __result;
        var player = __instance.Owner;
        if (player == null) return;

        var enemies = __instance.CombatState?.Enemies.Where(e => e.IsAlive).ToList();
        if (enemies != null)
            foreach (var enemy in enemies)
                await CommonActions.Apply<DoomPower>(choiceContext, enemy, __instance, 1m, false);
    }
}
