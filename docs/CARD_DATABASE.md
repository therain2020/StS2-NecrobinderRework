# Necrobinder 完整卡牌数据库

> **数据来源**: Spire Codex (sts2.dll 反编译提取)  
> **游戏版本**: v0.103.3 | **卡牌总数**: 88

## 图例
- **费用**: 能量消耗
- **vars**: 卡牌数值变量（Summon=召唤量, DoomPower=Doom层数, Damage=伤害, Block=格挡 等）
- **upgrade**: 升级变化（+N=增加, 数值=替换）

---

## Common

### Afterlife

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Exhaust |
| 变量 | Summon=6 |
| 升级 | summon: +3 |
| 效果 | [gold]Summon[/gold] 6. |

---

## Rare

### Banshee's Cry

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 6 |
| 伤害 | 33 |
| 格挡 | - |
| 变量 | Damage=33, Energy=2 |
| 升级 | damage: +6 |
| 效果 | Deal 33 damage to ALL enemies. Costs [energy:2] less for each [gold]Ethereal[/gold] card played this combat. |

---

## Common

### Blight Strike

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 8 |
| 格挡 | - |
| 变量 | Damage=8 |
| 升级 | damage: +2 |
| 效果 | Deal 8 damage. Apply [gold]Doom[/gold] equal to damage dealt. |

---

## Basic

### Bodyguard

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | Summon=5 |
| 升级 | summon: +2 |
| 效果 | [gold]Summon[/gold] 5. |

---

## Uncommon

### Bone Shards

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 9 |
| 格挡 | 9 |
| 变量 | OstyDamage=9, Block=9, Damage=9 |
| 升级 | damage: +3, block: +3, ostydamage: +3 |
| 效果 | If [gold]Osty[/gold] is alive, he deals 9 damage to ALL enemies and you gain 9 [gold]Block[/gold]. [gold]Osty[/gold] dies. |

### Borrowed Time

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 0 |
| 伤害 | - |
| 格挡 | - |
| 变量 | Energy=1, DoomPower=3, Doom=3 |
| 升级 | energy: +1 |
| 效果 | Apply 3 [gold]Doom[/gold] to yourself. Gain [energy:1]. |

### Bury

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 4 |
| 伤害 | 52 |
| 格挡 | - |
| 变量 | Damage=52 |
| 升级 | damage: +11 |
| 效果 | Deal 52 damage. |

### Calcify

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | CalcifyPower=4, Calcify=4 |
| 升级 | calcifypower: +2 |
| 效果 | [gold]Osty's[/gold] attacks deal 4 additional damage. |

---

## Rare

### Call of the Void

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | Cards=1 |
| 升级 | add_innate: True |
| 效果 | At the start of your turn, add 1 random card into your [gold]Hand[/gold]. It gains [gold]Ethereal[/gold]. |

---

## Uncommon

### Capture Spirit

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | 3 |
| 格挡 | - |
| 变量 | Damage=3, Cards=3 |
| 升级 | damage: +1, cards: +1 |
| 效果 | Enemy loses 3 HP. Add 3 [gold]Souls[/gold] into your [gold]Draw Pile[/gold]. |

### Cleanse

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | Summon=3 |
| 升级 | summon: +2 |
| 效果 | [gold]Summon[/gold] 3. [gold]Exhaust[/gold] 1 card from your [gold]Draw Pile[/gold]. |

### Countdown

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | CountdownPower=6, Countdown=6 |
| 升级 | countdownpower: +3 |
| 效果 | At the start of your turn, apply 6 [gold]Doom[/gold] to a random enemy. |

### Danse Macabre

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | Energy=2, DanseMacabrePower=3, DanseMacabre=3 |
| 升级 | dansemacabrepower: +1 |
| 效果 | Whenever you play a card that costs [energy:2] or more, gain 3 [gold]Block[/gold]. |

### Death March

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | CalculationBase=8, ExtraDamage=3, CalculatedDamage=11 |
| 升级 | damage: +1, calculationbase: +1, extradamage: +1 |
| 效果 | Deal 11 damage. Deals 3 additional damage for each card drawn during your turn. |

