# CLOWNS_PROJECT_SCAFFOLDING_GUIDE.md
# Purpose: Hand this to Claude Code to bootstrap the "Send in the Clowns"
#          implementation repo. Defines repo layout, doc organization, task
#          lifecycle, decision/status tracking, and tool-surface routing —
#          adapted from the deep_tide_game repo's proven structure, sized
#          down for Clowns' actual scope.
# Created: 2026-06-29
# Authored by: Deep Game Designer / Mission Control
# Reference (structure only, NOT design): deep_tide_game's README.md,
#   PROJECT_CONTEXT.md, INDEX.md, TOOL_ROLES.md, PH1_NETWORKING_AND_MULTIPLAYER.md
# Parent doctrine: CLAUDE_PROJECT_RULES.md §5 (file structure), §7 (Task Brief
#   protocol), §9 (tool routing) — this scaffold is an evolution of §5, not a
#   replacement; deltas are called out explicitly below.

---

## 0. How to use this document

This is a **bootstrap brief** — Claude Code should read it in full, then create
the directory structure and seed files described in §13 ("First Bootstrap Task").
Everything before that section is the *reasoning and conventions* that make the
bootstrap sensible; everything in §13 is the literal action list.

**Scope-honesty note up front:** this scaffold borrows deep_tide_game's
*process* (doc organization, indexing, task lifecycle, decision ledgers) almost
wholesale — that part is genuinely battle-tested and worth reusing. It does
**not** borrow deep_tide_game's *technology weight* (server-authoritative
netcode, ASP.NET backend, Supabase, Docker, Seq). See §1 for the comparison
and the reasoning behind each cut.

---

## 1. Structural comparison — what transfers, what doesn't

| Deep Tide element | Transfers to Clowns? | Reasoning |
|---|---|---|
| `_docs/` root + `design/` + `brainstorms/` + `architecture/` + `sessions/` + `archive/` subfolders | **YES — adopt wholesale** | Proven doc organization; scales down fine to a smaller project. |
| `INDEX.md` thin-pointer index | **YES — adopt wholesale** | Single-screen orientation is valuable at any project size, and cheap to maintain. |
| Task Brief lifecycle (`active/` → `complete/` \| `failed/`, `verification_pending/`, `Handoff/`) | **YES — adopt wholesale** | Already implied by parent CLAUDE_PROJECT_RULES §7; Deep Tide's subfolder lifecycle is a useful refinement. |
| `DECISIONS.md` append-only ledger (`DEC-YYYY-MM-DD-X`) | **YES — adopt wholesale** | Parent doctrine already requires a decisions log; this is the proven format. |
| `PROJECT_STATUS.md` single source of phase truth | **YES — adopt wholesale** | Already mandated by parent doctrine. |
| `BACKLOG.md` / `CUT.md` / `ICEBOX.md` / `DONE.md` scope ledgers | **YES — adopt wholesale** | Already mandated by parent doctrine §5; content already partially drafted in this session's `PROJECT_SUMMARY.md` cut list — needs splitting out (§12). |
| `TOOL_ROLES.md` four-surface split | **ADAPT, not adopt** | Clowns uses **three** surfaces, not four (see §10). No Blender surface needed at MVP — grey-box only, same as Cabal. |
| `CLAUDE.md` (root + subtree) Claude Code project rules | **YES — adopt, new addition for Clowns** | Parent CLAUDE_PROJECT_RULES never specified Claude Code CLI as a surface; this scaffold adds it on your explicit instruction (see §10.1). |
| Server-authoritative FishNet + Prediction V2 (Replicate/Reconcile) | **NO** | Clowns is PvE + friends-only (Pillar 4: cheating is a non-problem). Client-authoritative movement + `NetworkTransform` is the correct, cheaper pattern — same ruling Cabal already made. Importing server-authority here would solve a problem Clowns doesn't have. |
| `backend/` (ASP.NET Core API), `infra/` (Docker Compose), Supabase, Seq | **NO** | These exist to serve accounts/sessions/persistence/matchmaking — all already CUT in `PROJECT_SUMMARY.md`. Cutting the consumers and keeping the backend would be scope-incoherent. Revisit only if a future locked decision reintroduces persistence. |
| `.secrets/` git-ignored env dir | **NO (for now)** | No backend means nothing to put real secrets in yet. If FishNet ever needs a relay/transport key, re-add then — don't pre-build it. |
| `blender/` asset pipeline dir | **DEFERRED, stub only** | Same as Cabal/Deep Tide pattern: placeholder folders only, real Blender work is post-MVP. |
| Networking reference doc (`PH1_NETWORKING_AND_MULTIPLAYER.md` style) | **YES, but written when Phase 1 lands** | See §11 — stub the *slot* for this doc now so Phase 1 doesn't improvise the pattern, but don't write FishNet specifics before there's a Phase 1 to document. |
| Architecture summary audit doc (`PH1_ARCHITECTURE_SUMMARY.md` style) | **YES, written post-Phase-0** | Same logic — useful once there's an implemented system to audit. |

