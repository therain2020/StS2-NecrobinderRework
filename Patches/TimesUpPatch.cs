using System.Threading.Tasks;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// Time's Up OnPlay Postfix: Doom伤害后，若已升级则召唤=Doom量 (Doom→Osty)
[HarmonyPatch(typeof(TimesUp), "OnPlay")]
public static class TimesUpOnPlayPatch
{
    public static async Task Postfix(Task __result, PlayerChoiceContext choiceContext,
        TimesUp __instance, CardPlay cardPlay)
    {
        await __result;
        // 用 DynamicVars 判断是否已升级（原 V02_OnUpgrade 已设 Cards=1）
        if (__instance.DynamicVars.TryGetValue("Cards", out var dv) && dv.IntValue >= 1)
        {
            var player = __instance.Owner;
            var target = cardPlay.Target;
            if (player != null && target != null)
            {
                var doom = target.Powers.OfType<MegaCrit.Sts2.Core.Models.Powers.DoomPower>().FirstOrDefault();
                if (doom != null && doom.Amount > 0m)
                    await OstyCmd.Summon(choiceContext, player, doom.Amount, __instance);
            }
        }
    }
}
