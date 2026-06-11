# 方案B：流派交织深化设计

> **目标**：在方案A的4张CustomCardModel基础上，继续扩展至10+张卡，完整闭合6向交叉循环，让"多流派交织"从概念变成每一局都能感受到的实际体验。

---

## 一、现状：方案的4张卡只覆盖了6向中的3向

```
         Osty ──Bodyguard──→ Soul
          ↑                    │
    CaptureSpirit          ⚠️ 缺失
          │                    │
        Soul ◀── ⚠️ 缺失 ── Doom
                NegativePulse
```

| 方向 | 当前状态 |
|---|---|
| Osty→Soul | Bodyguard ✅ |
| Doom→Osty | NegativePulse ✅ |
| Soul→Osty | CaptureSpirit ✅ |
| Soul→Doom | **缺失** |
| Doom→Soul | **缺失** |
| Osty→Doom | **缺失** |

---

## 二、新增卡牌设计

### Priority 1：闭合 3 个缺失方向

#### 1. Calcify（Uncommon Power, 1费）—— Osty→Doom

| | 当前 | 新设计 |
|---|---|---|
| 原效果 | Osty攻击+6伤（数值） | Osty攻击+6伤 |
| 追加 | — | **Osty攻击后施加1层Doom** |
| 升级 | +8伤 | +8伤，**施加2层Doom** |

> **设计理由**：Calcify 是 Osty 的核心强化卡。Osty 攻击强化后附带死亡标记——"钙化的亡灵之爪留下灾厄的痕迹"。Osty 攻击次数越多，Doom 堆积越快。

```
描述：
"Osty攻击+6伤。
Osty每次攻击施加1层灾厄。"
```

#### 2. Countdown（Uncommon Power, 1费）—— Doom→Soul

| | 当前 | 新设计 |
|---|---|---|
| 原效果 | 回合开始随机敌人6 Doom | 回合开始随机敌人**9 Doom** |
| 追加 | — | **回合开始：抽牌堆+1 Soul** |
| 升级 | — | Doom 9→**11**，Soul **+2** |

> **设计理由**：Countdown 是"死亡倒计时"。每回合倒计时推进 → 濒死敌人释放灵魂能量。Power 卡每回合自动触发，是 Doom→Soul 最稳定的桥梁。

```
描述（Innate）：
"回合开始：随机敌人9层灾厄。
回合开始：抽牌堆+1灵魂。"
```

#### 3. SoulStorm（Rare Attack, 2费）—— Soul→Doom

| | 当前 | 新设计 |
|---|---|---|
| 原效果 | 9伤 + 每Soul+2伤 | 9伤 + 每Soul+2伤 |
| 追加 | — | **施加 Doom = 消耗堆 Soul数 × 0.5** |
| 升级 | 抽1 | 抽1，**Doom量翻倍（Soul数×1.0）** |

> **设计理由**：SoulStorm 消耗 Soul 爆发——灵魂风暴席卷后留下死亡印记。这是 Soul 流和 Doom 流最强的连接点。

```
描述：
"9伤。消耗堆每张灵魂+2伤。
施加灾厄 = 灵魂数一半。抽1张牌。"
```

---

### Priority 2：丰富现有方向，增加策略深度

#### 4. Sic 'Em（Uncommon Attack, 1费）—— Osty→Soul（增强版）

| | 当前 | 新设计 |
|---|---|---|
| 原效果 | Osty 7伤，命中→Summon 2 | 不变 |
| 追加 | — | **Osty命中后抽1张牌**（Soul代表） |
| 升级 | Osty 9伤, Summon 3 | **+ 抽牌变为2张** |

> **设计理由**：Sic 'Em 让 Osty 攻击命中后产生 Soul 抽牌。"咬住敌人不放"→ 攻击带回灵魂能量。与 Bodyguard 形成 Osty→Soul 双通路：一个主动（Bodyguard）、一个条件触发（Sic 'Em）。

#### 5. Haunt（Uncommon Power, 1费）—— Soul→Doom（Soul→伤害→Doom）

| | 当前 | 新设计 |
|---|---|---|
| 原效果 | Soul→随机敌 8伤 | Soul→随机敌 8伤 |
| 追加 | — | **Soul伤害后施加1层Doom** |
| 升级 | — | Soul→**10伤**，**施加2层Doom** |

> **设计理由**：Haunt（纠缠）——灵魂持续纠缠敌人，每次伤害留下灾厄。和 SoulStorm 形成 Soul→Doom 双通路：一个爆发（SoulStorm）、一个持续（Haunt Power）。

#### 6. Scourge（Uncommon Attack, 1费）—— Doom→Osty/Soul

| | 当前 | 新设计 |
|---|---|---|
| 原效果 | 13 Doom + 抽1 | 13 Doom + 抽1 |
| 追加 | — | **若目标Doom ≥ 10，Summon 1** |
| 升级 | 16 Doom, 抽2 | 16 Doom, 抽2, **Summon 2** |

> **设计理由**：Scourge（鞭挞）——高 Doom 触发 Osty 召唤。"敌人已被灾厄标记足够深 → 召唤亡灵收割"。既是 Doom→Osty（Summon），也是条件触发增加策略性。

#### 7. Death's Door（Uncommon Skill, 1费）—— Doom→Osty

