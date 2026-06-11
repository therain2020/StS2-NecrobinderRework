# Necrobinder Rework — 设计文档

> **版本**: 1.0.0 | **游戏版本**: STS2 v0.103.3 | **日期**: 2026-06-10
> **数据来源**: Spire Codex (sts2.dll 反编译提取, 88 张卡完整数据)

---

## 一、设计哲学

> **让玩家享受卡牌构筑带来的快乐，而不是被数值和机制所恶心。**

### 核心原则

| # | 原则 | 说明 |
|---|---|---|
| 1 | **每个流派都值得玩** | Osty 随从、Doom 处决、Soul 循环均可通 A20 |
| 2 | **降低入门门槛** | Act 1 不依赖特定卡牌掉落才能活下去 |
| 3 | **强化角色特色** | Osty 是她最独特的机制，必须是**最可靠**的流派 |
| 4 | **尊重玩家时间** | 不靠超低容错率制造虚假难度 |
| 5 | **精准改动** | 只改真正有问题的卡，不碰已经平衡的卡 |

---

## 二、玩家社群反馈

| 排名 | 问题 | 社群原话 |
|---|---|---|
| **P0** | **Osty 流派不可用** | *"They don't use the hand for any of their strong decks... If you try to use the hand, enemies will just run you over."* |
| **P0** | **Act 1 暴毙率极高** | *"I have to path to every single campfire just to keep healing."* |
| **P0** | **66 最低血量** | *"eating an unexpected 15 damage when you only have 66 total HP is a fast track back to the main menu."* |
| **P1** | **能量经济差** | 仅 9 张 0 费卡 (Ironclad 12, Silent/Defect 各 15) |
| **P1** | **Osty 伤害穿透 Bug** | *"damage leaks through when the giant hand is supposed to absorb it."* |
| **P2** | **Doom 等待感** | 除了 End of Days 外，所有 Doom 都要等敌人回合结束才斩杀 |

---

## 三、改动方案

### Phase 1: 角色基础数值（P0）

| 属性 | 原值 | 新值 | 理由 |
|---|---|---|---|
| 起始 HP | **66** | **72** | Silent 70 / Defect 75 之间，不再是最低 |
| Osty 初始 HP | **1** | **6** | Necrobinder Plus mod 已验证可行 |
| 初始遗物 Bound Phylactery | 每回合 Summon 1 | **每回合 Summon 2** | 更快建立 Osty 防线 |

---

### Phase 2: Osty 攻击卡强化（P0）

Osty 攻击卡数值整体提升 20-40%，让 Osty 流派成为可靠默认策略。

| 卡牌 | 稀有度 | 费用 | 原效果 | 新效果 | 升级 |
|---|---|---|---|---|---|
| **Bodyguard** | Basic | 1 | Summon 5 | **Summon 7** | Summon 10 |
| **Unleash** | Basic | ? | Osty存活→全体 9 伤+9 Block, Osty死 | **全体 12 伤+12 Block** | 15 伤+15 Block |
| **Fetch** | Common | 1 | Osty 3 伤, 首次打出抽1 | **Osty 5 伤** | Osty 8 伤 |
| **Flatten** | Common | 2 | Osty 12 伤, Osty攻击后→0费 | **Osty 15 伤** | Osty 20 伤 |
| **Sic 'Em** | Uncommon | 1 | Osty 5 伤, Osty命中→Summon 2 | **Osty 7 伤** | Osty 9 伤, Summon 3 |
| **Spur** | Uncommon | ? | 保留, Summon 3, Osty治疗 5 | **Summon 5, 治疗 7** | Summon 8, 治疗 10 |
| **Squeeze** | Rare | 3 | Osty 25 伤+每张Osty卡+5 | **Osty 30 伤+每张Osty卡+6** | 终极大招 |
| **Calcify** | Uncommon | 1 | Osty 攻击+4 伤 | **Osty 攻击+6 伤** | +8 伤 |
| **High Five** | Uncommon | ? | Osty 11 伤+全体2易伤 | **Osty 13 伤** | Osty 16 伤 |

---

### Phase 3: Doom 手感优化（P1）

#### 3.1 增加提前斩杀卡牌

Doom 默认在敌人回合结束时斩杀。End of Days（3费稀有）是唯一的立即斩杀卡。需要在中低稀有度提供更多提前斩杀选项。

