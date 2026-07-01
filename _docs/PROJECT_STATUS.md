# PROJECT_STATUS.md — Send in the Clowns
# Purpose: Single source of truth for current phase, last action, next action, blockers.
# Created: 2026-06-30 | Last Modified: 2026-06-30
# Related: INDEX.md, DECISIONS.md, architecture/PHASE_PLAN.md (stub)
# Update rule (parent doctrine §11): update after EVERY session, even partial ones.

---

**Phase:** 0 — Concept (pre-Phase-0-build) — 🟡 IN PROGRESS
**Last session:** 2026-06-30
**Last action:** Repo scaffolded from `CLOWNS_PROJECT_SCAFFOLDING_GUIDE.md` — directory
tree, foundational docs, scope ledgers, tool roles, and stub slots created; the six
drafted concept docs migrated into `_docs/`; `git init` + initial commit. No game
logic and no real Unity project created (gated — see blockers).

**Next:**
1. **Confirm Phase 0 boundary** (solo combat toy first, FishNet co-op in Phase 1) — **OWED from Mission Control.**
2. Reconfirm/lock `PILLARS.md` (rev 1) and lock `ONE_PAGE_GDD.md` (currently DRAFT rev 1.2).
3. Integrate humor-system agent's `HUMOR_SYSTEM.md` once delivered → promote to `_docs/design/HUMOR_SYSTEM.md`, fold decisions into `DECISIONS.md`.
4. Generate `_docs/architecture/PHASE_PLAN.md` (replace stub) once the Phase 0 boundary is confirmed.
5. Confirm Unity LTS version to freeze and GitHub repo name before any Phase 0 build work.

---

## Open questions / blockers (for Mission Control to act on)

- **[BLOCKER] USER — Phase 0 boundary unconfirmed.** Mission Control recommends solo-first
  (build the combat toy solo; gate FishNet co-op behind a passing Phase 0). Confirm or override.
- **[BLOCKER] Humor-system agent — `HUMOR_SYSTEM.md` not yet delivered.** Brief is handed off
  (`brainstorms/HUMOR_SYSTEM_BRIEF.md`, ACTIVE HANDOFF). Phase 0's playable read depends on at
  least a minimal subset from this deliverable.
- **[OPEN] 3-word target experience still provisional** — "Read. Riff. Roar." Lock via
  `brainstorms/CONCEPT_QUESTIONNAIRE.md` Q1.
- **[OPEN] Unity LTS version not frozen.** Workspace default is Unity 6000.3.17f1 (candidate);
  confirm before Phase 0 build. Recorded in `unity/UNITY_CONTEXT.md`.
- **[OPEN] GitHub repo name unconfirmed.** Suggested `send-in-the-clowns`. No remote created yet.
- **[OPEN] Repo folder vs. codename mismatch.** Repo folder is `send_the_clowns`; guide/docs use
  codename `clowns` and Unity canonical paths `unity_clowns/` + `Assets/_clowns/`. Resolved in
  favor of: keep folder `send_the_clowns`, keep Unity canonical `_clowns` naming. Note only — not a blocker.

---

## Phase ledger (one line per phase; detail lives in PHASE_PLAN.md once generated)

| Phase | Name | Status | Exit criterion |
|---|---|---|---|
| 0 | Concept + solo combat toy (grey-box) | 🟡 In progress (docs done; build gated) | **"Is the read fun?"** — humor-type-vs-temperament is a real decision, not a damage race. |
| 1 | Co-op (FishNet, 2-player host/join) | ⬜ Not started | Two friends play the toy together; client-auth movement + NetworkTransform works. |
| 2+ | Backlog (roster, tour, progression) | ⬜ Parked | See BACKLOG.md — gated on Phase 0 passing. |
