# INDEX.md — Send in the Clowns
# Purpose: Thin pointer index — START HERE. Titles, one-line hooks, status flags only.
# Created: 2026-06-30 | Last Modified: 2026-06-30
# Rule: This file never duplicates content (single-source rule). Any doc added,
#       moved, or status-changed is reflected here in the SAME change set
#       (change-sync rule). If INDEX and a doc disagree, the doc wins.

> **Folder codename:** `clowns` · **Repo folder:** `send_the_clowns` · **Phase:** 0 (Concept)
> Status flags: `LOCKED` · `LIVING` · `DRAFT` · `STABLE` · `REFERENCE` · `STUB` · `ARCHIVED`

---

## Foundational (`_docs/` root)
- [PROJECT_STATUS.md](PROJECT_STATUS.md) — phase/scope source of truth. **LIVING.**
- [PILLARS.md](PILLARS.md) — the 5 pillars + the gibberish-performance constraint. **LOCKED** (rev 1, pending user reconfirm).
- [ONE_PAGE_GDD.md](ONE_PAGE_GDD.md) — concept, loop, references, MDA. **DRAFT rev 1.2 — NOT YET LOCKED.**
- [DECISIONS.md](DECISIONS.md) — dated decision ledger. **LIVING, append-only.**
- [BACKLOG.md](BACKLOG.md) — parked-not-killed scope, with promotion conditions. **LIVING.**
- [CUT.md](CUT.md) — out-of-scope / permanently cut, with the pillar that cuts it. **LIVING.**
- [ICEBOX.md](ICEBOX.md) — parked with review-or-kill defaults. **LIVING.**
- [DONE.md](DONE.md) — shipped/closed scope. **LIVING** (empty until Phase 0 work lands).
- [TOOL_ROLES.md](TOOL_ROLES.md) — three-surface duty split + load-bearing invariants. **STABLE.**
- [PROJECT_FILE_MAP.md](PROJECT_FILE_MAP.md) — exhaustive repo file/dir map. **LIVING.**

## Design (`design/`)
- [MIRTH_METER_SPEC.md](design/MIRTH_METER_SPEC.md) — core combat model (the toy). **DRAFT — review+lock at claude.ai.**

## Brainstorms (`brainstorms/`)
- [CONCEPT_QUESTIONNAIRE.md](brainstorms/CONCEPT_QUESTIONNAIRE.md) — standing elicitation tool. **PARTIALLY ANSWERED / LIVING.**
- [HUMOR_SYSTEM_BRIEF.md](brainstorms/HUMOR_SYSTEM_BRIEF.md) — brief for the humor-system agent. **ACTIVE HANDOFF.**
- [HUMOR_TYPE_RESEARCH.md](brainstorms/HUMOR_TYPE_RESEARCH.md) — comedy-typology reference. **REFERENCE.**

## Architecture (`architecture/`)
- [PHASE_PLAN.md](architecture/PHASE_PLAN.md) — phase boundaries + Phase 0 exit criterion. **STUB — pending Phase 0 boundary confirm.**
- [PH1_NETWORKING_AND_COOP.md](architecture/PH1_NETWORKING_AND_COOP.md) — FishNet/co-op reference. **STUB — write at Phase 1 kickoff (slot reserved).**

## References (`references/`)
- _(empty)_ — moodboard / clown & crowd visual refs outstanding (low priority for grey-box). **LIVING.**

## Sessions (`sessions/`)
- _(empty)_ — immutable troubleshooting snapshots; opt-in context, never auto-read. Habit starts Phase 1. **LIVING.**

## Archive (`archive/`)
- [CLOWNS_PROJECT_SCAFFOLDING_GUIDE.md](archive/CLOWNS_PROJECT_SCAFFOLDING_GUIDE.md) — the bootstrap brief this repo was built from. **ARCHIVED** (job done).
- [HUMOR_SYSTEM_HANDOFF_PROMPT.md](archive/HUMOR_SYSTEM_HANDOFF_PROMPT.md) — one-time handoff artifact; fold outcomes into DECISIONS.md. **ARCHIVED.**

---

## Repo-root pointers (outside `_docs/`)
- [README.md](../README.md) — public-facing description + doc pointers.
- [PROJECT_CONTEXT.md](../PROJECT_CONTEXT.md) — cold-start block (paste into any tool).
- [CLAUDE.md](../CLAUDE.md) — Claude Code CLI project rules (auto-loads).
- [unity/UNITY_CONTEXT.md](../unity/UNITY_CONTEXT.md) — Unity-specific cold-start. **STUB** (no Unity project until Phase 0).