| 卡牌 | 稀有度 | 费用 | 原效果 | 新效果 | 设计意图 |
|---|---|---|---|---|---|
| **End of Days** | Rare | 3 | 全体 29 Doom, 立即斩杀 | **不变** ✅ | 已是完美设计 |
| **Time's Up** | Rare | 2 | 伤害=敌人Doom, 消耗 | 升级追加: **打出后若敌人 HP ≤ Doom，立即斩杀** | 不只是打伤害，真正"时间到了" |
| **Countdown** | Uncommon | 1 | 回合开始: 随机敌人 6 Doom | **9 Doom** + 回合开始时若任意敌人 Doom ≥ HP，**立即斩杀** | Doom 流加速引擎，在敌人行动前终结 |
| **Scourge** | Uncommon | 1 | 施加 13 Doom, 抽1 | 升级追加: 施加 16 Doom, 抽2, **若目标 Doom ≥ HP 立即斩杀** | 中稀有度条件斩杀 |

#### 3.2 Doom 赋予时的格挡数值提升

| 卡牌 | 稀有度 | 费用 | 原效果 | 新效果 | 理由 |
|---|---|---|---|---|---|
| **Negative Pulse** | Common | 1 | 5 Block + 全体 7 Doom | **7 Block** + 全体 7 Doom | Doom 流核心防卡 +2 Block |
| **Death's Door** | Uncommon | 1 | 6 Block, Doom→×2次(共18) | **8 Block**, 触发后共 **24 Block** | 条件回报更大 |
| **Deathbringer** | Uncommon | 2 | 全体 21 Doom + 1 Weak | 追加 **获得 5 Block** | AoE Doom 附带生存 |

---

### Phase 4: 能量经济（P1）

| 卡牌 | 稀有度 | 原效果 | 改动 | 理由 |
|---|---|---|---|---|
| **Wisp** | Common | 0费, +1能量, 升级: 保留 | 升级追加: 保留 + **抽 1 张** | 0 费能量卡升级价值太低 |

---

### Phase 5: Bug 修复（P2）

| Bug | 修复方案 |
|---|---|
| **Osty 伤害穿透** | Patch `AfterModifyingHpLostBeforeOsty` 确保 Osty 存活时攻击伤害不泄露到 Necrobinder |

---

## 四、改动总览

| Phase | 内容 | 改动数 |
|---|---|---|
| Phase 1 | 角色基础数值（HP, Osty HP, 遗物） | 3 |
| Phase 2 | Osty 攻击卡强化（9 张卡） | 9 |
| Phase 3 | Doom 手感优化（7 项） | 7 |
| Phase 4 | 能量经济（Wisp 升级） | 1 |
| Phase 5 | Bug 修复 | 1 |
| **合计** | | **20 项** |

### 不再改动的卡牌

以下卡牌在之前版本中被错误归类为"废卡"，经 Spire Codex 数据验证后确认**无需修改**：

| 卡牌 | 实际效果 | 不改原因 |
|---|---|---|
| Eidolon | Rare, 2费, 消耗手牌≥9→1无形 | 稀有卡有独特构筑价值 |
| Parse | Uncommon, 1费, 抽3 | 标准抽牌卡 |
| Danse Macabre | Uncommon, 1费, 打2+费→3Block | Borrwed Time 构筑专用 |
| Delay | Uncommon, 2费, 11Block+下回合1能量 | 标准防御卡 |
| Death March | Uncommon, 1费, 8+3/抽牌 | 抽牌流攻击卡 |
| Seance | Rare, 0费, 抽牌堆→Soul | Soul 体系专用 |
| Invoke | Common, 1费, 下回合Summon2+2能量 | 延迟收益卡 |

---

## 五、技术实现

采用 Harmony Postfix 拦截属性 getter 和卡牌 CanoicalVars：

```csharp
// 修改起始 HP
[HarmonyPatch(typeof(Necrobinder), "get_StartingHp")]
public static class StartingHpPatch {
    public static void Postfix(ref int __result) { __result = 72; }
}

// 修改卡牌变量（以 Negative Pulse Block 为例）
[HarmonyPatch(typeof(NegativePulse), "get_CanonicalVars")]
public static class NegativePulsePatch {
    public static void Postfix(ref IEnumerable<ValueProp> __result) {
        // Block: 5→7, Doom unchanged
    }
}
```

---

## 六、版本记录

| 版本 | 日期 | 变更 |
|---|---|---|
| 1.0.0 | 2026-06-10 | 基于 Spire Codex (sts2.dll 反编译) 完整 88 张卡数据彻底重写。移除所有基于错误归类的改动 |
| 0.2.0 | 2026-06-10 | 基于社区数据交叉验证重写 |
| 0.1.0 | 2026-06-10 | 初始设计文档 |
