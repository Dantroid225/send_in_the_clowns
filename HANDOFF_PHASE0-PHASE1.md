# HANDOFF_PHASE0-PHASE1.md — Send in the Clowns
# Purpose: Bootstrap execution report + the technical handoff that lets Phase 0
#          (solo combat toy) and Phase 1 (FishNet co-op) begin without re-deriving context.
# Created: 2026-06-30 | Author: Claude Code CLI (Implementation Agent)
# Related: _docs/PROJECT_STATUS.md, _docs/DECISIONS.md, _docs/architecture/PHASE_PLAN.md,
#          _docs/archive/CLOWNS_PROJECT_SCAFFOLDING_GUIDE.md (the brief this executes)

---

## Execution Report — CLOWNS_PROJECT_SCAFFOLDING_GUIDE.md §13
**Date:** 2026-06-30
**Status:** ✅ COMPLETE (repo scaffolding only — no game logic, no Unity project, per §13 step 12)
**Commit:** `fc173d1` — "Bootstrap: clowns repo structure + concept docs" (39 files, root commit on `main`)

### Files created (structure)
```
send_the_clowns/
├── README.md · PROJECT_CONTEXT.md · CLAUDE.md · HANDOFF_PHASE0-PHASE1.md
├── .gitignore · .gitattributes           (LFS declared for post-MVP binaries)
├── .claude/commands/                      (.gitkeep; settings.local.json stays local/ignored)
├── .cursor/rules/                         (.gitkeep)
├── _docs/
│   ├── INDEX.md · PROJECT_STATUS.md · DECISIONS.md · TOOL_ROLES.md · PROJECT_FILE_MAP.md
│   ├── PILLARS.md · ONE_PAGE_GDD.md        (migrated; ONE_PAGE_GDD was PROJECT_SUMMARY.md)
│   ├── BACKLOG.md · CUT.md · ICEBOX.md · DONE.md   (scope ledgers split from the GDD)
│   ├── design/MIRTH_METER_SPEC.md          (migrated)
│   ├── brainstorms/{CONCEPT_QUESTIONNAIRE, HUMOR_SYSTEM_BRIEF, HUMOR_TYPE_RESEARCH}.md (migrated)
│   ├── architecture/{PHASE_PLAN, PH1_NETWORKING_AND_COOP}.md   (STUB slots)
│   ├── references/ · sessions/             (.gitkeep — empty by design)
│   └── archive/{README, CLOWNS_PROJECT_SCAFFOLDING_GUIDE, HUMOR_SYSTEM_HANDOFF_PROMPT}.md
├── _task_briefs/active/{,verification_pending/,Handoff/} · complete/ · failed/   (.gitkeep)
├── blender/{exports,refs,sessions}/        (.gitkeep — post-MVP)
└── unity/UNITY_CONTEXT.md                  (STUB — no unity_clowns/ project yet, GATED)
```

### Commands run
- `git init -b main` → new repo (this folder is excluded from the workspace repo — `projects/` is gitignored). Pass.
- `git add -A` + `git commit` → root commit `fc173d1`, 39 files, 2573 insertions. Pass.

### Verification results (§13)
- [x] **INDEX.md lists every file present** — cross-checked; all 19 `_docs` markdown files (incl. `archive/README.md`) are referenced. No orphans, no dangling links (stub docs exist as real files). Pass.
- [x] **DECISIONS.md matches the scaffold** — DEC-A, DEC-B, DEC-C verbatim per §6; added DEC-D (folder-name ruling, see deviations). Pass.
- [x] **No `backend/`, `infra/`, or `.secrets/`** — directory scan confirms none exist (§1 ruling). Pass.
- [x] **No real Unity project initialized** — `unity/` contains only `UNITY_CONTEXT.md` (§13 step 12). Pass.

---

## Deviations from the brief (and why)

