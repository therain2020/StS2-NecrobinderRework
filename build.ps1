# Necrobinder Rework — 构建 & 部署脚本
param(
    [switch]$Release,        # Release 模式构建
    [switch]$NoDeploy,       # 只构建不部署
    [switch]$Clean           # 清理构建产物
)

$ErrorActionPreference = "Stop"
$projectDir = $PSScriptRoot
$gameModsDir = "D:\STAEAM\steamapps\common\Slay the Spire 2\Mods\NecrobinderRework"
$buildConfig = if ($Release) { "Release" } else { "Debug" }

Write-Output "=== Necrobinder Rework Build Script ==="
Write-Output "Config: $buildConfig"

if ($Clean) {
    Write-Output "Cleaning..."
    Remove-Item -Recurse -Force "$projectDir\bin" -ErrorAction SilentlyContinue
    Remove-Item -Recurse -Force "$projectDir\obj" -ErrorAction SilentlyContinue
    Remove-Item -Recurse -Force "$projectDir\build" -ErrorAction SilentlyContinue
    Write-Output "Clean done."
}

# Step 1: Build
Write-Output "Building..."
Set-Location $projectDir
dotnet build -c $buildConfig
if ($LASTEXITCODE -ne 0) { throw "Build failed!" }

# Step 2: Copy to build output
$dllSource = "$projectDir\bin\$buildConfig\net9.0\NecrobinderRework.dll"
$buildOut = "$projectDir\build"
New-Item -ItemType Directory -Force -Path $buildOut | Out-Null
Copy-Item -Force $dllSource "$buildOut\NecrobinderRework.dll"
Write-Output "DLL copied to build\"

# Step 3: Copy manifest
Copy-Item -Force "$projectDir\godot\mod_manifest.json" "$buildOut\mod_manifest.json"

# Step 4: Deploy to game
if (-not $NoDeploy) {
    New-Item -ItemType Directory -Force -Path $gameModsDir | Out-Null
    Copy-Item -Force "$buildOut\NecrobinderRework.dll" "$gameModsDir\NecrobinderRework.dll"
    Copy-Item -Force "$buildOut\mod_manifest.json" "$gameModsDir\mod_manifest.json"
    Write-Output "Deployed to: $gameModsDir"
}

Write-Output "=== Build Complete ==="
