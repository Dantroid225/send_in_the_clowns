# PHASE_PLAN.md — Send in the Clowns
# Purpose: Phase boundaries, deliverables, and exit criteria. The binding plan.
# Created: 2026-06-30 | Last Modified: 2026-06-30
# Status: ⚠ STUB — NOT YET GENERATED as a binding plan. Pending Phase 0 boundary confirm
#         from Mission Control (see PROJECT_STATUS.md blockers). Mission Control (claude.ai)
#         authors the real version; Claude Code only stubbed the slot.
# Related: PROJECT_STATUS.md, PILLARS.md, design/MIRTH_METER_SPEC.md, DECISIONS.md

---

## ⚠ This is a slot reservation, not the plan

The real PHASE_PLAN.md is authored by **Mission Control (claude.ai)** once the Phase 0 boundary
is confirmed. Until then, this stub records the *provisional* shape so the slot isn't improvised.

---

## Provisional shape (NOT binding)

### Phase 0 — Concept + solo combat toy (grey-box)
- **Goal:** Build the smallest playable thing that answers the one make-or-break question.
- **Scope:** 1 clown (player-piloted), 1 single arena, 1–2 enemy temperaments, a few humor types
  drawn from the humor agent's MVP subset, the mirth meter (`design/MIRTH_METER_SPEC.md`).
  **Solo only — no networking.**
- **Exit criterion (the gate):** **"Is the read fun?"** Does humor-type-vs-temperament create a
  real, satisfying decision, or does it collapse into a damage race? This is a USER-playtest gate —
  the corresponding Task Brief moves to `active/verification_pending/` until the user confirms.
- **If it fails:** the design pivots before a line of netcode is written.

### Phase 1 — Co-op (FishNet, 2-player)
- **Gated behind a passing Phase 0.**
- **Scope:** host/join (session code or direct IP), client-authoritative movement + `NetworkTransform`
  (DEC-2026-06-29-B), the SyncVar inventory for mirth/defeat state. **Authored in
  `architecture/PH1_NETWORKING_AND_COOP.md` at Phase 1 kickoff (currently a stub).**

### Phase 2+ — Backlog
- Roster expansion, the roguelite tour, the Gunfire-Reborn progression layer. See `BACKLOG.md`.
  None of this is designed until Phase 0 passes.

---

## To replace this stub, Mission Control should confirm:
1. The Phase 0 boundary (solo-first vs. some other cut).
2. How many humor types / enemy temperaments the MVP read needs (depends on `HUMOR_SYSTEM.md`).
3. The precise exit-criterion playtest protocol (what "the read is fun" looks like, measured how).
