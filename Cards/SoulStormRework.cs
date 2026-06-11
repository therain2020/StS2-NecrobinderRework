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
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace NecrobinderRework.Cards;

[Pool(typeof(NecrobinderCardPool))]
public sealed class SoulStormRework : ReworkCardBase
{
    public SoulStormRework() : base(2, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy, "soul_storm") { }

    protected override IEnumerable<DynamicVar> CanonicalVars => [
        ..MakeCalculatedDamage(9, (card, _) =>
            card.Owner?.PlayerCombatState?.ExhaustPile.Cards.Count(c => c is Soul) ?? 0,
            2, ValueProp.Move),
        new CardsVar(1),
    ];

    public override List<(string, string)> Localization => LocManager.Instance.Language switch
    {
        "zhs" => new CardLoc("灵魂风暴",
            "造成 {CalculatedDamage} 点伤害。消耗堆中每张[gold]灵魂[/gold]使伤害 +{ExtraDamage}。\n" +
            "施加[gold]灾厄[/gold] = 消耗堆中[gold]灵魂[/gold]数量的一半。\n抽 {Cards} 张牌。"),
        _ => new CardLoc("Soul Storm",
            "Deal {CalculatedDamage} damage. Deal +{ExtraDamage} damage for each [gold]Soul[/gold] in your [gold]Exhaust Pile[/gold].\n" +
            "Apply [gold]Doom[/gold] equal to half the number of [gold]Souls[/gold] in your [gold]Exhaust Pile[/gold].\n" +
            "Draw {Cards} card."),
    };

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        CommonActions.CardAttack(this, cardPlay);

        var player = Owner;
        if (player != null)
        {
            int soulCount = player.PlayerCombatState?.ExhaustPile.Cards.Count(c => c is Soul) ?? 0;
            int doomAmount = soulCount / 2;
            if (doomAmount > 0)
            {
                var target = cardPlay.Target;
                if (target != null)
                    await CommonActions.Apply<DoomPower>(choiceContext, target, this, doomAmount, false);
            }
        }

        if (Owner != null)
            await CardPileCmd.Draw(choiceContext, 1m, Owner, false);
    }

    protected override void OnUpgrade()
    {
        DynamicVars["CalculatedDamage"].UpgradeValueBy(3m);
        DynamicVars["ExtraDamage"].UpgradeValueBy(1m);
    }
}