### Deathbringer

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 2 |
| 伤害 | - |
| 格挡 | - |
| 变量 | DoomPower=21, Doom=21, WeakPower=1, Weak=1 |
| 升级 | doom: +5 |
| 效果 | Apply 21 [gold]Doom[/gold] and 1 [gold]Weak[/gold] to ALL enemies. |

### Death's Door

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | 6 |
| 变量 | Block=6, Repeat=2 |
| 升级 | block: +1 |
| 效果 | Gain 6 [gold]Block[/gold]. If you applied [gold]Doom[/gold] this turn, gain [gold]Block[/gold] 2 additional times. |

### Debilitate

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 7 |
| 格挡 | - |
| 变量 | Damage=7, DebilitatePower=3, Debilitate=3 |
| 升级 | damage: +2, debilitatepower: +1 |
| 效果 | Deal 7 damage. [gold]Vulnerable[/gold] and [gold]Weak[/gold] are twice as effective against the enemy for the next 3 turns. |

---

## Basic

### Defend

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | 5 |
| 变量 | Block=5 |
| 升级 | block: +3 |
| 效果 | Gain 5 [gold]Block[/gold]. |

---

## Common

### Defile

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 13 |
| 格挡 | - |
| 关键词 | Ethereal |
| 变量 | Damage=13 |
| 升级 | damage: +4 |
| 效果 | Deal 13 damage. |

### Defy

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | 6 |
| 关键词 | Ethereal |
| 变量 | Block=6, WeakPower=1, Weak=1 |
| 升级 | block: +1, weak: +1 |
| 效果 | Gain 6 [gold]Block[/gold]. Apply 1 [gold]Weak[/gold]. |

---

## Uncommon

### Delay

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 2 |
| 伤害 | - |
| 格挡 | 11 |
| 变量 | Block=11, Energy=1 |
| 升级 | block: +2, energy: +1 |
| 效果 | Gain 11 [gold]Block[/gold]. Next turn, gain [energy:1]. |

---

## Rare

### Demesne

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 3 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Ethereal |
| 变量 | Energy=1, Cards=1 |
| 升级 | cost: 2 |
| 效果 | At the start of your turn, gain [energy:1] and draw 1 additional card. |

### Devour Life

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | DevourLifePower=1, DevourLife=1 |
| 升级 | devourlifepower: +1 |
| 效果 | Whenever you play a [gold]Soul[/gold], [gold]Summon[/gold] 1. |

---

## Uncommon

### Dirge

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 0 |
| 伤害 | - |
| 格挡 | - |
| 变量 | Summon=3 |
| 升级 | summon: +1 |
| 效果 | [gold]Summon[/gold] 3 X times. Add X [gold]Souls[/gold] into your [gold]Draw Pile[/gold]. |

---

## Common

### Drain Power

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 10 |
| 格挡 | - |
| 变量 | Damage=10, Cards=2 |
| 升级 | damage: +2, cards: +1 |
| 效果 | Deal 10 damage. [gold]Upgrade[/gold] 2 random cards in your [gold]Discard Pile[/gold]. |

---

## Uncommon

### Dredge

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Exhaust |
| 变量 | Cards=3 |
| 升级 | add_retain: True |
| 效果 | Put 3 cards from your [gold]Discard Pile[/gold] into your [gold]Hand[/gold]. |

---

## Rare

### Eidolon

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 2 |
| 伤害 | - |
| 格挡 | - |
| 变量 | intangibleThreshold=9 |
| 升级 | cost: 1 |
| 效果 | [gold]Exhaust[/gold] your [gold]Hand[/gold]. If 9 cards were [gold]Exhausted[/gold] this way, gain 1 [gold]Intangible[/gold]. |

### End of Days

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 3 |
| 伤害 | - |
| 格挡 | - |
| 变量 | DoomPower=29, Doom=29 |
| 升级 | doom: +8 |
| 效果 | Apply 29 [gold]Doom[/gold] to ALL enemies. Kill enemies with at least as much [gold]Doom[/gold] as HP. |

---

## Uncommon

### Enfeebling Touch

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Ethereal |
| 变量 | StrengthLoss=8 |
| 升级 | strengthloss: +3 |
| 效果 | Enemy loses 8 [gold]Strength[/gold] this turn. |

---

## Rare

