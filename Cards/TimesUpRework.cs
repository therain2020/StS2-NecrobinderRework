using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.CardPools;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace NecrobinderRework.Cards;

[Pool(typeof(NecrobinderCardPool))]
public sealed class TimesUpRework : ReworkCardBase
{
    public TimesUpRework() : base(2, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy, "times_up") { }

    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(0)];

    public override List<(string, string)> Localization => LocManager.Instance.Language switch
    {
        "zhs" => new CardLoc("时间到",
            "造成等于目标[gold]灾厄[/gold]层数的伤害。\n[gold]消耗[/gold]。\n升级后额外召唤等于[gold]灾厄[/gold]层数的[gold]亡灵[/gold]."),
        _ => new CardLoc("Time's Up",
            "Deal damage equal to the target's [gold]Doom[/gold].\n[gold]Exhaust[/gold].\nWhen upgraded, additionally [gold]Summon[/gold] equal to the target's [gold]Doom[/gold]."),
    };

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var player = Owner; if (player == null) return;
        var target = cardPlay.Target; if (target == null) return;
        var doom = target.Powers.OfType<DoomPower>().FirstOrDefault();
        decimal doomAmount = doom?.Amount ?? 0m; if (doomAmount <= 0m) return;
        await CreatureCmd.Damage(choiceContext, target, doomAmount, ValueProp.Unpowered, this);
        await CardCmd.Exhaust(choiceContext, this, false, false);
        if (DynamicVars.Cards.IntValue >= 1)
            await OstyCmd.Summon(choiceContext, player, doomAmount, this);
    }

    protected override void OnUpgrade() => DynamicVars.Cards.UpgradeValueBy(1m);
}
