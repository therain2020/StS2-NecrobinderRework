using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Abstracts;
using BaseLib.Extensions;
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
public sealed class NegativePulseRework : ReworkCardBase
{
    public NegativePulseRework() : base(1, CardType.Skill, CardRarity.Common, TargetType.AllEnemies, "negative_pulse") { }

    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new BlockVar(7m, default(ValueProp)), new PowerVar<DoomPower>(7m), new SummonVar(1m) ];

    public override List<(string, string)> Localization => LocManager.Instance.Language switch
    {
        "zhs" => new CardLoc("负能量脉冲",
            "获得 {Block} 点[gold]格挡[/gold]。\n给予所有敌人 {DoomPower} 层[gold]灾厄[/gold]。\n[gold]召唤[/gold] {Summon}。"),
        _ => new CardLoc("Negative Pulse",
            "Gain {Block} [gold]Block[/gold].\nApply {DoomPower} [gold]Doom[/gold] to ALL enemies.\n[gold]Summon[/gold] {Summon}."),
    };

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var player = Owner; if (player == null) return;
        await CommonActions.CardBlock(this, cardPlay);
        await CommonActions.Apply<DoomPower>(choiceContext, this, cardPlay);
        await OstyCmd.Summon(choiceContext, player, 1m, this);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Block.UpgradeValueBy(2m);
        DynamicVars.Power<DoomPower>().UpgradeValueBy(2m);
    }
}
