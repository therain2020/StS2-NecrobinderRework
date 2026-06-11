using System.Threading.Tasks;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// CaptureSpirit OnPlay Postfix: 原版 Soul 生成 + 追加 Summon 2 (Soul→Osty)
[HarmonyPatch(typeof(CaptureSpirit), "OnPlay")]
public static class CaptureSpiritOnPlayPatch
{
    public static async Task Postfix(Task __result, PlayerChoiceContext choiceContext,
        CaptureSpirit __instance, CardPlay cardPlay)
    {
        await __result;
        var player = __instance.Owner;
        if (player != null)
            await OstyCmd.Summon(choiceContext, player, 2m, __instance);
    }
}