**The throughline:** Clowns is structurally co-op-first (every doc slot below
exists from day one) without being technologically co-op-heavy before it has
to be (no netcode, no backend, until Phase 1 actually needs them).

---

## 2. Repo root layout

```
clowns/                                   ← repo root = game folder
│                                            (D:\Deez_Projects\projects\games\clowns\)
├── README.md                             ← public-facing description + doc pointers
├── PROJECT_CONTEXT.md                    ← cold-start block (paste-in for any tool)
├── CLAUDE.md                             ← Claude Code project rules (auto-loads)
├── .gitignore, .gitattributes
│
├── .claude/                              ← Claude Code only
│   ├── settings.json
│   └── commands/                         ← slash-commands, if/when adopted
│
├── .cursor/                              ← Cursor-only rules
│   └── rules/
│
├── _docs/                                ← single source for ALL design + status
│   ├── INDEX.md                          ← START HERE
│   ├── PROJECT_STATUS.md
│   ├── PILLARS.md, ONE_PAGE_GDD.md, DECISIONS.md
│   ├── BACKLOG.md, CUT.md, ICEBOX.md, DONE.md
│   ├── TOOL_ROLES.md, PROJECT_FILE_MAP.md
│   ├── design/                           ← locked + draft design specs
│   ├── brainstorms/                      ← explorations, questionnaires (DRAFT by definition)
│   ├── architecture/                     ← binding plans + phase guides (incl. future networking doc)
│   ├── references/                       ← moodboard, visual refs
│   ├── sessions/                         ← immutable troubleshooting snapshots, opt-in context
│   └── archive/                          ← superseded docs, kept with deprecation notices
│
├── _task_briefs/
│   ├── active/
│   │   └── verification_pending/         ← awaiting USER playtest/confirmation
│   ├── complete/
│   └── failed/                           ← with notes
│
├── blender/                              ← placeholder only, post-MVP
│   ├── exports/  (.gitkeep)
│   ├── refs/     (.gitkeep)
│   └── sessions/ (.gitkeep)
│
└── unity/
    ├── UNITY_CONTEXT.md                  ← Unity-specific cold-start
    └── unity_clowns/                     ← Unity LTS URP project root (canonical path)
        ├── CLAUDE.md                     ← Unity-subtree Claude Code rules
        └── Assets/
            └── _clowns/                  ← game-specific code root (per CLAUDE_PROJECT_RULES §8.2)
                └── _docs/
                    └── ai/                ← Unity AI conventions (csharp, netcode, org)
```

