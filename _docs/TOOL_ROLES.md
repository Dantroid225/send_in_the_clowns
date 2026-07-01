# TOOL_ROLES.md — Send in the Clowns
# Purpose: Locked duty split across the three tool surfaces, plus the load-bearing
#          invariants every surface must protect.
# Created: 2026-06-30 | Last Modified: 2026-06-30
# Related: CLAUDE.md (root), DECISIONS.md (DEC-2026-06-29-B/C), parent CLAUDE_PROJECT_RULES §9
# Status: STABLE
# Delta from parent doctrine: Clowns uses THREE surfaces, not Deep Tide's four (no separate
#         Blender surface at MVP — grey-box only). Claude Code CLI is added as a second
#         implementation surface per this project's explicit instruction (see §Why below).

---

## The three surfaces

| Surface | Role | Owns | Never does |
|---|---|---|---|
| **claude.ai Projects** (Mission Control) | Plans, locks pillars/decisions, authors Task Briefs, runs phase-gate reviews | `_docs/` content proposals, `DECISIONS.md` entries (drafted → user-locked), Task Brief authorship | Write files, run commands, issue any MCP call |
| **Claude Code CLI** | Implementation: code/file writes, scripts, doc audits, refactors, git ops, Task Brief execution that needs no live Editor control | `unity/unity_clowns/Assets/_clowns/` code, `_docs/` edits (proposed + change-synced with code), `.claude/` | Architecture / design / scope decisions; live Unity Editor manipulation |
| **Cursor + Unity MCP** | Live Unity Editor control: scene/prefab/component wiring, interactive Play Mode debugging | `.cursor/` config, real-time scene/asset/component operations | Planning, architecture decisions, Task Brief authorship |

> **No Blender surface at MVP.** Clowns is grey-box until the toy proves fun. Re-add a Blender/
> Claude-Desktop surface only when post-MVP 3D asset work actually starts (`blender/` is stubbed).

---

## Routing rule — Claude Code CLI vs Cursor

- Pure C# / script work, doc audits, refactors, git ops, no live-Editor verification needed → **Claude Code CLI**
- Anything requiring clicking through the Editor (GameObjects, prefabs, scenes, materials, components) → **Cursor + Unity MCP**
- **Ambiguous → escalate to claude.ai rather than guess.** Signal phrase: "This needs a decision from claude.ai — pausing here."

### Why Claude Code CLI is a surface here (delta from parent doctrine)
Parent CLAUDE_PROJECT_RULES §9 routes implementation only to Cursor. This project adds Claude Code
CLI as a second implementation surface per explicit instruction, mirroring the Deep Tide precedent.
**Flag to Workspace Infrastructure:** if Claude Code CLI becomes a standing surface across projects,
the workspace-level tool-architecture doc (and possibly CLAUDE_PROJECT_RULES §9) should be updated to
reflect a general-purpose fourth surface — out of scope for this repo.

---

## Load-bearing invariants (every surface must protect these)

These are the equivalent of Deep Tide's "server authority invariant" — promote any new one here
the moment the system it guards exists.

1. **Authority-model invariant (DEC-2026-06-29-B).** Movement is **client-authoritative + `NetworkTransform`**.
   No server-authoritative movement, no Prediction V2 / Replicate-Reconcile. Do not drift toward server
   authority mid-project. PvE + friends-only makes cheating a non-problem (Pillar 4).

2. **Gibberish-performance invariant (DEC-2026-06-29-C).** No real, written, or scripted joke/punchline
   text exists anywhere in code, assets, comments, or UI as the primary comedic payload. Humor type
   reads through cadence / animation / action / VFX / SFX only. This is a content-pipeline hard rule.

3. **The read is the toy (Pillar 2).** If any humor type beats everything, or matchup is invisible/
   irrelevant, the system collapses into a damage race and the toy fails. No feature may erase the read.

4. **Future invariants (reserve slots — fill when the system exists):**
   - "Humor-type SO data is never mutated at runtime." (once humor types are ScriptableObjects)
   - "The mirth meter value is written in one authoritative place." (once the meter exists; see
     `design/MIRTH_METER_SPEC.md` and `architecture/PH1_NETWORKING_AND_COOP.md`)
