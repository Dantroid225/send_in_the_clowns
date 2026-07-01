# Send in the Clowns

> *A top-down co-op arena where you and friends each pilot a clown and **fight with comedy** —
> performing jokes (in videogame gibberish, not real jokes) to fill an enemy's **mirth meter**
> until they're laughing themselves silly, reading each foe's temperament to pick the humor that lands.*

**Working title** — rename freely. **Folder codename:** `clowns`. **Repo folder:** `send_the_clowns`.
**Phase:** 0 — Concept (solo grey-box combat toy not yet built).
**Status:** Greenfield. Reuses the Cabal/Deep Tide *document scaffold*, not their design or tech weight.

---

## The one-liner elevator

*Battlerite's* arena combat × a **humor "type chart"** (a Magic-color-wheel of comedy), played
**co-op vs the AI** — with a *Gunfire Reborn*-style per-run class/skill layer as the eventual
roguelite (backlogged). You win a fight by **breaking the room**, not drawing blood.

## The five pillars (gate for every feature)

1. **Comedy Is Combat** — weapons are jokes; you win by cracking the room up, not hurting it.
2. **Read the Room** — humor type vs. audience temperament is the central mind-game.
3. **The Bit Lands or Bombs** — timing + feedback make a joke *hit*, communicated through
   **performance** (cadence/animation/action/VFX/SFX), never written text.
4. **Co-op Chaos, Not Competition** — friends vs. the crowd; cheating and balance are non-problems.
5. **Every Clown's a Different Act** — each class is a distinct comedic voice, not a stat reskin.

Full definitions + violation examples: [_docs/PILLARS.md](_docs/PILLARS.md).

## Two load-bearing constraints

- **Gibberish, not real jokes.** All in-game humor is *performed* videogame gibberish (Simlish /
  Undertale-bark style). No written punchlines anywhere. (DEC-2026-06-29-C.)
- **Client-authoritative co-op.** PvE + friends-only → no server authority, no anti-cheat spend.
  Movement is client-authoritative + `NetworkTransform`. (DEC-2026-06-29-B.)

---

## Where to start reading

| You want… | Go to |
|---|---|
| A one-screen orientation | **[_docs/INDEX.md](_docs/INDEX.md)** ← START HERE |
| Cold-start context to paste into any tool | [PROJECT_CONTEXT.md](PROJECT_CONTEXT.md) |
| Current phase / next action / blockers | [_docs/PROJECT_STATUS.md](_docs/PROJECT_STATUS.md) |
| The concept (one-page GDD) | [_docs/ONE_PAGE_GDD.md](_docs/ONE_PAGE_GDD.md) |
| The core combat model (the toy) | [_docs/design/MIRTH_METER_SPEC.md](_docs/design/MIRTH_METER_SPEC.md) |
| Locked decisions | [_docs/DECISIONS.md](_docs/DECISIONS.md) |
| What's cut / parked / iceboxed | [_docs/CUT.md](_docs/CUT.md) · [_docs/BACKLOG.md](_docs/BACKLOG.md) · [_docs/ICEBOX.md](_docs/ICEBOX.md) |
| Who does what across tools | [_docs/TOOL_ROLES.md](_docs/TOOL_ROLES.md) |
| The bootstrap → Phase 0/1 handoff | [HANDOFF_PHASE0-PHASE1.md](HANDOFF_PHASE0-PHASE1.md) |

## Tech (intended, not yet built)

Unity LTS + URP · ScriptableObject architecture (Ryan Hipple) · FishNet (Phase 1, host/listen,
client-auth movement) · Unity NavMesh. Grey-box until the toy proves fun.

## Current open blockers

See [_docs/PROJECT_STATUS.md](_docs/PROJECT_STATUS.md) — chiefly: (1) confirm the Phase 0 boundary,
(2) humor-system agent's `HUMOR_SYSTEM.md` delivery, (3) lock the 3-word target experience, and
(4) freeze the Unity LTS version + GitHub repo name before Phase 0 build.