**Delta from parent CLAUDE_PROJECT_RULES §5:** the original template puts all
tracking docs flat at game root. This scaffold nests them under `_docs/` with
sub-buckets instead (Deep Tide's evolution). Recommend the Workspace
Infrastructure project eventually bump CLAUDE_PROJECT_RULES to a v2 reflecting
this — that's out of scope for this doc (routes to that project, not here).

---

## 3. `_docs/` bucket table (mirrors Deep Tide's INDEX.md convention)

| Location | Bucket | What belongs here |
|---|---|---|
| `_docs/` (root) | **Foundational** | Status, pillars, decisions, scope ledgers, tool roles. Load-bearing — CLAUDE.md auto-imports several. |
| `_docs/design/` | **Design** | Locked + draft specs: `MIRTH_METER_SPEC.md`, future `CLOWN_CLASS_DESIGN.md`, `AUDIENCE_DESIGN.md`, `HUMOR_SYSTEM.md` (once the humor-system agent delivers it and it's locked). |
| `_docs/brainstorms/` | **Brainstorms & questionnaires** | `CONCEPT_QUESTIONNAIRE.md`, `HUMOR_SYSTEM_BRIEF.md`, `HUMOR_TYPE_RESEARCH.md`. DRAFT by definition until promoted. |
| `_docs/architecture/` | **Architecture & guides** | `PHASE_PLAN.md` (once generated), and — once Phase 1 lands — a `PH1_NETWORKING_AND_MULTIPLAYER.md`-style reference doc (see §11). |
| `_docs/references/` | **Visual references** | Moodboard, clown/crowd visual refs (currently outstanding per `PROJECT_SUMMARY.md`). |
| `_docs/sessions/` | **Session snapshots** | Immutable troubleshooting records (see §9). |
| `_docs/archive/` | **Archive** | Superseded docs, never deleted, deprecation-noted. |

---

## 4. `INDEX.md` — conventions

`INDEX.md` is a **thin pointer index only** — titles, one-line hooks, status
flags (`LOCKED` / `LIVING` / `DRAFT` / `STABLE` / `REFERENCE`). It never
duplicates content (single-source rule). The **change-sync rule** applies:
any doc added, moved, or status-changed gets reflected in `INDEX.md` in the
same change set. If `INDEX.md` and a doc disagree, the doc wins.

Seed entries for Clowns at bootstrap (status flags reflect this session's actual state):

```markdown
## Foundational (root)
- [PROJECT_STATUS.md](PROJECT_STATUS.md) — phase/scope source of truth. LIVING.
- [PILLARS.md](PILLARS.md) — the 5 pillars + the gibberish-performance constraint. LOCKED pending user confirm.
- [ONE_PAGE_GDD.md](ONE_PAGE_GDD.md) — concept, loop, cut list. DRAFT rev 1.2 — NOT YET LOCKED.
- [DECISIONS.md](DECISIONS.md) — dated decision ledger. LIVING, append-only.
- [BACKLOG.md](BACKLOG.md) / [CUT.md](CUT.md) / [ICEBOX.md](ICEBOX.md) / [DONE.md](DONE.md) — scope ledgers. LIVING.
- [TOOL_ROLES.md](TOOL_ROLES.md) — three-surface duty split. STABLE.

## Design (design/)
- [MIRTH_METER_SPEC.md](design/MIRTH_METER_SPEC.md) — core combat model (the toy). DRAFT — review+lock at claude.ai.

## Brainstorms (brainstorms/)
- [CONCEPT_QUESTIONNAIRE.md](brainstorms/CONCEPT_QUESTIONNAIRE.md) — standing elicitation tool. PARTIALLY ANSWERED.
- [HUMOR_SYSTEM_BRIEF.md](brainstorms/HUMOR_SYSTEM_BRIEF.md) — brief for the humor-system agent. ACTIVE HANDOFF.
- [HUMOR_TYPE_RESEARCH.md](brainstorms/HUMOR_TYPE_RESEARCH.md) — comedy-typology reference. REFERENCE.

## Architecture (architecture/)
- [PHASE_PLAN.md](architecture/PHASE_PLAN.md) — NOT YET GENERATED — pending Phase 0 boundary confirm.
```

---

## 5. Task Brief lifecycle

Adopting Deep Tide's lifecycle refinement on top of parent CLAUDE_PROJECT_RULES §7:

```
_task_briefs/
├── active/
│   ├── TASK_BRIEF_YYYY-MM-DD_[short-name].md      ← in-progress
│   └── verification_pending/                       ← USER playtest/confirm owed
├── complete/                                        ← all verification steps passed
└── failed/                                          ← unresolved, notes appended
```

**Lifecycle rule:** a brief moves from `active/` → `active/verification_pending/`
when implementation is done but a USER playtest or confirmation gates closing
it (e.g., "does the read feel fun?" — Phase 0's exit criterion is exactly this
kind of gate). It moves to `complete/` only after that confirmation, or to
`failed/` with notes if it doesn't pass.

**Naming convention (from parent doctrine, unchanged):**
`TASK_BRIEF_YYYY-MM-DD_[short-name].md`

**Add for Clowns, mirroring Deep Tide's `Handoff/`:** a `_task_briefs/active/Handoff/`
subfolder for cross-surface handoff records — e.g., when the humor-system
agent's deliverable (`HUMOR_SYSTEM.md`) is integrated, or when a Cursor session
hands back to claude.ai with notes that need folding into `DECISIONS.md`.

---

## 6. `DECISIONS.md` — format

Append-only. One entry per locked decision, dated and numbered:

```markdown
# DECISIONS.md — Send in the Clowns
# Append-only. Never edit or delete past entries — supersede with a new entry
# and a note on the old one if a decision changes.

## DEC-2026-06-29-A
**Decision:** Co-op shape is Battlerite-style — 1 clown per player, no lanes/economy.
**Reasoning:** Defuses the "moba" scope trap; keeps the protected feature (humor combat) testable solo.
**Owner:** User, confirmed via Mission Control session 2026-06-29.

## DEC-2026-06-29-B
**Decision:** Authority model is client-authoritative (movement) + NetworkTransform,
NOT server-authoritative. No Prediction V2/Replicate-Reconcile.
**Reasoning:** PvE + friends-only means cheating is a non-problem (Pillar 4). Matches
the Cabal precedent. Server-authority would be solving an unneeded problem.
**Owner:** Mission Control ruling, this scaffold — confirm or override.

## DEC-2026-06-29-C
**Decision:** All in-game "jokes" are performed videogame gibberish (Simlish/
Undertale-bark style) — never real written comedy. Humor type reads via cadence,
animation, action, VFX/SFX only.
**Reasoning:** Converts an unscopeable task (write good jokes) into a scopeable one
(design performance signatures); removes localization and copyright risk.
**Owner:** User.
```

---

## 7. `PROJECT_STATUS.md` — format

Single source of truth for current phase. Mirrors Deep Tide's `PROJECT_CONTEXT.md`
"Current state" block but lives as its own living doc per parent doctrine:

```markdown
# PROJECT_STATUS.md — Send in the Clowns

Phase: 0 — Concept (pre-Phase-0-build) — 🟡 IN PROGRESS
Last session: 2026-06-29
Last action: GDD rev 1.2 drafted (gibberish-performance constraint added);
             HUMOR_SYSTEM_BRIEF.md handed to separate agent instance; this
             scaffolding guide drafted.
Next: (1) confirm Phase 0 boundary (solo toy first, FishNet Phase 1) — OWED;
      (2) lock PILLARS.md + ONE_PAGE_GDD.md; (3) integrate humor-system agent's
      HUMOR_SYSTEM.md once delivered; (4) generate PHASE_PLAN.md.

## Open questions / blockers
- USER: confirm Phase 0 boundary (Mission Control recommends solo-first; see chat).
- Humor-system agent: HUMOR_SYSTEM.md not yet delivered.
- 3-word target experience still provisional ("Read. Riff. Roar.").
```

---

## 8. Scope ledgers — `BACKLOG.md` / `CUT.md` / `ICEBOX.md` / `DONE.md`

Already partially populated by content embedded in this session's
`PROJECT_SUMMARY.md` "Out of Scope From Day 1" section. At bootstrap, **split
that content out** into proper standing files rather than leaving it buried in
the GDD (the GDD should *reference* these, not duplicate them, per the
single-source rule):

- `CUT.md` — items #1, #2, #6 (matchmaking/accounts/anti-cheat), #11 (written
  jokes — **permanent cut**, not revisitable) from the current cut list.
- `BACKLOG.md` — the roguelite tour (#3), the Gunfire-Reborn progression layer
  (#5), large rosters (#7) — each with the pillar/reason it's parked, not killed.
- `ICEBOX.md` — the alt "emotion bar" defeat condition (#6 in the rev-1.2 list)
  — parked with its 6-week-ish review-or-kill default per parent doctrine §3.5.
- `DONE.md` — starts empty; first entries land once Phase 0 work begins.

---

## 9. Session snapshots — `_docs/sessions/`

Adopt Deep Tide's pattern exactly: **immutable troubleshooting records, opt-in
context only** (never auto-read at session start — referenced explicitly when
relevant). Naming: `SESSION_YYYY-MM-DD_[topic].md`.

This matters more than it looks like for a co-op project: networking bugs
(desync, late-join state, ownership mistakes) are exactly the kind of thing
worth a permanent dated record rather than a transient chat. Start the habit
from Phase 1 onward, even though Phase 0 (solo) won't generate many of these.

---

## 10. Tool roles — three surfaces, not four

Clowns doesn't need a Unity-MCP-via-Cursor split documented separately from
Claude Code the way Deep Tide does (Deep Tide's four-surface split exists
partly because of its much larger live-Editor workload). Recommend three:

| Surface | Role | Owns | Never does |
|---|---|---|---|
| **claude.ai Projects** (Mission Control) | Plans, locks pillars/decisions, authors Task Briefs, phase-gate reviews | `_docs/` content proposals, `DECISIONS.md` entries (drafted, user-locked), Task Brief authorship | Write files, run commands, issue any MCP call |
| **Claude Code CLI** | Implementation: code/file writes, scripts, doc audits, refactors, git ops, Task Brief execution without live Unity control | `unity/unity_clowns/Assets/_clowns/` code, `_docs/` edits (proposed, change-synced with code), `.claude/` | Architecture/design/scope decisions; live Unity Editor manipulation |
| **Cursor + Unity MCP** | Live Unity Editor control, scene/prefab/component wiring, interactive Play Mode debugging | `.cursor/` config, real-time scene/asset/component operations | Planning, architecture decisions, Task Brief authorship |

### 10.1 Why Claude Code CLI is being added here (delta from parent doctrine)

Parent CLAUDE_PROJECT_RULES §9 only routes implementation to **Cursor**. This
scaffold adds **Claude Code CLI** as a second implementation surface,
following the Deep Tide precedent, per this session's explicit instruction
("to pass to claude code"). Routing call, mirroring Deep Tide's:

- Pure C# / script work, doc audits, refactors, git ops, no live-Editor
  verification needed → **Claude Code**
- Anything requiring clicking through the Editor (GameObjects, prefabs,
  scenes, materials, components) → **Cursor + Unity MCP**
- Ambiguous → escalate to claude.ai rather than guess (same rule as Deep Tide)

**Recommend flagging this addition to the Workspace Infrastructure project** —
if Claude Code CLI becomes a standing surface for Clowns, the workspace-level
three-tool architecture doc (and possibly CLAUDE_PROJECT_RULES §9) should be
updated to reflect a fourth general-purpose surface, not just a Clowns-local
exception. That update is out of scope for this document.

---

## 11. Networking reference doc — stub now, write at Phase 1

Don't write FishNet specifics yet — there's no Phase 1 implementation to
document. But reserve the slot now so Phase 1 doesn't improvise the pattern.

**At Phase 1 kickoff, create** `_docs/architecture/PH1_NETWORKING_AND_COOP.md`
(naming mirrors Deep Tide's `PH1_NETWORKING_AND_MULTIPLAYER.md`) covering, at
minimum:

- FishNet version pinned + transport choice (confirm against current FishNet
  docs at implementation time — Cabal's PROJECT_INSTRUCTIONS already flags this).
- **Client-authoritative movement + `NetworkTransform`** — the chosen pattern
  (per DEC-2026-06-29-B), stated explicitly so it isn't accidentally drifted
  toward server-authority/Prediction V2 mid-project.
- The SyncVar inventory (mirth meter value, defeat state, any per-clown state
  that needs to mirror to both clients) — same table format as Deep Tide's §1.2.
- ServerRpc/ObserversRpc usage for ability activation (per `MIRTH_METER_SPEC.md`
  §4's `GetAffinity` contract crossing the network boundary).
- Connection flow: host/join, session code or direct-IP (2-player MVP — no
  matchmaking, per the cut list).
- Late-join behavior (likely simpler than Deep Tide's, since Clowns' MVP is
  probably not designed around mid-run joins — confirm against
  `CONCEPT_QUESTIONNAIRE.md` §6 once answered).
- A table of load-bearing invariants ("must not break"), mirroring Deep Tide §5
  — e.g., "humor-type SO data is never mutated at runtime," "the mirth meter
  is only written server-side," etc., once those systems exist.

**This is the concrete, structural way "co-op is a priority" gets honored**:
the doc slot, the table format, and the invariant-tracking habit are ready
before Phase 1 starts, even though Phase 0 itself stays solo.

---

## 12. Migration map — where this session's drafted docs land

| Drafted this session | Lands at (post-bootstrap) | Notes |
|---|---|---|
| `PROJECT_SUMMARY.md` | `_docs/ONE_PAGE_GDD.md` | **Rename on migration** — `ONE_PAGE_GDD.md` is the established convention (parent CLAUDE_PROJECT_RULES §5 *and* Deep Tide both use this name; `PROJECT_SUMMARY.md` was this session's working title only). |
| `PILLARS.md` | `_docs/PILLARS.md` | No rename — already matches convention. |
| `MIRTH_METER_SPEC.md` | `_docs/design/MIRTH_METER_SPEC.md` | DRAFT until reviewed+locked. |
| `CONCEPT_QUESTIONNAIRE.md` | `_docs/brainstorms/CONCEPT_QUESTIONNAIRE.md` | Living — keep answering top-down. |
| `HUMOR_SYSTEM_BRIEF.md` | `_docs/brainstorms/HUMOR_SYSTEM_BRIEF.md` | Promote to `_docs/design/HUMOR_SYSTEM.md` once the humor-system agent's deliverable is locked. |
| `HUMOR_TYPE_RESEARCH.md` | `_docs/brainstorms/HUMOR_TYPE_RESEARCH.md` | Reference-only, stays here. |
| `HUMOR_SYSTEM_HANDOFF_PROMPT.md` | Not migrated as a standing doc | One-time handoff artifact — fold any resulting decisions into `DECISIONS.md` instead. |
| (cut list, currently inside `PROJECT_SUMMARY.md`) | Split into `_docs/CUT.md`, `_docs/BACKLOG.md`, `_docs/ICEBOX.md` | See §8 — don't leave this buried in the GDD. |
| This document | `_docs/architecture/` or repo root (one-time bootstrap reference) | Optionally archive to `_docs/archive/` once the structure exists and this doc's job is done. |

---

## 13. First Bootstrap Task (literal action list for Claude Code)

This is the executable portion. Treat it like a Task Brief per parent
CLAUDE_PROJECT_RULES §7.2, scoped to repo scaffolding only — no game logic.

### Prerequisites
- [ ] Confirm target path: `D:\Deez_Projects\projects\games\clowns\`
- [ ] Confirm Unity LTS version to freeze (not yet chosen — ask if unset)
- [ ] Confirm GitHub repo name (suggest `send-in-the-clowns`, unconfirmed)

### Steps
1. Create the directory tree from §2.
2. Create `.gitkeep` placeholders in empty dirs (`blender/exports/`,
   `blender/refs/`, `blender/sessions/`).
3. Create `_docs/INDEX.md` seeded with §4's entries.
4. Create `_docs/PROJECT_STATUS.md` seeded with §7's content.
5. Create `_docs/DECISIONS.md` seeded with the three entries in §6.
6. Create `_docs/BACKLOG.md`, `_docs/CUT.md`, `_docs/ICEBOX.md`, `_docs/DONE.md`
   (empty `DONE.md`; the other three seeded per §8's split instructions —
   pull the actual content from the `PROJECT_SUMMARY.md` cut list provided
   alongside this brief).
7. Create `_docs/TOOL_ROLES.md` from §10's table.
8. Migrate the six drafted docs per §12's table (rename `PROJECT_SUMMARY.md` →
   `ONE_PAGE_GDD.md` on move).
9. Create root `README.md` and `PROJECT_CONTEXT.md`, mirroring Deep Tide's
   structure/tone (see uploaded reference docs) but reflecting Clowns' actual
   current state (Concept phase, solo grey-box toy not yet started).
10. Create root `CLAUDE.md` — Claude Code project rules. At minimum: point to
    `_docs/PROJECT_STATUS.md` and `_docs/DECISIONS.md` as auto-imported
    context; state the authority-model invariant (DEC-2026-06-29-B) as a
    load-bearing rule equivalent to Deep Tide's "server authority invariant"
    section in `TOOL_ROLES.md`; state the gibberish-performance constraint
    (DEC-2026-06-29-C) as a content-pipeline invariant (no written joke
    content anywhere in code, assets, or comments).
11. `git init`, initial commit: "Bootstrap: clowns repo structure + concept docs."
12. **Do not** create `unity/unity_clowns/` as a real Unity project yet —
    that's Phase 0 build work, gated on the Phase 0 boundary confirmation
    that's still owed from Mission Control (see `PROJECT_STATUS.md` blockers).
    Stub the folder with just `UNITY_CONTEXT.md` for now.

### Verification
- [ ] `_docs/INDEX.md` lists every file actually present (no orphans, no
      missing entries — change-sync rule applies from the first commit).
- [ ] `DECISIONS.md` entries match what's stated in this scaffold.
- [ ] No `backend/`, `infra/`, or `.secrets/` directories were created (§1 ruling).
- [ ] No real Unity project was initialized (step 12).

### Report back
On completion, report: directory tree as created, any deviations from this
brief (and why), and confirm the three open blockers from `PROJECT_STATUS.md`
are still accurately listed for Mission Control to act on next.
