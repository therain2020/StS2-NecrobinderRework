using System;
using BaseLib.Patches.Localization;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace NecrobinderRework.Patches;

/// 为 Postfix 增强的卡牌追加交叉效果描述文本
public static class DescriptionPatch
{
    public static void Initialize()
    {
        DescriptionOverrides.CustomizeDescriptionPost += (CardModel card, Creature? target, ref string desc) =>
        {
            try
            {
                var lang = LocManager.Instance.Language;
                if (card is Bodyguard)
                    desc += lang == "zhs" ? " NL 施加 1 层[gold]灾厄[/gold]。" : " NL Apply 1 [gold]Doom[/gold].";
                else if (card is SoulStorm)
                    desc += lang == "zhs" ? " NL 施加[gold]灾厄[/gold] = 消耗堆中[gold]灵魂[/gold]数。" : " NL Apply [gold]Doom[/gold] = number of [gold]Souls[/gold] in exhaust.";
            }
            catch { }
        };
    }
}
