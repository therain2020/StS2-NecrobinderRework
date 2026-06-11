using System;
using System.Collections.Generic;
using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

[HarmonyPatch(typeof(MegaCrit.Sts2.Core.Models.Characters.Necrobinder), "get_StartingDeck")]
public static class TestModePatch
{
    public static bool Enabled = true;

    public static void Postfix(ref IEnumerable<CardModel> __result)
    {
        if (!Enabled) return;
        try
        {
            var deck = new List<CardModel>
            {
                // 5 张交叉卡 (Harmony Postfix 增强)
                ModelDb.Card<Bodyguard>(),
                ModelDb.Card<NegativePulse>(),
                ModelDb.Card<CaptureSpirit>(),
                ModelDb.Card<TimesUp>(),
                ModelDb.Card<SoulStorm>(),
                // Osty 卡
                ModelDb.Card<Unleash>(),
                ModelDb.Card<Fetch>(), ModelDb.Card<Flatten>(), ModelDb.Card<SicEm>(),
                ModelDb.Card<Spur>(), ModelDb.Card<Squeeze>(), ModelDb.Card<Calcify>(),
                ModelDb.Card<HighFive>(),
                // Doom 卡
                ModelDb.Card<DeathsDoor>(), ModelDb.Card<Countdown>(),
                ModelDb.Card<Haunt>(),
                ModelDb.Card<Defile>(), ModelDb.Card<DrainPower>(),
                ModelDb.Card<Reap>(),
                // 基础
                ModelDb.Card<DefendNecrobinder>(), ModelDb.Card<Soul>(),
            };
            __result = deck;
            Log.Debug($"[NR] TestMode: {deck.Count} cards");
        }
        catch (Exception ex) { Log.Error($"[NR] TestMode: {ex.Message}"); }
    }
}
