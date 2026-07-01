# CLAUDE.md — Send in the Clowns (project rules)
# Purpose: Claude Code CLI project rules for this repo. Auto-loads when cwd is here.
#          Supplements (does not replace) the workspace-level D:\Deez_Projects\CLAUDE.md.
# Created: 2026-06-30 | Last Modified: 2026-06-30
# Related: _docs/TOOL_ROLES.md, _docs/DECISIONS.md, _docs/PROJECT_STATUS.md

---

## Auto-imported context (read these first, every session)
@_docs/PROJECT_STATUS.md
@_docs/DECISIONS.md

> If the `@` imports above don't resolve in your harness, open them manually:
> `_docs/PROJECT_STATUS.md` (phase/next/blockers) and `_docs/DECISIONS.md` (locked decisions).
> For fuller orientation: `_docs/INDEX.md` → START HERE. For cold start: `PROJECT_CONTEXT.md`.

---

## 1. Identity of this repo
**Send in the Clowns** — co-op-vs-AI comedy arena game. Codename `clowns`; repo folder
`send_the_clowns`. **Phase 0 (Concept).** No game logic and no Unity project exist yet — the
Unity project is Phase 0 build work, gated on the Phase 0 boundary confirmation still owed from
Mission Control (see `_docs/PROJECT_STATUS.md` blockers). **Do not scaffold a Unity project until
that gate clears.**

## 2. Your role here (Claude Code CLI = Implementation Agent)
You **execute**, you do not **decide design**. See `_docs/TOOL_ROLES.md`.
- **You own:** `unity/unity_clowns/Assets/_clowns/` code (once it exists), `_docs/` edits (proposed +
  change-synced with code), `.claude/`, scripts, git ops, Task Brief execution without live Editor control.
- **You do NOT:** make architecture/design/scope decisions; manipulate the live Unity Editor (that's
  Cursor + Unity MCP).
- **Ambiguous or design-shaped?** Stop and escalate: *"This needs a decision from claude.ai — pausing here."*

## 3. LOAD-BEARING INVARIANTS (violating these is a hard error)

### 3.1 Authority-model invariant — DEC-2026-06-29-B
Movement is **client-authoritative + `NetworkTransform`**. **Never** introduce server-authoritative
movement, Prediction V2, or Replicate/Reconcile. PvE + friends-only makes cheating a non-problem
(Pillar 4); server authority would solve a problem this game does not have and inflate netcode cost.
This is the Clowns equivalent of Deep Tide's "server authority invariant" — protect it in every
review, PR, and Task Brief.

### 3.2 Gibberish-performance invariant — DEC-2026-06-29-C
**No real, written, or scripted joke / punchline / comedy text may exist anywhere** — not in code,
strings, ScriptableObject data, assets, comments, commit messages, or UI — as the primary comedic
payload. All in-game humor is **performed gibberish** (Simlish / Animal Crossing / Undertale-bark
style); humor TYPE reads through cadence, animation timing, action/prop use, and VFX/SFX only.
If a Task Brief or feature asks you to author joke copy, **stop and flag it** — that's a permanent
cut (`_docs/CUT.md` C-6), not a task.

### 3.3 The read is the toy — Pillar 2
Never implement anything that makes one humor type universally best, or that makes the humor-type-
vs-temperament matchup invisible/irrelevant. That collapses the toy into a damage race and fails the
Phase 0 exit criterion. If a change would do this, flag it rather than shipping it.

## 4. Scope discipline
Everything in `_docs/CUT.md` (permanent), `_docs/BACKLOG.md` (parked), and `_docs/ICEBOX.md` (frozen)
stays out of Phase 0. The MTG color-wheel humor depth and the Gunfire-Reborn progression layer are
**vision, not MVP** — they must not leak into Phase 0 code. MVP = 2 clown classes, 1–2 enemy
temperaments, a few humor types.

## 5. Conventions (inherit workspace CLAUDE.md; project specifics)
- **Shell:** PowerShell. **Paths:** backslashes in code, forward slashes in `.md`/`.gitignore`.
- **C#:** PascalCase types/methods; `_camelCase` private fields; XML docs on public members; URP;
  ScriptableObject-based architecture (Ryan Hipple pattern) — abilities and humor types as SO data.
- **Docs:** every file gets a header (title / purpose / created+modified / related). `_docs/` is the
  single source of truth. **Change-sync rule:** any doc added/moved/status-changed updates
  `_docs/INDEX.md` in the SAME change set. Never delete docs — archive to `_docs/archive/` with a note.
- **Task Briefs:** `_task_briefs/active/` → `verification_pending/` (USER playtest owed) →
  `complete/` | `failed/`. Read a brief fully before starting; never reinterpret — flag ambiguity and stop.
- **Git:** commit only when asked; `main` = stable. Confirm `.env`/secrets are gitignored before any
  git op. Never commit credentials. (No backend at MVP, so no secrets yet.)

## 6. After every session
Update `_docs/PROJECT_STATUS.md` (phase / last action / next / blockers), even for partial sessions.
