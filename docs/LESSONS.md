# STS2 Mod 开发经验积累

> 记录 NecrobinderRework 开发过程中踩过的坑和学到的经验。

---

## 1. 项目搭建

### .csproj 配置
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <LangVersion>12</LangVersion>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
  <!-- 引用游戏自带 DLL -->
  <Reference Include="sts2" HintPath="$(Sts2DataDir)\sts2.dll" Private="false" />
  <Reference Include="0Harmony" HintPath="$(Sts2DataDir)\0Harmony.dll" Private="false" />
  <!-- 自动部署 Target -->
  <Target Name="DeployToGame" AfterTargets="Build">
    <Copy SourceFiles="$(TargetPath)" DestinationFolder="$(Sts2Dir)\Mods\$(AssemblyName)" />
  </Target>
</Project>
```

### Mod 入口
```csharp
[ModInitializer("Initialize")]
public static class ModEntry
{
    public static void Initialize()
    {
        var harmony = new Harmony("com.example.mod");
        harmony.PatchAll(typeof(ModEntry).Assembly);
    }
}
```

### 部署结构
```
<游戏>\Mods\<ModName>\
    mod_manifest.json    ← 必须
    <ModName>.dll        ← 编译产物
    mod_image.png        ← 可选图标
```

---

## 2. Harmony Patch 核心规则

### 关键区分：方法是否被重写

| 情况 | Patch 目标 | 写法 |
|---|---|---|
| 在派生类中**重写**了 | `typeof(派生类)` | `Prefix` 返回 false 或 `Postfix` |
| 在派生类中**未重写**（继承自基类） | `typeof(CardModel)` | `Postfix` + `if (__instance is 派生类)` |

### 示例对比

```csharp
// ✅ 正确：方法在 CardModel 基类定义，卡牌未重写
[HarmonyPatch(typeof(CardModel), "get_DynamicVars")]
public static void Postfix(CardModel __instance, DynamicVarSet __result)
{
    if (__instance is Bodyguard)
        __result.Summon.UpgradeValueBy(2m);
}

// ❌ 错误：方法不在派生类上
[HarmonyPatch(typeof(Bodyguard), "get_DynamicVars")]
// → "Undefined target method"
```

```csharp
// ✅ 正确：get_StartingHp 在 Necrobinder 类上重写了
[HarmonyPatch(typeof(Necrobinder), nameof(Necrobinder.StartingHp), MethodType.Getter)]
public static void Postfix(ref int __result) => __result = 72;

// ✅ 正确：OnUpgrade 在 Wisp 类上重写了
[HarmonyPatch(typeof(Wisp), "OnUpgrade")]
public static void Postfix(Wisp __instance) { ... }
```

---

## 3. 修改卡牌数值

### ⚠️ 致命陷阱：get_CanonicalVars vs get_DynamicVars

```csharp
// ❌ 错误：Patch get_DynamicVars 会导致数值叠加爆炸
// get_DynamicVars 被反复调用，每次 Postfix 都会执行 UpgradeValueBy
// 结果：5 → 7 → 9 → 11 → ... (无限叠加)
[HarmonyPatch(typeof(CardModel), "get_DynamicVars")]
public static void Postfix(DynamicVarSet __result) {
    __result.Block.UpgradeValueBy(2m);  // 每次 +2，疯狂叠加！
}

// ✅ 正确：Patch get_CanonicalVars + 用 SetBase（幂等）
// get_CanonicalVars 每次重新计算，不会叠加
// SetBase 是幂等的：target - current = 差值，已达目标则差值为 0
[HarmonyPatch(typeof(Bodyguard), nameof(Bodyguard.CanonicalVars), MethodType.Getter)]
public static void Postfix(IEnumerable<DynamicVar> __result) {
    CardVarHelper.SetBase(__result, "Summon", 7);  // 5→7，只执行一次
}
```

| 方法 | 重写位置 | 返回类型 | 调用频率 | 适合 |
|---|---|---|---|---|
| `get_CanonicalVars()` | ✅ 每张卡重写 | `IEnumerable<DynamicVar>` | 低（创建时） | **修改数值** |
| `get_DynamicVars()` | ❌ 基类 CardModel | `DynamicVarSet` | 高（每次访问） | 不要 Patch |

### SetBase 为何安全
```csharp
dv.UpgradeValueBy(target - dv.BaseValue);  // 差值 = 目标 - 当前
// 首次：dv.BaseValue=5, target=7 → UpgradeValueBy(2) → BaseValue=7 ✓
// 再次：dv.BaseValue=7, target=7 → UpgradeValueBy(0) → BaseValue=7 ✓
// 幂等！永远不会叠加。
```

### 数据模型
```
CardModel
  └── DynamicVarSet _dynamicVars       ← 运行时变量集
       └── Dictionary<string, DynamicVar> _vars
            ├── Block (BlockVar)       ← 类型化访问器
            ├── Damage (DamageVar)
            ├── Summon (SummonVar)
            ├── OstyDamage (OstyDamageVar)
            ├── Heal (HealVar)
            ├── CalculationBase (CalculationBaseVar)
            ├── ExtraDamage (ExtraDamageVar)
            ├── Cards (CardsVar)
            └── ... (Doom, Weak, Energy, Repeat 等)