### Eradicate

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 0 |
| 伤害 | 11 |
| 格挡 | - |
| 关键词 | Retain |
| 变量 | Damage=11 |
| 升级 | damage: +3 |
| 效果 | Deal 11 damage X times. |

---

## Common

### Fear

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 7 |
| 格挡 | - |
| 关键词 | Ethereal |
| 变量 | Damage=7, VulnerablePower=1, Vulnerable=1 |
| 升级 | damage: +1, vulnerable: +1 |
| 效果 | Deal 7 damage. Apply 1 [gold]Vulnerable[/gold]. |

---

## Uncommon

### Fetch

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 0 |
| 伤害 | 3 |
| 格挡 | - |
| 变量 | OstyDamage=3, Cards=1, Damage=3 |
| 升级 | damage: +3, ostydamage: +3 |
| 效果 | [gold]Osty[/gold] deals 3 damage. If this is the first time this card has been played this turn, draw 1 card. |

---

## Common

### Flatten

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 2 |
| 伤害 | 12 |
| 格挡 | - |
| 变量 | OstyDamage=12, Damage=12 |
| 升级 | damage: +4, ostydamage: +4 |
| 效果 | [gold]Osty[/gold] deals 12 damage. This card costs 0 [energy:1] if [gold]Osty[/gold] has attacked this turn. |

---

## Ancient

### Forbidden Grimoire

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 2 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Eternal |
| 升级 | cost: 1 |
| 效果 | At the end of combat, you may remove a card from your [gold]Deck[/gold]. |

---

## Uncommon

### Friendship

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | Energy=1, StrengthPower=2, Strength=2 |
| 升级 | strengthpower: -1 |
| 效果 | Lose 2 [gold]Strength[/gold]. Gain [energy:1] at the start of each turn. |

---

## Rare

### Glimpse Beyond

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Exhaust |
| 变量 | Cards=3 |
| 升级 | cards: +1 |
| 效果 | ALL players add 3 [gold]Souls[/gold] into their [gold]Draw Pile[/gold]. |

---

## Common

### Grave Warden

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | 8 |
| 变量 | Block=8, Cards=1 |
| 升级 | block: +2 |
| 效果 | Gain 8 [gold]Block[/gold]. Add a [gold]Soul[/gold] into your [gold]Draw Pile[/gold]. |

### Graveblast

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 4 |
| 格挡 | - |
| 关键词 | Exhaust |
| 变量 | Damage=4 |
| 升级 | damage: +2, remove_exhaust: True |
| 效果 | Deal 4 damage. Put a card from your [gold]Discard Pile[/gold] into your [gold]Hand[/gold]. |

---

## Rare

### Hang

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 10 |
| 格挡 | - |
| 变量 | Damage=10 |
| 升级 | damage: +3 |
| 效果 | Deal 10 damage. Double the damage ALL Hang cards deal to this enemy. |

---

## Uncommon

### Haunt

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | HpLoss=6 |
| 升级 | hploss: +2 |
| 效果 | Whenever you play a [gold]Soul[/gold], a random enemy loses 6 HP. |

### High Five

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 2 |
| 伤害 | 11 |
| 格挡 | - |
| 变量 | OstyDamage=11, VulnerablePower=2, Vulnerable=2, Damage=11 |
| 升级 | damage: +2, ostydamage: +2, vulnerable: +1 |
| 效果 | [gold]Osty[/gold] deals 11 damage and applies 2 [gold]Vulnerable[/gold] to ALL enemies. |

---

## Common

### Invoke

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | Summon=2, Energy=2 |
| 升级 | summon: +1, energy: +1 |
| 效果 | Next turn, [gold]Summon[/gold] 2 and gain [energy:2]. |

---

## Uncommon

### Legion of Bone

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 2 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Exhaust |
| 变量 | Summon=6 |
| 升级 | summon: +2 |
| 效果 | ALL players [gold]Summon[/gold] 6. |

### Lethality

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Ethereal |
| 变量 | LethalityPower=50, Lethality=50 |
| 升级 | lethalitypower: +25 |
| 效果 | The first Attack each turn deals 50% additional damage. |

### Melancholy

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 3 |
| 伤害 | - |
| 格挡 | 13 |
| 变量 | Block=13, Energy=1 |
| 升级 | block: +4 |
| 效果 | Gain 13 [gold]Block[/gold]. Reduce this card's cost by [energy:1] whenever ANYONE dies. |

