# HANDOFF_TB-02_data-layer-affinity.md
# Purpose: Summary handoff for TB-02 execution — what shipped, deviations, and what USER must verify.
# Created: 2026-07-02 | Author: Claude Code CLI (Implementation Agent)
# Related: ../verification_pending/TASK_BRIEF_2026-07-01_p0-02-data-layer-affinity.md,
#          ../../_docs/PROJECT_STATUS.md, ../../_docs/brainstorms/HUMOR_SYSTEM.md

---

## Execution Report — TASK_BRIEF_2026-07-01_p0-02-data-layer-affinity.md
**Date:** 2026-07-01 → committed 2026-07-02
**Status:** COMPLETE — awaiting USER playtest/verification sign-off
**Commit:** `8ebdff2` — "Phase 0 TB-01: URP project + _clowns scaffold + LFS" (combined with TB-01, see TB-01 handoff for why)

### Files created — Runtime (`Clowns.Data` namespace)
- `Assets/_clowns/Runtime/Data/ClownDataSO.cs` — abstract base holding `id` / `displayName` /
  `debugColor`, shared by `HumorTypeSO` and `TemperamentSO`. **Not in the brief's file list** —
  added because the brief specifies identical fields on both SOs; the base class removes the
  duplication and makes a third data kind (if one is ever needed) a one-line subclass.
- `HumorTypeSO.cs`, `TemperamentSO.cs` (+ nullable `SilhouetteProxyPrefab`, wired later in TB-06)
- `AffinityGrade.cs` — `enum { Weak, Neutral, Strong }`, ordered for numeric comparison
- `AffinityResult.cs` — `readonly struct { Grade, Multiplier }`, multiplier defaults to 1
- `IAffinityTable.cs` — **not in the brief's file list.** Extracted the `GetAffinity` contract into
  an interface so combat/feedback/AI code depends on the lookup shape, not the concrete SO — a
  test double or a future per-arena table can substitute without touching any caller.
- `AffinityTableSO.cs` — implements `IAffinityTable`; rebuilds an O(1) `Dictionary<(HumorTypeSO,
  TemperamentSO), AffinityResult>` cache from the authored row list on `OnEnable`/`OnValidate`;
  missing pair returns `Neutral x1` with a `Debug.LogWarning`, never throws

### Files created — Editor (`Clowns.EditorTools` namespace)
- `Assets/_clowns/Editor/AffinityTableValidator.cs` — menu item **Clowns ▸ Validate Affinity
  Table**. Two FAIL conditions per brief §7 (universal-answer, roster-dominance) plus a
  non-failing per-crowd best-answer report. See "Interpretation note" below.

### Files created — Tests (not in the brief; added as a co-op-forward addition)
- `Assets/_clowns/Tests/EditMode/Clowns.Tests.EditMode.asmdef` + `AffinityTableTests.cs` — builds
  SOs in memory (no asset dependency), so the core lookup contract is CI-verifiable without opening
  a scene. Covers: authored-grade lookup, unset-multiplier coercion to 1, missing-pair Neutral
  fallback, null-argument Neutral fallback (each with `LogAssert.Expect` for the warning).

### GameData assets created (via Unity MCP, `unity_execute_code` + `SerializedObject`)
- `HT_Wit` (id `wit`), `HT_Slapstick` (id `slapstick`), `HT_Dark` (id `dark`)
- `TMP_Snob` (id `snob`), `TMP_Rowdy` (id `rowdy`)
- `AT_Toy` — 6 authored rows per HUMOR_SYSTEM §7: Wit/Snob=Strong, Wit/Rowdy=Weak,
  Slapstick/Snob=Weak, Slapstick/Rowdy=Strong, Dark/Snob=Neutral, Dark/Rowdy=Strong
- `AT_Toy.notes.md` — the brief-required "NOT a locked decision" note, kept off the asset itself

### Verification — all TB-02 §8 items PASSED
Run live against the Unity Editor via MCP (`unity_execute_code` + `unity_execute_menu_item` +
`unity_console_log`), not simulated:
- [x] Three HumorType, two Temperament, one AffinityTable asset exist (confirmed via `AssetDatabase.LoadAssetAtPath`)
- [x] `GetAffinity(Wit, Snob) == Strong` — confirmed
- [x] `GetAffinity(Slapstick, Snob) == Weak` — confirmed
- [x] `GetAffinity(Dark, Rowdy) == Strong` — confirmed
- [x] Validator PASSES on `AT_Toy`, prints per-crowd report:
      `vs snob: best = Strong -> [wit]` · `vs rowdy: best = Strong -> [slapstick, dark]`
- [x] Deliberately setting Wit→Rowdy = Strong → validator **FAILs both checks**:
      universal-answer ("wit is Strong against EVERY temperament") AND roster-dominance
      ("wit is the best (>=) answer against every temperament") — then reverted, re-ran, PASS confirmed
- [x] 0 compilation errors (`unity_get_compilation_errors`)

### Interpretation note — validator FAIL-2 semantics (flagged, not silently resolved)
Brief §7 says: "FAIL if any humor type's grade is ≥ every other type's grade in *every* column
(strict dominance)." A literal per-cell reading of "strict dominance" would flag `Dark` in the
seeded `AT_Toy` grid, because Dark ties-or-beats Slapstick in every column it shares (Neutral≥Weak
vs Snob is false actually — check: Dark/Snob=Neutral vs Slapstick/Snob=Weak, Neutral>Weak; Dark/Rowdy=Strong
vs Slapstick/Rowdy=Strong, tied) — a strict per-type-pair reading is ambiguous with a 3-type roster.
I implemented what the brief's intent and its own worked example require: **roster dominance** — a
type must be `>=` **every other type** across **every column**, not just one other type — which is
what actually collapses the read into a non-decision (Pillar 2's real concern). This keeps `AT_Toy`
at PASS (matches the brief's stated expected outcome in §7) and still catches the planted
`Wit→Rowdy=Strong` case. **USER/Mission Control should confirm this reading is correct** before the
5×5 full wheel is authored, since dominance gets easier to trigger accidentally as columns grow.

### Notes / blockers for USER
- No blockers. TB-02 exit gate ("`GetAffinity` returns correct seeded grades; validator PASSES and
  catches a planted all-Strong row") is met and verified live, not just by static review.
- The seeded `AT_Toy` grid is explicitly **not locked** (per DECISIONS.md and `AT_Toy.notes.md`) —
  designer-tunable via inspector, re-validate after any edit.
- TB-03 (mirth meter) can now start: it consumes `IAffinityTable`/`AffinityResult` as a read-only
  input and owns "how much a grade fills the meter," which is explicitly out of TB-02's scope.