| | 当前 | 新设计 |
|---|---|---|
| 原效果 | 8 Block, Doom触发→×2次 | 8 Block, Doom→×2次(共24) |
| 追加 | — | **每次Doom触发格挡后，Summon 1** |
| 升级 | — | Block 8→**10**，触发×**3次** |

> **设计理由**：Death's Door（死亡之门）——Doom 触发格挡的同时唤醒 Osty。"每穿越一次死亡之门，亡灵之力就增强一分"。

#### 8. Dirge（Uncommon Skill, 1费）—— 双向 Osty↔Soul

| | 当前 | 新设计 |
|---|---|---|
| 原效果 | Summon + 加 Soul | **Summon 3 + 2 Soul**（数值提升） |
| 追加 | — | **若 Osty 存活：Soul +2（共4）** |
| 升级 | — | Summon 5, Soul 3（Osty存活→5） |

> **设计理由**：Dirge（挽歌）天生就是 Osty+Soul 双修卡。强化条件触发——Osty 存活时有更多 Soul，自然鼓励 Osty→Soul 玩法。

#### 9. Defile（Common Attack, 1费）—— Doom→Osty（低稀有度入门）

| | 当前 | 新设计 |
|---|---|---|
| 原效果 | 7 Doom（数值加强后）| 7 Doom |
| 追加 | — | **若敌HP ≤ 50%，召唤1** |
| 升级 | Doom→9 | Doom→9，**召唤2** |

> **设计理由**：Defile（玷污）是 Doom 流最基础的白卡。让新手在 Common 稀有度就能体验"Doom→Osty"交叉——敌人被灾厄削弱后，死灵法师召唤亡灵收割。低门槛入门。

#### 10. Seance（Rare Power, 0费）—— Soul→Osty

| | 当前 | 新设计 |
|---|---|---|
| 原效果 | 抽牌堆→Soul | 不变 |
| 追加 | — | **每回合打出≥3 Soul时：Summon 3** |
| 升级 | — | Summon→**5** |

> **设计理由**：Seance（降灵会）——大规模 Soul 产出后自动召唤 Osty。Soul 流的高潮回报——"灵魂汇聚于降灵会，唤醒最强大的亡灵"。

---

## 三、完整交叉矩阵（10张卡后）

| | → Osty | → Doom | → Soul |
|---|---|---|---|
| **Osty→** | — | **Calcify** 🆕 | Bodyguard ✅ |
| | | **Sic 'Em**（Osty命中→抽牌）| Dirge（条件Soul+）|
| **Doom→** | NegativePulse ✅ | — | **Countdown** 🆕 |
| | **Scourge** 🆕（条件Summon）| | |
| | **Death's Door** 🆕 | | |
| | **Defile** 🆕（入门）| | |
| **Soul→** | CaptureSpirit ✅ | **SoulStorm** 🆕 | — |
| | **Dirge**（Soul↔Summon）| **Haunt** 🆕（持续Doom）| |
| | **Seance** 🆕（Soul→Summon）| | |

**每个方向至少有2条通路**。所有新增卡都是 CustomCardModel。

---

## 四、稀有度分布

| 稀有度 | 已有交叉卡 | 新增 | 合计 |
|---|---|---|---|
| **Basic** | Bodyguard | — | 1 |
| **Common** | NegativePulse | Defile | 2 |
| **Uncommon** | CaptureSpirit | Calcify, Countdown, Sic 'Em, Haunt, Scourge, Death's Door, Dirge | 8 |
| **Rare** | Time's Up | SoulStorm, Seance | 3 |

**Common 有入门卡（Defile），Uncommon 是交叉主战场，Rare 是高潮回报。** 玩家从Act 1就能接触到交叉机制。

---

## 五、玩家体验弧线

### Act 1（入门）
- 起手牌组有 **Bodyguard**（Osty→Soul），开局就感受到交叉
- 大概率拿到 **Defile**（Common，Doom→Osty条件Summon）或 **NegativePulse**（Common，Doom→Osty），低门槛体验
- **Countdown**（Uncommon Power）可能遇到 → 决定走 Doom+Soul 混合

### Act 2（展开）
- Uncommon 交叉卡大量出现：**Calcify**（Osty→Doom）、**Scourge**（高Doom触发）、**Dirge**（Osty+Soul双修）
- **Sic 'Em**（Osty→抽牌）、**Death's Door**（Doom防御→Summon）
- 玩家开始主动选择"我要走 Osty+Doom 混合"还是"Osty+Soul 混合"

### Act 3（高潮）
- **SoulStorm**（Rare，Soul→Doom爆发）—— Soul积攒到Act 3释放
- **Seance**（Rare，Soul→Osty量产）—— 大规模Soul转Summon
- **Time's Up**（升级后AoE Doom伤害）—— Doom流派终结点

---

## 六、实施优先级

| 批次 | 卡牌 | 原因 |
|---|---|---|
| **B1（核心闭合）** | Calcify, Countdown, SoulStorm | 闭合3个缺失方向 |
| **B2（Osty线增强）** | Sic 'Em, Dirge | Osty→Soul第二通路 |
| **B3（Doom线增强）** | Scourge, Defile, Death's Door | Doom→Osty多通路 |
| **B4（Soul线增强）** | Haunt, Seance | Soul→Doom/Osty高潮 |