---

## Rare

### Misery

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 0 |
| 伤害 | 7 |
| 格挡 | - |
| 变量 | Damage=7 |
| 升级 | damage: +2, add_retain: True |
| 效果 | Deal 7 damage. Apply any debuffs on the enemy to ALL other enemies. |

### Necro Mastery

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 2 |
| 伤害 | - |
| 格挡 | - |
| 变量 | Summon=5 |
| 升级 | summon: +3 |
| 效果 | [gold]Summon[/gold] 5. Whenever [gold]Osty[/gold] loses HP, ALL enemies lose that much HP as well. |

---

## Common

### Negative Pulse

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | 5 |
| 变量 | Block=5, DoomPower=7, Doom=7 |
| 升级 | block: +1, doom: +4 |
| 效果 | Gain 5 [gold]Block[/gold]. Apply 7 [gold]Doom[/gold] to ALL enemies. |

---

## Rare

### Neurosurge

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 0 |
| 伤害 | - |
| 格挡 | - |
| 变量 | Energy=3, Cards=2, NeurosurgePower=3, Neurosurge=3 |
| 升级 | energy: +1 |
| 效果 | Gain [energy:3]. Draw 2 cards. At the start of your turn, apply 3 [gold]Doom[/gold] to yourself. |

---

## Uncommon

### No Escape

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | DoomThreshold=10, CalculationBase=10, CalculationExtra=5 |
| 升级 | calculationbase: +5 |
| 效果 | Apply 10 [gold]Doom[/gold], plus an additional 5 [gold]Doom[/gold] for every 10 [gold]Doom[/gold] already on this enemy.[IsTargeting] |

---

## Rare

### Oblivion

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 0 |
| 伤害 | - |
| 格挡 | - |
| 变量 | DoomPower=3, Doom=3 |
| 升级 | doom: +1 |
| 效果 | Whenever you play a card this turn, apply 3 [gold]Doom[/gold] to the enemy. |

---

## Uncommon

### Pagestorm

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | Cards=1 |
| 升级 | cost: 0 |
| 效果 | Whenever you draw an [gold]Ethereal[/gold] card, draw 1 card. |

### Parse

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Ethereal |
| 变量 | Cards=3 |
| 升级 | cards: +1 |
| 效果 | Draw 3 cards. |

---

## Common

### Poke

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 0 |
| 伤害 | 6 |
| 格挡 | - |
| 变量 | OstyDamage=6, Damage=6 |
| 升级 | damage: +3, ostydamage: +3 |
| 效果 | [gold]Osty[/gold] deals 6 damage. |

---

## Ancient

### Protector

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | CalculationBase=10, ExtraDamage=1, CalculatedDamage=11 |
| 升级 | cost: 0, calculationbase: +5 |
| 效果 | [gold]Osty[/gold] deals 11 damage. Deals additional damage equal to [gold]Osty's[/gold] [gold]Max HP[/gold]. |

---

## Common

### Pull Aggro

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 2 |
| 伤害 | - |
| 格挡 | 7 |
| 变量 | Summon=4, Block=7 |
| 升级 | block: +2, summon: +1 |
| 效果 | [gold]Summon[/gold] 4. Gain 7 [gold]Block[/gold]. |

---

## Uncommon

### Pull from Below

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 5 |
| 格挡 | - |
| 变量 | Damage=5, CalculationBase=0, CalculationExtra=1 |
| 升级 | damage: +2 |
| 效果 | Deal 5 damage for each [gold]Ethereal[/gold] card played this combat.[InCombat] |

### Putrefy

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Exhaust |
| 变量 | Power=2 |
| 升级 | power: +1 |
| 效果 | Apply 2 [gold]Weak[/gold]. Apply 2 [gold]Vulnerable[/gold]. |

### Rattle

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 7 |
| 格挡 | - |
| 变量 | OstyDamage=7, CalculationBase=0, CalculationExtra=1, Damage=7 |
| 升级 | damage: +2, ostydamage: +2 |
| 效果 | [gold]Osty[/gold] deals 7 damage. Hits an additional time for each other time he has attacked this turn.[InCombat] |

---

## Rare

