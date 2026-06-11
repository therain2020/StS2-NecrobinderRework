using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization;

namespace NecrobinderRework.Cards;

/// 替换卡基类：覆盖画像路径，阻止游戏去 card_atlas 查自定义 ModelId
public abstract class ReworkCardBase : CustomCardModel
{
    private readonly string _originalPortraitSuffix;

    protected ReworkCardBase(int cost, CardType type, CardRarity rarity, TargetType target, string originalModelId)
        : base(cost, type, rarity, target)
    {
        _originalPortraitSuffix = originalModelId;
    }

    // 核心：指向原卡在 card_atlas 中的精灵表（一定存在），不是我们的自定义 ModelId
    public override string PortraitPath =>
        $"res://images/atlases/card_atlas.sprites/necrobinder/{_originalPortraitSuffix}.tres";

    public override string BetaPortraitPath =>
        $"res://images/atlases/card_atlas.sprites/necrobinder/{_originalPortraitSuffix}.tres";

    public override string CustomPortraitPath => PortraitPath;
}
