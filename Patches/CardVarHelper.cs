using System;
using System.Collections.Generic;
using System.Linq;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace NecrobinderRework.Patches;

public static class CardVarHelper
{
    /// <summary>Set a var by name in IEnumerable (safe for CanonicalVars)</summary>
    public static void SetBase(IEnumerable<DynamicVar> vars, string varName, decimal target)
    {
        var dv = vars.FirstOrDefault(v => v.Name == varName);
        if (dv != null)
            dv.UpgradeValueBy(target - dv.BaseValue);
    }

    /// <summary>Set a var by name in DynamicVarSet (safe — checks existence)</summary>
    public static void SetBase(DynamicVarSet vars, string varName, decimal target)
    {
        if (vars.TryGetValue(varName, out var dv))
            dv.UpgradeValueBy(target - dv.BaseValue);
    }

    /// <summary>Try to UpgradeValueBy, silently skip if var doesn't exist</summary>
    public static void TryUpgrade(DynamicVarSet vars, string varName, decimal amount)
    {
        if (vars.TryGetValue(varName, out var dv))
            dv.UpgradeValueBy(amount);
    }
}
