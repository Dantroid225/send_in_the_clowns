# UNITY_CONTEXT.md — Send in the Clowns
# Purpose: Unity-specific cold-start context. Paste into Cursor/Claude Code when doing Unity work.
# Created: 2026-06-30 | Last Modified: 2026-06-30
# Status: ⚠ STUB — NO UNITY PROJECT EXISTS YET. Creating it is Phase 0 build work, GATED
#         on the Phase 0 boundary confirmation owed from Mission Control
#         (see ../_docs/PROJECT_STATUS.md blockers). Do NOT `unity_*` / init a project until then.

---

## Current state
There is **no `unity_clowns/` project**. This folder holds only this stub. The scaffolding brief
(archived at `../_docs/archive/CLOWNS_PROJECT_SCAFFOLDING_GUIDE.md` §13 step 12) explicitly gates
project creation behind the Phase 0 boundary decision.

## When Phase 0 build is approved — create the project as:
```
unity/
└── unity_clowns/                 ← Unity LTS + URP project root (canonical path)
    ├── CLAUDE.md                 ← Unity-subtree Claude Code rules (netcode + org invariants)
    └── Assets/
        └── _clowns/              ← game-specific code root (parent CLAUDE_PROJECT_RULES §8.2)
            └── _docs/
                └── ai/           ← Unity AI conventions (csharp, netcode, org)
```

## Intended Unity setup (confirm before creating)
- **Editor version to freeze:** **Unity 6000.3.17f1** is the workspace-installed candidate — **CONFIRM
  as the frozen LTS version before creating the project.** Record the final choice here + in DECISIONS.md.
- **Render pipeline:** URP (2D / low-poly stylized 3D; grey-box until the toy proves fun).
- **Architecture:** ScriptableObject-based (Ryan Hipple). Abilities, humor types/sub-types, and
  per-type mechanics as **SO data** so the affinities are inspector-tunable.
- **Networking:** FishNet, **Phase 1** (not Phase 0). Host/listen server; **client-authoritative
  movement + `NetworkTransform`** (DEC-2026-06-29-B). No server authority.
- **Movement/pathfinding:** Unity NavMesh — owner runs its own clown's agent; host runs enemy agents.

## Invariants that bind Unity work (from ../_docs/TOOL_ROLES.md + CLAUDE.md)
1. Client-authoritative movement only — no server authority / Prediction V2. (DEC-B)
2. No written joke text in any asset, string, or SO — performed gibberish only. (DEC-C)
3. Humor-type SO data is never mutated at runtime (reserve this invariant; enforce once SOs exist).
4. The mirth meter value is written in exactly one authoritative place (once the meter exists).

## Unity MCP note
Live Editor work routes through **Cursor + Unity MCP** (bridge port 7890). Claude Code CLI handles
batch C#/script/file/git work. See ../_docs/TOOL_ROLES.md for the routing rule.
