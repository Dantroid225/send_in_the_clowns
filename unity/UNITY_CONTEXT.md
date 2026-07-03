# UNITY_CONTEXT.md — Send in the Clowns
# Purpose: Unity-specific cold-start context. Paste into Cursor/Claude Code when doing Unity work.
# Created: 2026-06-30 | Last Modified: 2026-07-01
# Status: ACTIVE — Unity project exists (Phase 0 build in progress).

---

## Current state (2026-07-01)
The `unity/unity_clowns/` project **exists** and Phase 0 build has begun.
- **Editor version (FROZEN):** **Unity 6000.3.17f1** — see DEC-2026-07-01-E.
- **Render pipeline:** URP 17.3.0.
- **Serialization:** Force Text + Visible Meta Files (URP template defaults; verified).
- **Key packages:** AI Navigation 2.0.12 (NavMesh), Input System 1.19.0, Test Framework 1.6.0,
  and **AnkleBreaker Unity MCP** (`com.anklebreaker.unity-mcp`, git URL in `manifest.json`).
  Bridge port: **7890** (auto-discovered — always use `unity_list_instances`, never hard-code).
- **Code root:** `Assets/_clowns/` with an asmdef split (`Clowns.Runtime`, `Clowns.Editor`,
  `Clowns.Tests.EditMode`). `Assets/_clowns/Net/` is a **reserved Phase-1 slot** (README only, no asmdef).

## ⚠ STANDING RULE — check the Unity MCP port EVERY session (ports can switch)
The CoplayDev MCP **auto-discovers** running Editors; the bridge port is **not** guaranteed to be
7890 and can change between sessions/instances. So, at the start of any Unity MCP work:
1. Call **`unity_list_instances`** first — never assume a port.
2. Call **`unity_select_instance`** with the discovered port.
3. Pass **`port: <number>`** on every subsequent `unity_*` call (parallel-safety).
4. If multiple instances are listed, **ask the user which** before proceeding.
5. NEVER call the HTTP bridge directly (`http://127.0.0.1:<port>/api/...`) — MCP tools only.
If `unity_list_instances` returns none, the Editor is closed — open the project, then retry.

## Assembly layout
```
Assets/_clowns/
  Runtime/  Clowns.Runtime.asmdef        (rootNamespace "Clowns"; no editor/test refs)
    Core/ Data/ Combat/ Clown/ Enemy/ Feedback/
  Editor/   Clowns.Editor.asmdef         (refs Clowns.Runtime; Editor-only)
  Tests/EditMode/ Clowns.Tests.EditMode.asmdef  (refs Clowns.Runtime + TestRunner; Editor-only)
  GameData/ (SO asset instances)   Scenes/ (ToyArena.unity)   Art/greybox/
  Net/      README.md only — RESERVED Phase 1 (Clowns.Net refs Runtime, never the reverse)
```

## Intended Unity setup
- **Architecture:** ScriptableObject-based (Ryan Hipple). Humor types, temperaments, and the
  affinity grid are **SO data** so the read is inspector-tunable — no enum branches, no hard-coding.
- **Networking:** FishNet, **Phase 1** (not Phase 0). Host/listen; **client-authoritative movement +
  `NetworkTransform`** (DEC-2026-06-29-B). No server authority.
- **Movement/pathfinding:** Unity NavMesh — owner runs its own clown's agent; host runs enemy agents.

## Invariants that bind Unity work (from ../_docs/TOOL_ROLES.md + CLAUDE.md)
1. Client-authoritative movement only — no server authority / Prediction V2. (DEC-B)
2. No written joke text in any asset, string, or SO — performed gibberish only. (DEC-C)
   → `ClownDataSO.DisplayName` is debug/UI only and must never read as comedy.
3. Humor-type / affinity SO data is authored data, not mutated at runtime.
4. The mirth meter value is written in exactly one authoritative place (once the meter exists, TB-03).
5. No humor type universally best; the matchup must stay a real, visible decision (Pillar 2) —
   enforced in-editor by **Clowns ▸ Validate Affinity Table**.
