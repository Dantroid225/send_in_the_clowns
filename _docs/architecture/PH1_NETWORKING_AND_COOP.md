# PH1_NETWORKING_AND_COOP.md — Send in the Clowns
# Purpose: Binding networking + co-op reference for Phase 1. The pattern that Phase 1
#          implements, the SyncVar inventory, the connection flow, and the invariants.
# Created: 2026-06-30 | Last Modified: 2026-06-30
# Status: ⚠ STUB — SLOT RESERVED. Do NOT write FishNet specifics until Phase 1 kickoff.
#         There is no Phase 1 implementation to document yet. This skeleton exists so
#         Phase 1 doesn't improvise the pattern. Naming mirrors Deep Tide's
#         PH1_NETWORKING_AND_MULTIPLAYER.md.
# Related: DECISIONS.md (DEC-2026-06-29-B), TOOL_ROLES.md (invariants), design/MIRTH_METER_SPEC.md
# Gate: Phase 1 is gated behind a PASSING Phase 0 (see PHASE_PLAN.md). Do not start this doc early.

---

## ⚠ Write this at Phase 1 kickoff — not before

The sections below are the required outline. Each is a placeholder to be filled when Phase 1
actually starts. Confirm every FishNet/transport detail against the **current FishNet docs at
implementation time** (versions drift).

---

## 1. FishNet version + transport (FILL AT PHASE 1)
- [ ] FishNet version pinned: `____`
- [ ] Transport choice: `____` (Tugboat/direct, etc.) + why.

## 2. Authority model (DECIDED — DEC-2026-06-29-B)
- **Client-authoritative movement + `NetworkTransform`.** State it explicitly so it is not
  accidentally drifted toward server authority or Prediction V2 mid-project.
- Owner runs **its own clown's** NavMesh agent. Host runs **enemy** agents.
- Rationale: PvE + friends-only → cheating is a non-problem (Pillar 4). No server-authority spend.

## 3. SyncVar inventory (FILL AT PHASE 1 — same table format as Deep Tide §1.2)
| State | Type | Synced from | Notes |
|---|---|---|---|
| mirth meter value | `____` | host/authoritative writer | see MIRTH_METER_SPEC.md |
| defeat state ("in stitches") | `____` | ____ | per-enemy |
| per-clown state mirrored to both clients | `____` | ____ | ____ |

## 4. RPC usage (FILL AT PHASE 1)
- ServerRpc / ObserversRpc for ability activation, crossing the network boundary
  (per `MIRTH_METER_SPEC.md` §4 `GetAffinity` contract). Document each RPC + direction.

## 5. Connection flow (FILL AT PHASE 1)
- Host / join: session code OR direct IP (2-player MVP — **no matchmaking**, per CUT.md C-3).
- Late-join behavior: likely simpler than Deep Tide (MVP probably not designed around mid-run
  joins — confirm against `brainstorms/CONCEPT_QUESTIONNAIRE.md` §6 once answered).

## 6. Load-bearing invariants ("must not break") (FILL AS SYSTEMS LAND)
Mirror TOOL_ROLES.md and Deep Tide §5. Seed entries:
- [ ] Humor-type SO data is never mutated at runtime.
- [ ] The mirth meter value is written in exactly one authoritative place.
- [ ] Movement stays client-authoritative (no server-authority creep).
- [ ] No written joke text crosses the wire (gibberish-performance invariant, DEC-2026-06-29-C).
