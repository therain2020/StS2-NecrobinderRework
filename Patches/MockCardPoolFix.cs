using System;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.CardPools;

namespace NecrobinderRework.Patches;

/// BaseLib 的 get_AllCards_Patch1 会触发 MockCardPool.GenerateAllCards() 崩溃。
/// 这个 Patch 阻止 MockCardPool 执行原始逻辑，返回空数组避免崩溃。
[HarmonyPatch(typeof(MockCardPool), "GenerateAllCards")]
public static class MockCardPoolFix
{
    public static bool Prefix(ref CardModel[] __result)
    {
        __result = Array.Empty<CardModel>();
        return false; // 跳过原方法
    }
}
