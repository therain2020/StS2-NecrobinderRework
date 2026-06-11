using System;
using System.Collections.Generic;
using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using NecrobinderRework.Cards;

namespace NecrobinderRework.Patches;

[HarmonyPatch(typeof(MegaCrit.Sts2.Core.Models.Characters.Necrobinder), "get_StartingDeck")]
public static class TestModePatch
{
    public static bool Enabled = false;

    public static void Postfix(ref IEnumerable<CardModel> __result)
    {
        if (!Enabled) return;
        try
        {
            var deck = new List<CardModel>
            {
                // v0.3.0 替换卡 (CustomCardModel，已在卡池中)
                ModelDb.Card<BodyguardRework>(),
                ModelDb.Card<NegativePulseRework>(),
                ModelDb.Card<CaptureSpirit>(),
                ModelDb.Card<TimesUpRework>(),
                ModelDb.Card<SoulStormRework>(),
                // 保留的原卡 (未替换)
                ModelDb.Card<Unleash>(),
                ModelDb.Card<Fetch>(), ModelDb.Card<Flatten>(), ModelDb.Card<SicEm>(),
                ModelDb.Card<Spur>(), ModelDb.Card<Squeeze>(), ModelDb.Card<Calcify>(),
                ModelDb.Card<HighFive>(),
                ModelDb.Card<DeathsDoor>(), ModelDb.Card<Countdown>(),
                ModelDb.Card<Haunt>(),
                ModelDb.Card<Defile>(), ModelDb.Card<DrainPower>(),
                ModelDb.Card<Reap>(),
                ModelDb.Card<DefendNecrobinder>(), ModelDb.Card<Soul>(),
            };
            __result = deck;
            Log.Debug($"[NR] TestMode: {deck.Count} cards");
        }
        catch (Exception ex) { Log.Error($"[NR] TestMode: {ex.Message}"); }
    }
}
