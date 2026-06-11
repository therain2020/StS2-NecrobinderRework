# 方案A：卡片替换实现计划

> **目标**：用 BaseLib CustomCardModel 创建替换卡，完整控制 OnPlay 追加效果 + 本地化描述

---

## 一、架构概览

> **核心机制**: 替换卡继承 `BaseLib.Abstracts.CustomCardModel`（不是原卡类），完全重写 `OnPlay` + `CanonicalVars`。
> 通过 Harmony Patch `NecrobinderCardPool.get_AllCards`，在返回值中将原卡实例替换为替换卡实例。

```
CustomCardModel                     NecrobinderCardPool.AllCards
+--------------------------+        +----------------------+
| BodyguardRework          | 注册-> | BodyguardRework      | <- 替换原 Bodyguard
| - CanonicalVars (独立定义) |        | NegativePulseRework  | <- 替换原 NegativePulse
| - OnPlay (完整控制)       |        | CaptureSpiritRework  | <- 替换原 CaptureSpirit
| - OnUpgrade (独立定义)    |        | TimesUpRework        | <- 替换原 Time's Up
+--------------------------+        | (原卡实例被 Skip)      |
                                    +----------------------+
```

**替换 vs 原卡的关系**：
- 替换卡**不继承**原卡类（C# 不能多重继承，CustomCardModel 已继承 CardModel）
- 替换卡**完全重新实现** OnPlay（包括原效果 + 追加交叉效果）
- 池替换通过 `ModHelper.AddModelToPool` 注册 + Harmony Postfix 替换 AllCards 返回值

---

## 二、需要创建替换卡的目标

| 原卡 | 替换卡名 | 追加的 OnPlay 效果 | 改动类型 |
|---|---|---|---|
| Bodyguard | BodyguardRework | Summon后 +1 Soul 到抽牌堆 | 追加效果 |
| NegativePulse | NegativePulseRework | Block+Doom后 +Summon 1 | 追加效果 |
| CaptureSpirit | CaptureSpiritRework | 敌-Soul后 +Summon 2 | 追加效果 |
| Time's Up | TimesUpRework | 升级后追加 Summon=Doom量 (Doom→Osty) | 追加效果 |

### 各替换卡实现规格

#### BodyguardRework (已实现)

| 属性 | 值 |
|---|---|
| 基类 | `CustomCardModel(1, Skill, Basic, Self)` |
| CanonicalVars | `SummonVar(7)`, `CardsVar(1)` |
| OnPlay | `OstyCmd.Summon(7)` + `CardPileCmd.Draw(1)` |
| OnUpgrade | `Summon +2` (7->9) |
| 本地化 Key | `BODYGUARD_REWORK` |

#### NegativePulseRework

| 属性 | 值 |
|---|---|
| 基类 | `CustomCardModel(1, Skill, Common, AllEnemies)` |
| CanonicalVars | `BlockVar(7)`, `DoomVar(7)`, `SummonVar(1)` |
| OnPlay | Block 7 自 -> Doom 7 全体敌 -> Summon 1 |
| OnUpgrade | `Block +2` (7->9), `Doom +2` (7->9) |
| 本地化 Key | `NEGATIVE_PULSE_REWORK` |
| 注 | Doom 需用 `PowerCmd` 给所有存活敌人施加 `DoomPower` |

#### CaptureSpiritRework

| 属性 | 值 |
|---|---|
| 基类 | `CustomCardModel(1, Skill, Uncommon, Enemy)` |
| CanonicalVars | `CardsVar(3)`, `SummonVar(2)`, HP 损失在 OnPlay 硬编码 |
| OnPlay | 目标敌 -3 HP -> 抽牌堆 +3 Soul -> Summon 2 |
| OnUpgrade | `Cards +2` (Soul 3->5), `Summon +1` (2->3) |
| 本地化 Key | `CAPTURE_SPIRIT_REWORK` |

#### TimesUpRework

| 属性 | 值 |
|---|---|
| 基类 | `CustomCardModel(2, Attack, Rare, AnyEnemy)` |
| CanonicalVars | `CardsVar(0)` (升级标记) |
| OnPlay | Doom伤害 + Exhaust; 升级后追加 Summon = Doom量 (Doom->Osty) |
| OnUpgrade | `Cards +1` |
| 本地化 Key | `TIMES_UP_REWORK` |
| 设计 | Doom->Osty 交叉: 敌人灾厄越深 -> 召唤亡灵越多 |

**不需要替换的卡** (纯 CanonicalVars 已生效，保留现有 Harmony Patch):
Fetch, Flatten, SicEm, Spur, Squeeze, Calcify, HighFive, DeathsDoor, Haunt, SoulStorm, Defile, Reap, DrainPower, Wisp -- 共 14 张。

> **Countdown 说明**: `V02_CrossArchetype.cs` 中 Countdown 的 patch (Doom 6->9 + Cards=1) 保留。但其真正的"Doom->Soul"交叉效果 (回合开始时生成 Soul) 无法通过纯 CanonicalVars 实现，留待远期 CustomCardModel 化。

---

## 三、文件变更清单

### Step 1: 项目基础设施