```

### 修改方式

```csharp
// 方式1：类型化访问器（有对应 DynamicVarSet 属性时）
__result.Block.UpgradeValueBy(2m);      // Block +2
__result.Summon.UpgradeValueBy(2m);     // Summon +2

// 方式2：字符串查找（Power 类变量无类型化访问器时）
CardVarHelper.SetBase(__result, "Calcify", 6);
CardVarHelper.SetBase(__result, "Countdown", 9);
```

### DynamicVarSet 类型化访问器完整列表
```
Block, Damage, Summon, OstyDamage, Heal, Energy, Cards,
Doom, Weak, Vulnerable, Strength, Dexterity, Poison,
CalculationBase, CalculationExtra, ExtraDamage, Repeat,
Forge, Gold, HpLoss, MaxHp, Stars, CalculatedBlock, CalculatedDamage
```

---

## 4. 创建卡牌实例

```csharp
// ❌ 错误：不能直接用 new
new Bodyguard();  // → "Don't call constructors on models! Use ModelDb instead."

// ✅ 正确：使用 ModelDb
ModelDb.Card<Bodyguard>();
```

**原因**：游戏使用单例/享元模式管理卡牌模型，每张卡只有一个规范化实例。

---

## 5. 日志与调试

### 日志位置
```
%APPDATA%\SlayTheSpire2\logs\godot<timestamp>.log
```

### 日志 API
```csharp
using MegaCrit.Sts2.Core.Logging;

Log.Debug("message");   // 调试信息
Log.Warn("message");    // 警告
Log.Error("message");   // 错误（会显示堆栈）
```

### ❌ Console.WriteLine 在 Godot 环境中不生效

### 逐个补丁注册 + 错误处理
```csharp
foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
{
    if (type.GetCustomAttribute<HarmonyPatch>() == null) continue;
    try
    {
        harmony.CreateClassProcessor(type).Patch();
        Log.Debug($"[Mod] OK: {type.Name}");
    }
    catch (Exception ex)
    {
        Log.Error($"[Mod] FAIL: {type.Name}: {ex.InnerException?.Message}");
    }
}
```

---

## 6. Osty 相关机制

### Osty HP 控制链路
```
BoundPhylactery.AfterEnergyResetLate()  ← 每回合触发
    → SummonPet()
        → OstyCmd.Summon(amount)        ← amount 决定 Osty HP
```

### 修改方式
```csharp
// 直接 Patch OstyCmd.Summon 的 amount 参数
[HarmonyPatch(typeof(OstyCmd), "Summon")]
public static void Prefix(ref decimal amount)
{
    amount *= 2; // Osty HP 翻倍
}
```

### ⚠️ 不要 Patch Osty.MinInitialHp/MaxInitialHp
这些是 Osty **作为怪物出现**时的属性，不影响玩家 Osty。

---

## 7. 卡牌数据来源

### 最佳来源：Spire Codex
```
https://github.com/ptrlrd/spire-codex
data/cards.json        ← 所有卡牌完整数据（从 sts2.dll 反编译提取）
data/relics.json       ← 遗物数据
data/characters.json   ← 角色数据
```

每个卡牌包含：id, name, cost, type, rarity, damage, block, vars, upgrade, keywords, description

### PCK 文件
- 卡牌**数值**存储在 C# DLL IL 字节码中，PCK 无法直接提取
- PCK 包含：动画资源、贴图、本地化文本、Godot 场景文件

---

## 8. 常见错误

| 错误信息 | 原因 | 解决 |
|---|---|---|
| `Undefined target method` | 方法不在 Patch 目标类型上 | 检查方法是重写还是继承，改 Patch 基类 |
| `Don't call constructors on models` | 直接 `new` 卡牌 | 用 `ModelDb.Card<T>()` |
| `模组检测到错误dll初始化失败` | Patch 失败导致初始化异常 | 用逐个注册 + 错误日志定位 |
| `Console.WriteLine` 无输出 | Godot 不用标准 Console | 用 `Log.Debug/Error` |
| ⚠️ **卡牌数值爆炸叠加** | `UpgradeValueBy` 在 `get_DynamicVars` 上被反复调用 | 必须 Patch `get_CanonicalVars` + 用 `SetBase`（幂等） |

---

## 9. 测试模式

```csharp
// Patch 起始牌组注入测试卡
[HarmonyPatch(typeof(Necrobinder), "get_StartingDeck")]
public static class TestModePatch
{
    public static bool Enabled = true; // ← 开关

    public static void Postfix(ref IEnumerable<CardModel> __result)
    {
        if (!Enabled) return;
        __result = new List<CardModel>
        {
            ModelDb.Card<Bodyguard>(),
            ModelDb.Card<Fetch>(),
            // ... 所有要测试的卡
        };
    }
}
```

---

## 10. 参考项目

| 项目 | 用途 |
|---|---|
| [zhc-0325/sts2-proregent](https://github.com/zhc-0325/sts2-proregent) | Regent 加强 mod，展示正确项目结构 |
| [jiegec/STS2RevertAnthony](https://github.com/jiegec/STS2RevertAnthony) | 卡牌版本切换 mod，展示完整 Patch 模式 |
| [ptrlrd/spire-codex](https://github.com/ptrlrd/spire-codex) | 卡牌数据库（从 DLL 反编译提取） |
| [fresh-milkshake/Modding-Tutorial](https://github.com/fresh-milkshake/Modding-Tutorial) | STS2 modding 教程 |