1. **Repo folder is `send_the_clowns`, not `clowns`.** The brief's §13 prerequisite named
   `D:\Deez_Projects\projects\games\clowns\`, but all concept docs already lived in
   `send_the_clowns\` and the user pointed Claude Code there. Scaffolded in place. Unity-internal
   canonical names are kept from the guide (`unity/unity_clowns/`, `Assets/_clowns/`) so parent
   CLAUDE_PROJECT_RULES §8.2 references still hold. Recorded as **DEC-2026-06-30-D**. *Cosmetic —
   confirm or rename at next Mission Control review; non-blocking.*

2. **Cut-list split reconciled by content, not by the brief's item numbers.** §8 referenced cut-list
   items by number, but those numbers didn't line up with the rev-1.2 GDD list (the brief flagged this
   itself). I split by **content**: CUT = PvP, MOBA economy, matchmaking/accounts/servers/anti-cheat,
   rules-editor, minimap/spectator/reconnect, and the permanent written-jokes cut; BACKLOG = roguelite
   tour, progression layer, large rosters, procedural/meta; ICEBOX = alt emotion-bar meter. Net scope
   is identical to the GDD — only the routing is now explicit.

3. **The GDD's cut-list section was converted to pointers** (not left duplicated). Per §8's single-
   source intent, `ONE_PAGE_GDD.md` now references CUT/BACKLOG/ICEBOX instead of embedding the list.
   No scope content was lost — it moved to the ledgers verbatim in spirit.

4. **Created real STUB files for `PHASE_PLAN.md` and `PH1_NETWORKING_AND_COOP.md`** rather than
   leaving them as dangling INDEX links. Each is clearly marked STUB/SLOT-RESERVED with the required
   outline and a "do not write early" banner. This satisfies both §11 (reserve the slot) and the
   no-broken-links verification.

5. **Added `_docs/archive/README.md`** as the deprecation-notice vehicle (§11 requires archived docs
   carry a note) without mutating the archived originals.

6. **Added DEC-D and `PROJECT_FILE_MAP.md`** (the latter is named in §2's layout; the brief's step list
   didn't call it out explicitly, but §2 lists it — created for completeness).

---

## Open blockers — still accurate for Mission Control to act on

These are unchanged from `_docs/PROJECT_STATUS.md`; repeated here so the handoff is self-contained:

1. **[BLOCKER] Phase 0 boundary unconfirmed (USER).** Mission Control recommends **solo-first**:
   build the combat toy solo, gate FishNet co-op behind a passing Phase 0. **Nothing in Phase 0 build
   should start until this is confirmed or overridden.** This gates `PHASE_PLAN.md` becoming binding
   and gates creating the Unity project.
2. **[BLOCKER] Humor-system agent's `HUMOR_SYSTEM.md` not delivered.** The playable MVP read needs at
   least a minimal humor-type subset from it. Brief is live at `_docs/brainstorms/HUMOR_SYSTEM_BRIEF.md`.
3. **[OPEN] 3-word target experience provisional** ("Read. Riff. Roar.") — lock via
   `_docs/brainstorms/CONCEPT_QUESTIONNAIRE.md` Q1.
4. **[OPEN] Unity LTS version not frozen** — workspace candidate is **Unity 6000.3.17f1**; confirm
   before creating the project (recorded in `unity/UNITY_CONTEXT.md`).
5. **[OPEN] GitHub repo name unconfirmed** — suggested `send-in-the-clowns`. No remote created.

---

## Phase 0 — start checklist (for whoever picks up the build)

**Prerequisite gate:** blockers #1, #2, #4 above must clear first.

1. **Mission Control (claude.ai):** replace the `PHASE_PLAN.md` stub with the binding plan —
   confirm the Phase 0 boundary, the humor-type/temperament count for the MVP read, and the exact
   exit-criterion playtest protocol ("is the read fun?", measured how).
2. **Freeze the Unity version** (confirm 6000.3.17f1 or choose) and **the repo name**; record both in
   `DECISIONS.md` + `unity/UNITY_CONTEXT.md`.
3. **Create the Unity project** (this is Cursor + Unity MCP work for scene/prefab wiring, and Claude
   Code for C#/SO scaffolding):
   - `unity/unity_clowns/` — Unity LTS + **URP**.
   - `Assets/_clowns/` code root; add subtree `unity/unity_clowns/CLAUDE.md` + `Assets/_clowns/_docs/ai/`.
   - The `.gitignore` already pre-ignores `unity/unity_clowns/{Library,Temp,Obj,Build,Logs,...}`.
4. **Build the toy (solo):** 1 player-piloted clown (click-to-move, Q/W/E/R abilities — LoL controls
   only), 1 arena, 1–2 enemy temperaments, a few humor types, and the **mirth meter** per
   `_docs/design/MIRTH_METER_SPEC.md`. **ScriptableObject-based:** abilities + humor types as SO data.
5. **Playtest against the exit criterion.** File the Task Brief under
   `_task_briefs/active/verification_pending/` until the USER confirms the read is fun. Move to
   `complete/` on pass, `failed/` (with notes) on fail — a fail pivots the design *before any netcode*.

### Phase 0 invariants to hold (enforced in CLAUDE.md §3)
- No HP/damage/gore framing — mirth meter fills, it doesn't deplete health (Pillar 1).
- No humor type universally best; matchup must be visible and matter (Pillar 2 — the toy's whole point).
- **No written joke text** in code/SO/asset/UI — performed gibberish only (DEC-C).
- Readable land/bomb feedback on every cast (Pillar 3).

## Phase 1 — readiness notes (do NOT start until Phase 0 passes)

- The networking reference slot is reserved: `_docs/architecture/PH1_NETWORKING_AND_COOP.md` (STUB).
  At Phase 1 kickoff, fill its sections: FishNet version + transport, the SyncVar inventory
  (mirth value, defeat state, per-clown mirrored state), ServerRpc/ObserversRpc for ability
  activation, host/join connection flow (session code or direct IP — **no matchmaking**), and
  late-join behavior.
- **Authority model is already decided — do not re-open it:** client-authoritative movement +
  `NetworkTransform`, no server authority / Prediction V2 (DEC-B). This is a load-bearing invariant.
- Owner runs its own clown's NavMesh agent; host runs enemy agents.
- Start the `_docs/sessions/` habit here: log networking bugs (desync, late-join, ownership) as
  immutable dated snapshots.

---

## Tooling reminders (from `_docs/TOOL_ROLES.md`)
- **claude.ai (Mission Control):** planning, locking decisions, authoring Task Briefs. Writes no files.
- **Claude Code CLI:** C#/script/file/doc/git work with no live-Editor need.
- **Cursor + Unity MCP:** live Editor / scene / prefab / Play Mode work.
- Ambiguous or design-shaped → escalate: *"This needs a decision from claude.ai — pausing here."*

## Cold-start pointers
`README.md` → orientation · `PROJECT_CONTEXT.md` → paste-in cold-start · `_docs/INDEX.md` → doc index ·
`_docs/PROJECT_STATUS.md` → live status · `CLAUDE.md` → the rules that bind implementation.
