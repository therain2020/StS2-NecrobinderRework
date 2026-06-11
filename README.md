# Necrobinder Rework

[English](#english) | [中文](#chinese)

---

## English

### Overview

A gameplay rebalance mod for the Necrobinder character in Slay the Spire 2 (v0.103.3). Built with [BaseLib](https://github.com/Alchyr/BaseLib-StS2).

**Core design philosophy**: Make Necrobinder's three archetypes—Osty (Undead), Doom (Decay), and Soul (Harvest)—viable individually while creating natural synergies between them.

### Features

**6-Way Cross-Archetype Synergy**: Each archetype feeds into the others:

| From | To | Card | Effect |
|---|---|---|---|
| Osty → Soul | Bodyguard | Summon 7 + Draw 1 Soul card |
| Doom → Osty | Negative Pulse | 7 Block + 7 Doom ALL + Summon 1 |
| Doom → Osty | Time's Up | Deal Doom damage; upgraded: Summon = Doom amount |
| Soul → Doom | Soul Storm | Damage scales with Souls; applies Doom = Souls/2 |
| Soul → Osty | Capture Spirit | Enemy -3 HP + 3 Souls + Summon 2 |
| Osty → Doom | Calcify | Osty damage +6 (numeric patch) |

**Base Stat Adjustments** (Phase 1):
- Starting HP: 66 → 72
- Osty initial HP: 1 → 6
- Starting relic: Summon 1 → Summon 2 per turn

**Numerical Buffs** (14 cards): Osty attack cards buffed 20-40%, Doom block values improved, Wisp upgrade enhanced.

### Installation

1. Install [BaseLib](https://github.com/Alchyr/BaseLib-StS2) (v3.1.7+)
2. Download `NecrobinderRework.dll` and `NecrobinderRework.pck` from [Releases](https://github.com/YOUR_USERNAME/StS2-NecrobinderRework/releases)
3. Place both files in `Steam/steamapps/common/Slay the Spire 2/mods/NecrobinderRework/`
4. Launch the game

### Build from Source

```powershell
git clone https://github.com/YOUR_USERNAME/StS2-NecrobinderRework.git
cd StS2-NecrobinderRework
dotnet restore
dotnet build
```

Requires .NET 9.0 SDK. Update `Sts2Dir` in `NecrobinderRework.csproj` to match your game install path.

### Technical Details

- **Language**: C# / .NET 9.0
- **Modding Framework**: Harmony + BaseLib
- **Card Implementation**: 4 CustomCardModel replacements + 1 Harmony Postfix + 14 CanonicalVars patches
- **Game Version**: Slay the Spire 2 v0.103.3

### License

MIT

---

## 中文

### 概述

杀戮尖塔2 Necrobinder（死灵法师）角色玩法重做模组。基于 [BaseLib](https://github.com/Alchyr/BaseLib-StS2) 构建。

**核心理念**：让 Osty（亡灵）、Doom（灾厄）、Soul（灵魂）三大流派各自可通 A20，同时流派间自然联动。

### 特性

**六向流派交叉**：

| 方向 | 卡牌 | 效果 |
|---|---|---|
| Osty→Soul | 护卫 | 召唤 7 + 抽 1 张灵魂 |
| Doom→Osty | 负能量脉冲 | 7 格挡 + 7 灾厄全体 + 召唤 1 |
| Doom→Osty | 时间到 | 灾厄伤害，升级后追加召唤 |
| Soul→Doom | 灵魂风暴 | 伤害随灵魂数增长，施加灾厄=灵魂数/2 |
| Soul→Osty | 捕获灵魂 | 敌-3血 + 3灵魂 + 召唤 2 |
| Osty→Doom | 钙化 | Osty攻击+6伤（数值强化） |

**基础数值调整**：初始血量 66→72，Osty 初始 HP 1→6，初始遗物每回合召唤 2。

**14 张数值强化卡**：Osty 攻击卡普遍提升 20-40%，Doom 格挡卡数值优化。

### 安装

1. 安装 [BaseLib](https://github.com/Alchyr/BaseLib-StS2) (v3.1.7+)
2. 从 [Releases](https://github.com/YOUR_USERNAME/StS2-NecrobinderRework/releases) 下载 `NecrobinderRework.dll` 和 `NecrobinderRework.pck`
3. 放入 `Steam/steamapps/common/Slay the Spire 2/mods/NecrobinderRework/`
4. 启动游戏

### 技术细节

- **语言**: C# / .NET 9.0
- **模组框架**: Harmony + BaseLib
- **卡牌实现**: 4 CustomCardModel + 1 Harmony Postfix + 14 CanonicalVars 补丁
- **游戏版本**: 杀戮尖塔2 v0.103.3

### 协议

MIT
