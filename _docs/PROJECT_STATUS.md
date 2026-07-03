# PROJECT_STATUS.md — Send in the Clowns
# Purpose: Single source of truth for current phase, last action, next action, blockers.
# Created: 2026-06-30 | Last Modified: 2026-07-01
# Related: INDEX.md, DECISIONS.md, architecture/PHASE_PLAN.md (stub)
# Update rule (parent doctrine §11): update after EVERY session, even partial ones.

---

**Phase:** 0 — Concept + solo combat toy (grey-box build started) — 🟡 IN PROGRESS
**Last session:** 2026-07-01
**Last action:** Executed **TB-01** + **TB-02** in full. Unity project confirmed (AnkleBreaker Unity
MCP, port 7890, AI Navigation, URP 17.3.0, Unity 6000.3.17f1). Scaffold: `Assets/_clowns/` tree,
`Clowns.Runtime`/`Clowns.Editor`/`Clowns.Tests.EditMode` asmdefs, `Net/` slot, `ToyArena.unity`
(floor plane + baked NavMesh via NavMeshSurface). Data layer: ClownDataSO abstract base,
HumorTypeSO/TemperamentSO/AffinityGrade/AffinityResult/IAffinityTable/AffinityTableSO (O(1) lookup
cache), Pillar-2 `AffinityTableValidator` (menu **Clowns ▸ Validate Affinity Table**), EditMode tests.
GameData assets created: HT_Wit/Slapstick/Dark, TMP_Snob/Rowdy, AT_Toy (seeded 6-row grid). **All
TB-02 §8 verifications PASSED**: GetAffinity spot-check ✓, validator PASS on AT_Toy ✓, planted
Wit→Rowdy=Strong triggered both FAILs ✓, reverted to PASS ✓, 0 compile errors ✓. Both briefs moved to
`verification_pending/`. **Awaiting USER commit approval.**

**Next:**
1. **USER confirms** TB-01 + TB-02 verification checklist (see briefs in `verification_pending/`),
   then approve the two commits — Claude Code will stage and commit on your go-ahead.
2. Still open: lock `ONE_PAGE_GDD.md` (DRAFT rev 1.2); integrate `HUMOR_SYSTEM.md`; replace
   `PHASE_PLAN.md` stub; confirm GitHub repo name.
3. Proceed to TB-03 (mirth meter) once commits are done and USER confirms the data layer is good.

---

## Open questions / blockers (for Mission Control to act on)

- **[RESOLVED 2026-07-01] Phase 0 boundary — cleared by USER (DEC-2026-07-01-F).** Solo combat toy
  first; FishNet co-op is Phase 1. Unity build is unblocked.
- **[RESOLVED 2026-07-01] Unity LTS version — frozen at 6000.3.17f1 (DEC-2026-07-01-E).**
- **[BLOCKER] Humor-system agent — `HUMOR_SYSTEM.md` not yet delivered.** Brief is handed off
  (`brainstorms/HUMOR_SYSTEM_BRIEF.md`, ACTIVE HANDOFF). TB-02 seeded the affinity grid from
  HUMOR_SYSTEM §7 as tunable defaults, but the fuller read still depends on this deliverable.
- **[OPEN] 3-word target experience still provisional** — "Read. Riff. Roar." Lock via
  `brainstorms/CONCEPT_QUESTIONNAIRE.md` Q1.
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