### Reanimate

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 3 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Exhaust |
| 变量 | Summon=20 |
| 升级 | summon: +5 |
| 效果 | [gold]Summon[/gold] 20. |

---

## Common

### Reap

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 3 |
| 伤害 | 27 |
| 格挡 | - |
| 关键词 | Retain |
| 变量 | Damage=27 |
| 升级 | damage: +6 |
| 效果 | Deal 27 damage. |

---

## Rare

### Reaper Form

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 3 |
| 伤害 | - |
| 格挡 | - |
| 升级 | add_retain: True |
| 效果 | Whenever Attacks deal damage, they also apply that much [gold]Doom[/gold]. |

---

## Common

### Reave

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 9 |
| 格挡 | - |
| 变量 | Damage=9, Cards=1 |
| 升级 | damage: +2 |
| 效果 | Deal 9 damage. Add a [gold]Soul[/gold] into your [gold]Draw Pile[/gold]. |

---

## Uncommon

### Right Hand Hand

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 0 |
| 伤害 | 4 |
| 格挡 | - |
| 变量 | OstyDamage=4, Energy=2, Damage=4 |
| 升级 | damage: +2, ostydamage: +2 |
| 效果 | [gold]Osty[/gold] deals 4 damage. Whenever you play a card that costs [energy:2] or more, return this to your [gold]Hand[/gold] from the [gold]Discard Pile[/gold]. |

---

## Rare

### Sacrifice

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Retain |
| 升级 | cost: 0 |
| 效果 | If [gold]Osty[/gold] is alive, he dies and you gain [gold]Block[/gold] equal to double his Max HP. |

---

## Common

### Scourge

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | Cards=1, DoomPower=13, Doom=13 |
| 升级 | doom: +3, cards: +1 |
| 效果 | Apply 13 [gold]Doom[/gold]. Draw 1 card. |

### Sculpting Strike

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 8 |
| 格挡 | - |
| 变量 | Damage=8 |
| 升级 | damage: +3 |
| 效果 | Deal 8 damage. Add [gold]Ethereal[/gold] to a card in your [gold]Hand[/gold]. |

---

## Rare

### Seance

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 0 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Ethereal |
| 变量 | Cards=1 |
| 效果 | Transform a card in your [gold]Draw Pile[/gold] into [gold]Soul[/gold]. |

### Sentry Mode

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 2 |
| 伤害 | - |
| 格挡 | - |
| 变量 | SentryModePower=1, SentryMode=1 |
| 升级 | cost: 1 |
| 效果 | At the start of your turn, add 1 [gold]Sweeping Gaze[/gold] into your [gold]Hand[/gold]. |

---

## Uncommon

### Severance

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 2 |
| 伤害 | 13 |
| 格挡 | - |
| 变量 | Damage=13 |
| 升级 | damage: +5 |
| 效果 | Deal 13 damage. Add a [gold]Soul[/gold] into your [gold]Draw Pile[/gold], [gold]Hand[/gold], and [gold]Discard Pile[/gold]. |

---

## Rare

### Shared Fate

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 0 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Exhaust |
| 变量 | EnemyStrengthLoss=2, PlayerStrengthLoss=2 |
| 升级 | enemystrengthloss: +1 |
| 效果 | Lose 2 [gold]Strength[/gold]. Enemy loses 2 [gold]Strength[/gold]. |

---

## Uncommon

### Shroud

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | 2 |
| 变量 | Block=2 |
| 升级 | block: +1 |
| 效果 | Whenever you apply [gold]Doom[/gold], gain 2 [gold]Block[/gold]. |

### Sic 'Em

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 5 |
| 格挡 | - |
| 变量 | OstyDamage=5, SicEmPower=2, SicEm=2, Damage=5 |
| 升级 | damage: +1, ostydamage: +1, sicempower: +1 |
| 效果 | [gold]Osty[/gold] deals 5 damage. Whenever [gold]Osty[/gold] hits this enemy this turn, [gold]Summon[/gold] 2. |

### Sleight of Flesh

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 2 |
| 伤害 | - |
| 格挡 | - |
| 变量 | SleightOfFleshPower=9, SleightOfFlesh=9 |
| 升级 | sleightoffleshpower: +4 |
| 效果 | Whenever you apply a debuff to an enemy, they take 9 damage. |

---

## Common