| 文件 | 操作 | 内容 |
|---|---|---|
| `NecrobinderRework.csproj` | 已有 | 已引用 BaseLib 3.1.7, net9.0, Harmony, GodotSharp |
| `godot/mod_manifest.json` | 已有 | 已含 `"dependencies": ["BaseLib"]`, `"has_pck": true` |
| `godot/project.godot` | 已有 | config_version=5 |
| `godot/export_presets.cfg` | 已有 | 导出预设已配置 |

### Step 2: 创建替换卡类

| 文件 | 内容 |
|---|---|
| `Cards/BodyguardRework.cs` | 已有. CustomCardModel, OnPlay Summon+Draw |
| `Cards/NegativePulseRework.cs` | 新建. CustomCardModel, OnPlay Block+Doom+Summon |
| `Cards/CaptureSpiritRework.cs` | 新建. CustomCardModel, OnPlay HPLoss+Soul+Summon |
| `Cards/TimesUpRework.cs` | 新建. CustomCardModel, OnPlay DoomDamage+Kill |

### Step 3: 卡片注册与池替换

| 文件 | 操作 |
|---|---|
| `ModEntry.cs` | 修改 | 添加 4 张卡的 `AddModelToPool` + 更新 `Replacements` 字典 |

### Step 4: 本地化

| 文件 | 内容 |
|---|---|
| `godot/localization/eng/cards.json` | 已有. 4 张替换卡的新描述 (含追加效果文本) |

### Step 5: 清理旧 Patch (按类名精确移除)

| 文件 | 移除的类 | 保留的类 |
|---|---|---|
| `Patches/Phase2_OstyCards.cs` | `BodyguardPatch` | UnleashPatch, FetchPatch, FlattenPatch, SicEmPatch, SpurPatch, SqueezePatch, CalcifyPatch, HighFivePatch |
| `Patches/Phase3_DoomBlock.cs` | `NegativePulsePatch` | `DeathsDoorPatch` |
| `Patches/V02_CrossArchetype.cs` | `BodyguardCrossPatch`, `NegativePulseCrossPatch`, `CaptureSpiritCrossPatch` | SoulStormCrossPatch, HauntVarsPatch, CountdownCrossPatch |
| `Patches/V02_OnUpgrade.cs` | `TimesUpUpgradePatch`, `TimesUpOnPlayPatch` | `DrainPowerUpgradePatch` |

### Step 6: .pck 打包与部署

```
godot/ -> Godot --export-pack -> build/NecrobinderRework.pck
+-- mod_manifest.json
+-- project.godot
+-- project.binary
+-- localization/
|   +-- eng/
|       +-- cards.json
+-- .godot/
```

---

## 四、卡牌替换流程示意

```
游戏启动
  -> ModEntry.Initialize()
    -> Harmony Patch: NecrobinderCardPool.get_AllCards
      -> 原返回值中找 Bodyguard 实例 -> 替换为 BodyguardRework 实例
      -> 原返回值中找 NegativePulse 实例 -> 替换为 NegativePulseRework 实例
      -> (同上 CaptureSpirit, TimesUp)
    -> ModHelper.AddModelToPool (注册替换卡类型)

玩家开新局
  -> 起手牌组自动包含替换卡 (因为 Through Pool)
  -> 战斗中打出 -> OnPlay 包含交叉效果
  -> 卡面显示新描述 (通过 localize/eng/cards.json)
```

---

## 五、风险与对策

| 风险 | 影响 | 对策 |
|---|---|---|
| BaseLib 版本不兼容 | 编译/加载失败 | 当前使用 v3.1.7 (NuGet), 已编译通过 |
| 替换卡未被游戏识别 | 池中无替换卡 | 先用 TestMode 直接构造替换卡实例验证 OnPlay |
| .pck 本地化未合并 | 描述不更新 | 已验证路径 `localization/eng/cards.json` |
| CustomCardModel 实例化 | 池替换创建失败 | `Activator.CreateInstance` 已验证可行; CustomCardModel 不是原生 ModelDb 管理的单例 |
| OnPlay API 兼容性 | 异步命令签名不匹配 | 以 BodyguardRework 已验证的 `OstyCmd.Summon` / `CardPileCmd.Draw` 模式为模板扩展 |

---

## 六、执行顺序

```
1. 添加 BaseLib 依赖 -> dotnet restore 验证 [已完成]
2. 创建 1 张替换卡 (BodyguardRework) -> 编写 OnPlay -> 本地化 -> .pck [已完成]
3. 注册 + 池替换 -> 进游戏验证 Bodyguard 是否打出 Soul [待进游戏验证]
4. 验证成功后 -> 复制模式创建剩余 3 张替换卡 [本次实施]
5. 清理旧 Patch -> 最终构建 -> 全量测试 [本次实施]
```

---

## 七、验收清单

| # | 检查项 | 通过标准 |
|---|---|---|
| 1 | `dotnet build` 无错误 | 4 张替换卡 + ModEntry 全部编译通过 |
| 2 | 旧 patch 无冗余 | Bodyguard/NegativePulse/CaptureSpirit/TimesUp 不再被 Harmony Patch 拦截 |
| 3 | 进游戏可见替换卡 | 起手牌组中出现 BodyguardRework (Summon 7 + Draw 1) |
| 4 | OnPlay 交叉效果触发 | 打出后 Soul/Soul/Summon 追加效果生效 |
| 5 | 升级效果正确 | 数值按规格增加 |
| 6 | 本地化正常显示 | 卡面描述匹配 `cards.json` 文本 |
