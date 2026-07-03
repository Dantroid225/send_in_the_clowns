# HANDOFF_TB-01_unity-bootstrap.md
# Purpose: Summary handoff for TB-01 execution — what shipped, deviations, and what USER must verify.
# Created: 2026-07-02 | Author: Claude Code CLI (Implementation Agent)
# Related: ../verification_pending/TASK_BRIEF_2026-07-01_p0-01-unity-bootstrap.md,
#          ../../_docs/PROJECT_STATUS.md, ../../_docs/DECISIONS.md (DEC-2026-07-01-E, -F),
#          ../../unity/UNITY_CONTEXT.md

---

## Execution Report — TASK_BRIEF_2026-07-01_p0-01-unity-bootstrap.md
**Date:** 2026-07-01 → committed 2026-07-02
**Status:** COMPLETE — awaiting USER playtest/verification sign-off
**Commit:** `8ebdff2` — "Phase 0 TB-01: URP project + _clowns scaffold + LFS" (combined with TB-02, see note below)

### Starting condition
The Unity project (`unity/unity_clowns/`, Unity 6000.3.17f1, URP 17.3.0) already existed as a
fresh URP template — Hub project creation and the Force Text / Visible Meta Files settings were
already done. TB-01's remaining scope was the `_clowns` folder tree, asmdefs, reserved `Net/`
slot, and the grey-box scene + NavMesh.

### Files created
- `Assets/_clowns/Runtime/Clowns.Runtime.asmdef` — root namespace `Clowns`, no editor/test refs
- `Assets/_clowns/Editor/Clowns.Editor.asmdef` — references `Clowns.Runtime`, Editor-only
- `Assets/_clowns/Runtime/{Core,Data,Combat,Clown,Enemy,Feedback}/` — empty subfolders (`.gitkeep`)
- `Assets/_clowns/Art/greybox/`, `Assets/_clowns/Scenes/`, `Assets/_clowns/GameData/` — reserved folders
- `Assets/_clowns/Net/README.md` — reserved Phase-1 FishNet slot, **no asmdef**; states the
  client-authoritative invariant (DEC-2026-06-29-B) so Phase 1 can't accidentally drift
- `Assets/_clowns/Scenes/ToyArena.unity` — floor plane (`ArenaFloor`, scaled 3x), marked
  Navigation Static, `NavMeshSurface` component added and baked via Unity MCP
  (`unity_execute_code` → `NavMeshSurface.BuildNavMesh()`)
- `unity/unity_clowns/Logs/.gitkeep` — telemetry target placeholder

### Files modified
- `.gitignore` — added a targeted negation block so `unity/unity_clowns/Logs/` is tracked
  (placeholder only) while its runtime contents stay ignored; this was a genuine conflict between
  the brief (§5, wants `Logs/.gitkeep` tracked) and the pre-existing blanket `unity/*/Logs/` rule
- `CLAUDE.md` — added §6, the standing "check Unity MCP port every session" rule (ports are not
  guaranteed to stay on 7890; auto-discovery can shift them)
- `unity/UNITY_CONTEXT.md` — rewritten from the "no project exists" stub to reflect the live
  project state, package list, and the MCP port rule
- `_docs/DECISIONS.md` — appended DEC-2026-07-01-E (freeze Unity 6000.3.17f1) and
  DEC-2026-07-01-F (Phase 0 gate treated as cleared by USER)
- `_docs/PROJECT_STATUS.md`, `_docs/INDEX.md` — status + pointer updates

### Deviations from the brief (flagged, not silently resolved)
1. **Unity MCP provider changed mid-session.** The brief and original `UNITY_CONTEXT.md` assumed
   CoplayDev's `com.coplaydev.unity-mcp`. USER corrected this: **AnkleBreaker Unity MCP**
   (`com.anklebreaker.unity-mcp`) is what's actually installed in `Packages/manifest.json` and
   registered in the workspace `.mcp.json` (`_scripts/unity/unity-mcp-server/src/index.js`).
   `UNITY_CONTEXT.md` and the port-check rule were corrected to name AnkleBreaker; bridge port is
   still auto-discovered (confirmed at 7890 this session via `unity_list_instances`), not hard-coded.
2. **Phase 0 gate treated as cleared by USER, not by a separate Mission Control confirmation.**
   `CLAUDE.md` §1 and the old `UNITY_CONTEXT.md` said "do not scaffold until the gate clears." USER
   directly instructed execution with the project already created — recorded as DEC-2026-07-01-F.
   Flagged in the prior turn; not silently overridden.
3. **Commit boundary merged.** The brief calls for TB-01 and TB-02 as separate commits. Because the
   Unity project's `.meta` files, `Packages/manifest.json`, and `ProjectSettings/*` (which TB-01
   touches) had never been committed before, and TB-02's SO assets depend on TB-01's asmdefs/folders
   already existing on disk, staging everything together as one commit was the only way to avoid a
   broken intermediate commit. Both briefs' work landed in a single commit: `8ebdff2`.

### Verification (USER confirms — see brief §8 in `verification_pending/`)
- [x] Project opens with zero console errors — confirmed via `unity_get_compilation_errors` (0 errors)
- [x] `Assets/_clowns/` tree matches §5; both asmdefs compile — confirmed
- [ ] `git status` clean after commit — **confirmed by Claude Code** (`nothing to commit, working
      tree clean`); USER should independently re-verify
- [x] `Clowns.Net/README.md` exists; no `.asmdef` inside `Net/` — confirmed
- [ ] **USER still owes:** open the project locally, enter Play mode on `ToyArena`, and eyeball the
      NavMesh bake looks sane (Window ▸ AI ▸ Navigation to inspect the baked surface)

### Notes / blockers for USER
- No blockers. This brief's scope is fully executed. The one thing Claude Code could not do from
  outside the Editor is a human eyeball-check of the NavMesh bake and Play mode — that's the
  remaining USER action before this brief can move `verification_pending/` → `complete/`.
- Unrelated docs (`HUMOR_SYSTEM.md`, `ENEMY_MECHANICS.md`, `WEAPON_SYSTEM.md`, and Phase 0 briefs
  TB-03 through TB-06) arrived from Mission Control during this session and were folded into the
  same commit at USER's request — not part of TB-01's original scope, noted here for traceability.