### Snap

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 7 |
| 格挡 | - |
| 变量 | OstyDamage=7, Damage=7 |
| 升级 | damage: +3, ostydamage: +3 |
| 效果 | [gold]Osty[/gold] deals 7 damage. Add [gold]Retain[/gold] to a card in your [gold]Hand[/gold]. |

---

## Rare

### Soul Storm

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | CalculationBase=9, ExtraDamage=2, CalculatedDamage=11 |
| 升级 | damage: +1, extradamage: +1 |
| 效果 | Deal 11 damage. Deals 2 additional damage for each [gold]Soul[/gold] in your [gold]Exhaust Pile[/gold]. |

---

## Common

### Sow

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 8 |
| 格挡 | - |
| 关键词 | Retain |
| 变量 | Damage=8 |
| 升级 | damage: +3 |
| 效果 | Deal 8 damage to ALL enemies. |

---

## Rare

### Spirit of Ash

| 属性 | 值 |
|---|---|
| 类型 | Power |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | BlockOnExhaust=4 |
| 升级 | blockonexhaust: +1 |
| 效果 | Whenever you play an [gold]Ethereal[/gold] card, gain 4 [gold]Block[/gold]. |

---

## Uncommon

### Spur

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Retain |
| 变量 | Summon=3, Heal=5 |
| 升级 | summon: +2, heal: +2 |
| 效果 | [gold]Summon[/gold] 3. [gold]Osty[/gold] heals 5 HP. |

---

## Rare

### Squeeze

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 3 |
| 伤害 | - |
| 格挡 | - |
| 变量 | CalculationBase=25, ExtraDamage=5, CalculatedDamage=30 |
| 升级 | damage: +1, calculationbase: +5, extradamage: +1 |
| 效果 | [gold]Osty[/gold] deals 30 damage. Deals 5 additional damage for ALL your other [gold]Osty[/gold] Attacks. |

---

## Basic

### Strike

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 6 |
| 格挡 | - |
| 变量 | Damage=6 |
| 升级 | damage: +3 |
| 效果 | Deal 6 damage. |

---

## Rare

### The Scythe

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 2 |
| 伤害 | 13 |
| 格挡 | - |
| 关键词 | Exhaust |
| 变量 | Increase=3, Damage=13, baseDamage=13 |
| 升级 | increase: +1 |
| 效果 | Deal 13 damage. Permanently increase this card's damage by 3. |

### Time's Up

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 2 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Exhaust |
| 变量 | CalculationBase=0, ExtraDamage=1, CalculatedDamage=1 |
| 升级 | add_retain: True |
| 效果 | Deal damage equal to the enemy's [gold]Doom[/gold].[IsTargeting] |

### Transfigure

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Exhaust |
| 变量 | Energy=1 |
| 升级 | remove_exhaust: True |
| 效果 | Add [gold]Replay[/gold] to a card in your [gold]Hand[/gold]. It costs an extra [energy:1]. |

### Undeath

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 0 |
| 伤害 | - |
| 格挡 | 7 |
| 变量 | Block=7 |
| 升级 | block: +2 |
| 效果 | Gain 7 [gold]Block[/gold]. Add a copy of this card into your [gold]Discard Pile[/gold]. |

---

## Basic

### Unleash

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | - |
| 格挡 | - |
| 变量 | CalculationBase=6, ExtraDamage=1, CalculatedDamage=7 |
| 升级 | calculationbase: +3 |
| 效果 | [gold]Osty[/gold] deals 7 damage. Deals additional damage equal to [gold]Osty's[/gold] current HP. |

---

## Uncommon

### Veilpiercer

| 属性 | 值 |
|---|---|
| 类型 | Attack |
| 费用 | 1 |
| 伤害 | 10 |
| 格挡 | - |
| 变量 | Damage=10 |
| 升级 | damage: +3 |
| 效果 | Deal 10 damage. The next [gold]Ethereal[/gold] card you play costs 0 [energy:1]. |

---

## Common

### Wisp

| 属性 | 值 |
|---|---|
| 类型 | Skill |
| 费用 | 0 |
| 伤害 | - |
| 格挡 | - |
| 关键词 | Exhaust |
| 变量 | Energy=1 |
| 升级 | add_retain: True |
| 效果 | Gain [energy:1]. |


