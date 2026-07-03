# PHASE 0 TASK BRIEF BATCH — Send in the Clowns
# Codename: clowns | Generated: 2026-07-01 | By: technical_designer_agent (Mission Control)
# Goal: build the SOLO combat toy as a vertical slice that answers ONE question —
#       "is the humor-type READ a fun decision?" — while locking ZERO open design
#       choice and leaving clean seams for co-op (Phase 1) to slot in later.
#
# Format note: each brief conforms to the intent of CLAUDE_PROJECT_RULES.md §7.2
# (unambiguous / complete / ordered / recoverable). Reconcile field names against
# §7.2 if the parent template differs; the section content is what matters.

---

## The batch, in dependency order

| # | Brief | Route | Answers / builds | Depends on |
|---|---|---|---|---|
| TB-01 | `p0-01-unity-bootstrap` | Hub + Claude Code CLI | URP project, `Assets/_clowns/` tree, asmdefs, git+LFS, non-negotiables | — (one env confirm) |
| TB-02 | `p0-02-data-layer-affinity` | Claude Code CLI | `HumorTypeSO`, `TemperamentSO`, `AffinityTableSO` + `GetAffinity` interface + Pillar-2 validator | TB-01 |
| TB-03 | `p0-03-mirth-meter` | Claude Code CLI + Cursor | Enemy-side shared mirth accumulator; affinity/bombing/decay as **config toggles** | TB-02 |
| TB-04 | `p0-04-clown-controller` | Cursor + Claude Code CLI | Click-to-move, auto-attack + 2 `JokeSO` abilities, casts as **events** | TB-03 |
| TB-05 | `p0-05-performance-feedback` | Cursor + Claude Code CLI | Text-free land/bomb grey-box feedback driven off result events | TB-04 |
| TB-06 | `p0-06-temperament-spawner-loop` | Cursor + Claude Code CLI | Temperament tells, trivial spawner, swappable loss, playtest log | TB-05 |

**After TB-06 the Phase 0 exit playtest is runnable** (`MIRTH_METER_SPEC.md` §6 /
`HUMOR_SYSTEM.md` §7 GATE). That playtest is a `playtest_agent` job, not in this batch.

---

## Two invariant sets every brief enforces

### A. Design-choice independence (this is the whole point)
Nothing here bakes in an unresolved decision. Everything below stays **data or a toggle**:

- **Affinity values** (`HUMOR_SYSTEM` §5/§7) → inspector data on `AffinityTableSO`. Seeded
  with the §7 subset as *tunable defaults*, not a lock.
- **Discrete `{Strong/Neutral/Weak}` vs floats** (Q2) → `AffinityResult` carries an unused
  `multiplier` field; flip to floats by editing data, not code.
- **Which "fill ≠ HP" mechanic carries the fun** (`MIRTH_METER` §3, Q1) → `bombingEnabled`,
  `decayEnabled`+`decayRate` are booleans/floats on `MirthConfigSO`. Combo/priming left as an
  interface seam (Layer B, OFF, not built).
- **Player-loss model** (Q4) → `ILossCondition` with a NO-LOSS sandbox default; timer / health /
  heckle are swappable implementations. Nothing committed.
- **Type count / roster** → adding Heart + Tender + Edgelord (`HUMOR_SYSTEM` Layer A) later =
  new SO assets + table rows, **zero** code change.
- **Meter name / defeat term** (Q7) → display-string data, never an identifier.

### B. Co-op-forward seams (build solo, don't foreclose Phase 1)
Honors `DEC-2026-06-29-B` (client-auth movement) **without committing it** — no FishNet installed.

1. **Mirth lives on the ENEMY and is shared.** Any clown's cast contributes. Solo = 1 contributor;
   co-op = N. (`HUMOR_SYSTEM` Layer C recommends shared-per-enemy.) No rearchitecture later.
2. **Casts are events/commands, not direct mutations.** `CastEvent {casterId, jokeType, targetId,
   t}` → resolver. That resolver call site is exactly where a FishNet broadcast slots in.
3. **Ownership abstracted, defaults to local.** An `ownerId` on clown & enemy; solo = local/host
   owns all. Mirrors the Cabal owner-runs-own-clown / host-runs-enemies split with no netcode.
4. **Input → Intent → Apply.** Movement & casting read input into an intent struct that a mover
   applies. A network layer later produces intents from remote input; client-auth stays drop-in.
5. **No player-count singletons.** An `ActorRegistry` supports N; solo registers one. No
   `Player.Instance` assumptions anywhere.
6. **Feedback replays from result events**, so a remote client can re-play a land/bomb from a
   broadcast. No visual logic buried inside a cast method.
7. **A `Clowns.Net` asmdef slot is reserved** (folder + doc, not created). Gameplay compiles with
   zero networking dependency; Phase 1 adds `Net` referencing gameplay, never the reverse.

---

## Non-negotiable guardrails carried in every brief

- **Content model (locked, `DEC-2026-06-29-C`):** NO written / scripted joke, punchline, or comedy
  text anywhere — not in assets, not in code, not in comments, not as placeholder or test data.
  Humor reads only through performance (cadence / animation / action / VFX / SFX). Grey-box feedback
  uses non-text primitives (scale-punch, colour flash, placeholder audio pitch), never strings.
- **Pillar 2 (Read the Room):** the affinity data may never make one humor type Strong against
  every temperament (no universal answer). TB-02 ships an **editor-time validator** that fails the
  asset if any row is all-Strong or strictly dominates. This locks the *invariant*, not the *values*.
- **Scope:** solo grey-box only. No roster, no tour, no progression, no weapon-loot layer
  (`WEAPON_SYSTEM.md` is design-ahead, gated behind this toy). No backend / persistence / accounts.
