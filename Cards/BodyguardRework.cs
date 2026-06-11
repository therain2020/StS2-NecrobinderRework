using System.Collections.Generic;
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

namespace NecrobinderRework.Cards;

[Pool(typeof(NecrobinderCardPool))]
public sealed class BodyguardRework : ReworkCardBase
{
    public BodyguardRework() : base(1, CardType.Skill, CardRarity.Basic, TargetType.Self, "bodyguard") { }

    protected override IEnumerable<DynamicVar> CanonicalVars => [new SummonVar(7), new CardsVar(1)];

    public override List<(string, string)> Localization => LocManager.Instance.Language switch
    {
        "zhs" => new CardLoc("护卫", "[gold]召唤[/gold] {Summon}。\n抽 {Cards} 张牌。"),
        _ => new CardLoc("Bodyguard", "[gold]Summon[/gold] {Summon}.\nDraw {Cards} card."),
    };

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var player = Owner; if (player == null) return;
        await OstyCmd.Summon(choiceContext, player, 7m, this);
        await CardPileCmd.Draw(choiceContext, 1m, player, false);
    }

    protected override void OnUpgrade() => DynamicVars.Summon.UpgradeValueBy(2m);
}
