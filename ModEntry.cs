using System;
using System.Reflection;
using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;

namespace NecrobinderRework;

[ModInitializer("Initialize")]
public static class ModEntry
{
    public const string HarmonyId = "com.necrobinder-rework.mod";

    public static void Initialize()
    {
        try
        {
            var harmony = new Harmony(HarmonyId);
            int ok = 0, fail = 0;
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.GetCustomAttribute<HarmonyPatch>() == null) continue;
                try { harmony.CreateClassProcessor(type).Patch(); ok++; }
                catch (Exception ex) { fail++; Log.Error($"[NR] FAIL: {type.Name}: {ex.InnerException?.Message ?? ex.Message}"); }
            }
            Log.Debug($"[NR] v0.4.0 — {ok} ok, {fail} fail");
        }
        catch (Exception ex) { Log.Error($"[NR] FATAL: {ex}"); }
    }
}
