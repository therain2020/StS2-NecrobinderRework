using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.CardPools;
using NecrobinderRework.Cards;

namespace NecrobinderRework;

[ModInitializer("Initialize")]
public static class ModEntry
{
    public const string HarmonyId = "com.necrobinder-rework.mod";

    public static void Initialize()
    {
        try
        {
            ModHelper.AddModelToPool<NecrobinderCardPool, BodyguardRework>();
            ModHelper.AddModelToPool<NecrobinderCardPool, NegativePulseRework>();
            ModHelper.AddModelToPool<NecrobinderCardPool, TimesUpRework>();
            ModHelper.AddModelToPool<NecrobinderCardPool, SoulStormRework>();

            var harmony = new Harmony(HarmonyId);
            int ok = 0, fail = 0;
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.GetCustomAttribute<HarmonyPatch>() == null) continue;
                try { harmony.CreateClassProcessor(type).Patch(); ok++; }
                catch (Exception ex) { fail++; Log.Error($"[NR] FAIL: {type.Name}: {ex.InnerException?.Message ?? ex.Message}"); }
            }
            Log.Debug($"[NR] 5 cards, {ok} ok, {fail} fail");
        }
        catch (Exception ex) { Log.Error($"[NR] FATAL: {ex}"); }
    }
}

[HarmonyPatch(typeof(NecrobinderCardPool), "GenerateAllCards")]
public static class PoolReplacePatch
{
    private static readonly HashSet<Type> RemoveTypes = new()
    {
        typeof(MegaCrit.Sts2.Core.Models.Cards.Bodyguard),
        typeof(MegaCrit.Sts2.Core.Models.Cards.NegativePulse),
        typeof(MegaCrit.Sts2.Core.Models.Cards.TimesUp),
        typeof(MegaCrit.Sts2.Core.Models.Cards.SoulStorm),
    };

    public static void Postfix(ref CardModel[] __result)
    {
        __result = __result.Where(c => !RemoveTypes.Contains(c.GetType())).ToArray();
    }
}
