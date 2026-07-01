# PROJECT_FILE_MAP.md — Send in the Clowns
# Purpose: Exhaustive map of the repo's directories and load-bearing files, with what
#          each is for. Complements INDEX.md (which indexes _docs content only).
# Created: 2026-06-30 | Last Modified: 2026-06-30
# Status: LIVING — update in the same change set when a directory or key file is added/moved.

---

```
send_the_clowns/                          ← repo root (folder codename: "clowns")
│
├── README.md                             ← public-facing description + doc pointers
├── PROJECT_CONTEXT.md                    ← cold-start block — paste into ANY tool
├── CLAUDE.md                             ← Claude Code CLI project rules (auto-loads)
├── .gitignore, .gitattributes            ← VCS config (LFS declared for post-MVP binaries)
├── files.zip                             ← original upload bundle (git-ignored)
│
├── .claude/                              ← Claude Code only
│   ├── settings.local.json               ← local Claude Code settings (pre-existing)
│   └── commands/                         ← slash-commands (empty; .gitkeep)
│
├── .cursor/                              ← Cursor-only rules
│   └── rules/                            ← (empty; .gitkeep)
│
├── _docs/                                ← single source for ALL design + status  → see INDEX.md
│   ├── INDEX.md                          ← START HERE (thin pointer index)
│   ├── PROJECT_STATUS.md                 ← phase/scope source of truth (LIVING)
│   ├── PILLARS.md                        ← the 5 pillars + gibberish constraint (LOCKED rev 1)
│   ├── ONE_PAGE_GDD.md                   ← one-page GDD (DRAFT rev 1.2; was PROJECT_SUMMARY.md)
│   ├── DECISIONS.md                      ← append-only decision ledger
│   ├── BACKLOG.md / CUT.md / ICEBOX.md / DONE.md   ← scope ledgers (split from the GDD)
│   ├── TOOL_ROLES.md                     ← three-surface duty split + invariants (STABLE)
│   ├── PROJECT_FILE_MAP.md               ← this file
│   ├── design/
│   │   └── MIRTH_METER_SPEC.md           ← core combat model (DRAFT — review+lock)
│   ├── brainstorms/
│   │   ├── CONCEPT_QUESTIONNAIRE.md      ← standing elicitation tool (LIVING)
│   │   ├── HUMOR_SYSTEM_BRIEF.md         ← brief for humor-system agent (ACTIVE HANDOFF)
│   │   └── HUMOR_TYPE_RESEARCH.md        ← comedy-typology reference
│   ├── architecture/
│   │   ├── PHASE_PLAN.md                 ← STUB — pending Phase 0 boundary confirm
│   │   └── PH1_NETWORKING_AND_COOP.md    ← STUB — slot reserved; write at Phase 1
│   ├── references/                       ← moodboard / visual refs (empty; .gitkeep)
│   ├── sessions/                         ← immutable troubleshooting snapshots (empty; .gitkeep)
│   └── archive/                          ← superseded/one-time docs + deprecation README
│       ├── README.md                     ← deprecation notes
│       ├── CLOWNS_PROJECT_SCAFFOLDING_GUIDE.md   ← the bootstrap brief (job done)
│       └── HUMOR_SYSTEM_HANDOFF_PROMPT.md         ← one-time handoff artifact
│
├── _task_briefs/                         ← Task Brief lifecycle (parent doctrine §7 + Deep Tide refinement)
│   ├── active/
│   │   ├── verification_pending/         ← awaiting USER playtest/confirmation
│   │   └── Handoff/                      ← cross-surface handoff records
│   ├── complete/                         ← all verification steps passed
│   └── failed/                           ← with notes appended
│
├── blender/                              ← placeholder only, post-MVP (grey-box until toy proves fun)
│   ├── exports/ · refs/ · sessions/      ← all empty (.gitkeep)
│
└── unity/
    ├── UNITY_CONTEXT.md                  ← Unity-specific cold-start (STUB — no project yet)
    └── (unity_clowns/)                   ← NOT YET CREATED — Phase 0 build work, gated. When
                                             created: URP project root, Assets/_clowns/ code root,
                                             its own subtree CLAUDE.md.
```

## Notes
- **No `backend/`, `infra/`, or `.secrets/`** — cut at bootstrap (scaffolding §1). No accounts/
  persistence/matchmaking at MVP, so nothing to serve.
- **`HANDOFF_PHASE0-PHASE1.md`** (repo root) is the bootstrap → Phase 0/1 handoff report. If present
  at root, it is a living pointer for whoever picks up the build next.
