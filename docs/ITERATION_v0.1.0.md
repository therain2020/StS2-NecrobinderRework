# Necrobinder Rework — 流派交织设计文档

> **核心理念**: Osty(亡灵) / Doom(灾厄) / Soul(灵魂) 三位一体，互相滋养。
> 交叉不应该像打补丁，而应该是每个流派自然运作时产生的"副产品"。

---

## 一、三位一体的主题对应

| 流派 | 英文 | 代表动作 | 主题 |
|---|---|---|---|
| Osty | Undead | Summon | 召唤亡灵、建立防线 |
| Doom | Decay | Apply Doom | 散布灾厄、标记死亡 |
| Soul | Harvest | 生成/打出 Soul | 收割灵魂、循环法力 |

## 二、六向循环

```
         ┌──────────────────────────────┐
         │                              ▼
       Osty ──→ 攻击附带 Doom ──→  Doom
         ▲                              │
         │     (亡灵召来灾厄)            │ Doom 杀敌
         │                              │ 释放灵魂
    Soul 喂养老 Osty                    │
         │                              ▼
         └────────── Soul ◀─────────────┘
              (灵魂强化 Doom)
```

### 已存在的自然连接（不改）

| 卡牌 | 方向 | 效果 |
|---|---|---|
| Devour Life (Rare Power) | Soul → Osty | 每打 Soul → Summon 1 |
| NecroMastery (Rare Power) | Osty → Doom | Osty 受伤 → 全体反射 |
| Dirge (Uncommon) | Osty ↔ Soul | Summon + 加 Soul |
| Haunt (Uncommon Power) | Soul → 伤害 | Soul → 随机敌 6 伤 |
| CaptureSpirit (Uncommon) | 敌 → Soul | 损失 HP + 加 Soul |

### 我们创建的连接（新增）

| # | 卡牌 | 方向 | 新增效果 | 为什么自然 |
|---|---|---|---|---|
| 1 | **Bodyguard** (Basic) | **Osty → Soul** | Summon 后 +1 Soul 到抽牌堆 | 召唤亡灵时产生灵魂残余 |
| 2 | **NegativePulse** (Common) | **Doom → Osty** | Block+Doom 后 +Summon 1 | 散布灾厄加深与 Osty 的联结 |
| 3 | **CaptureSpirit** (Uncommon) | **Soul → Osty** | 追加 Summon 2 | 捕获灵魂同时喂养 Osty |
| 4 | **Countdown** (Uncommon Power) | **Doom → Soul** | 回合开始 +1 Soul 到抽牌堆 | 倒计时的死亡释放灵魂 |
| 5 | **Soul Storm** (Rare Attack) | **Soul → Doom** | 伤害 + 施加 Doom = Soul数×0.5 | 灵魂风暴携带死亡印记 |
| 6 | **Haunt** (Uncommon Power) | **Soul → 伤害** | 伤害 6→8 | 灵魂纠缠更强烈 |

## 三、每张卡的设计理由

### 1. Bodyguard（Basic）— Osty → Soul
```
原：Summon 5（已增至7）
新：Summon 后 +1 Soul 到 Draw Pile
```
**为什么自然**: Bodyguard 是每个 Necrobinder 开局的入口卡。把 Osty 的 Summon 和 Soul 生成连接起来，从第一回合就让玩家感受到"召唤亡灵产生灵魂能量"的循环。

### 2. NegativePulse（Common）— Doom → Osty
```
原：5 Block + 全体 7 Doom（Block 已增至7）
新：+Summon 1
```
**为什么自然**: NegativePulse 是 Doom 流的常用防卡。施加灾厄的同时维系 Osty 的存在——这是死灵法师最基本的生存手段。不给太多（Summon 1），刚好让玩家觉得"拿 Doom 卡也不会完全放弃 Osty"。

### 3. CaptureSpirit（Uncommon）— Soul → Osty
```
原：敌 -3HP, +3 Soul 到 Draw Pile
新：+Summon 2
```
**为什么自然**: "捕获灵魂"——捕获的灵魂部分用于抽牌（Soul），部分喂养 Osty（Summon）。一张卡同时推进两个流派。

### 4. Countdown（Uncommon Power）— Doom → Soul
```
原：回合开始 6 Doom 随机敌（已增至9）
新：+1 Soul 到 Draw Pile
```
**为什么自然**: Countdown 是"倒计时"——每回合的死亡标记。当死亡倒计时推进时，濒死的敌人释放 Soul。Power 卡天然适合做交叉，因为每回合都触发。

### 5. Soul Storm（Rare Attack）— Soul → Doom
```
原：9 伤 + 每张消耗中 Soul +2 伤
新：施加 Doom = 消耗中 Soul 数量 × 0.5
```
**为什么自然**: Soul Storm 是消耗 Soul 的爆发攻击。灵魂风暴席卷敌人时，留下死亡印记（Doom）。这是 Soul 流和 Doom 流的最强连接点——你积攒的 Soul 越多，Soul Storm 不仅伤害越高，留下的 Doom 也越深。

### 6. Haunt（Uncommon Power）— Soul → 伤害
```
原：Soul → 随机敌 6 伤
新：8 伤
```
**为什么自然**: 魂灵纠缠的强度还不够。从 6 到 8 是合理的加强，让 Soul 引擎的伤害回报更明显，不改变设计方向。

---

## 四、交叉矩阵（最终版）

| | → Osty | → Doom | → Soul |
|---|---|---|---|
| **Osty →** | — | NecroMastery(已有) | **Bodyguard(新)** |
| | | Calcify(已有) | |
| **Doom →** | **NegativePulse(新)** | — | **Countdown(新)** |
| **Soul →** | DevourLife(已有) | **SoulStorm(新)** | — |
| | **CaptureSpirit(新)** | | |
| | Dirge(已有) | | |

## 五、本次实现清单（与初版 v0.1.0 对比）

| 初版 | 终版 | 变化 |
|---|---|---|
| Bodyguard +3 Doom | **Bodyguard +1 Soul** | 方向改为 Osty→Soul |
| NegativePulse +Summon 1 | 不变 | — |
| CaptureSpirit +Summon 2 | 不变 | — |
| Countdown Cards=1 | **Countdown +1 Soul** | 改为具体 Soul 生成 |
| Scourge Cards=2 | **移除** | 太临时，不算真正的交叉 |
| Haunt 6→8 | 不变 | — |
| — | **新增：SoulStorm +Doom** | Soul→Doom 的连接点 |

---

## 六、实施优先级

| 优先级 | 改动 | 原因 |
|---|---|---|
| **现在** | #2 NegativePulse, #3 CaptureSpirit, #6 Haunt | 已有代码，已验证 |
| **重做** | #1 Bodyguard: +3 Doom → +1 Soul | 方向调整 |
| **重做** | #4 Countdown: +Cards → +Soul 生成 | 改为更具体的 Soul |
| **新增** | #5 SoulStorm: +Doom 效果 | 填补 Soul→Doom 空白 |
