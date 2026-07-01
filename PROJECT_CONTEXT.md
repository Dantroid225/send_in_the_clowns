# PROJECT_CONTEXT.md — Send in the Clowns
# Purpose: Cold-start context block. Paste this whole file into ANY tool (claude.ai,
#          Claude Code, Cursor) to bring it up to speed with zero prior memory.
# Created: 2026-06-30 | Last Modified: 2026-06-30
# Related: _docs/INDEX.md, _docs/PROJECT_STATUS.md, CLAUDE.md

---

## What this is
**Send in the Clowns** (working title; codename `clowns`, repo folder `send_the_clowns`) — a
top-down **co-op vs AI** arena game where players pilot clowns and "fight with comedy." Attacks are
jokes that fill an enemy's **mirth meter** (not an HP bar); each enemy has a **temperament**, each
joke a **humor type**, and the match between them is strong/weak/neutral. The fight is a live
**reading** exercise. Think *Battlerite* combat × a *Pokémon-style type read* × a *Gauntlet* co-op
horde loop. The MTG-color-wheel humor model and Gunfire-Reborn progression layer are **vision/backlog**.

## Phase & status
- **Phase 0 — Concept.** Docs scaffolded (2026-06-30). **No game logic. No Unity project yet.**
- The one make-or-break question Phase 0 exists to answer: **"Is the read fun?"** — does humor-type-
  vs-temperament create a real decision, or collapse into a damage race?
- Live status, next action, and blockers: **[_docs/PROJECT_STATUS.md](_docs/PROJECT_STATUS.md)**.

## The five pillars (feature gate)
1. Comedy Is Combat · 2. Read the Room · 3. The Bit Lands or Bombs · 4. Co-op Chaos, Not Competition
· 5. Every Clown's a Different Act. Details: [_docs/PILLARS.md](_docs/PILLARS.md).

## Locked decisions you must respect (do not re-litigate)
- **DEC-A:** 1 clown per player, Battlerite-style — no lanes/economy.
- **DEC-B:** Client-authoritative movement + `NetworkTransform`. **No server authority / Prediction V2.**
- **DEC-C:** All jokes are **performed gibberish** (Simlish/Undertale-bark). **No written joke text anywhere.**
Full ledger: [_docs/DECISIONS.md](_docs/DECISIONS.md).

## Hard scope boundaries
- **CUT (permanent):** PvP, MOBA economy, matchmaking/accounts/servers/anti-cheat, rules-editor,
  minimap/spectator/reconnect, **written jokes**. See [_docs/CUT.md](_docs/CUT.md).
- **BACKLOG:** roguelite tour, progression layer, large rosters, procedural/meta. [_docs/BACKLOG.md](_docs/BACKLOG.md).
- **ICEBOX:** alt "emotion bar" second meter. [_docs/ICEBOX.md](_docs/ICEBOX.md).
- **MVP roster:** 2 clown classes, 1–2 enemy temperaments, a few humor types.

## Tech (intended)
Unity LTS + URP · ScriptableObject-based (abilities/humor types as SO data) · FishNet Phase 1
(host/listen, client-auth) · Unity NavMesh (owner runs its own clown; host runs enemies). Grey-box art.

## Tool routing (who does what)
- **claude.ai (Mission Control):** plans, locks decisions, authors Task Briefs. Writes no files.
- **Claude Code CLI:** code/file writes, scripts, doc audits, git — no live Editor control.
- **Cursor + Unity MCP:** live Unity Editor / scene / prefab / Play Mode work.
- Ambiguous → escalate to claude.ai. Full split: [_docs/TOOL_ROLES.md](_docs/TOOL_ROLES.md).

## Open blockers (as of 2026-06-30)
1. Confirm Phase 0 boundary (solo-first recommended). 2. Humor-system agent's `HUMOR_SYSTEM.md` owed.
3. Lock 3-word target ("Read. Riff. Roar." provisional). 4. Freeze Unity LTS version + GitHub repo name.

## Environment
Windows 10 · PowerShell · path `D:\Deez_Projects\projects\games\send_the_clowns\` · GitHub user `Dantroid225`.
This repo is **excluded from the workspace git repo** (`projects/` is gitignored) — it is its own repo.
