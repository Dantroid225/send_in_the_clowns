# DECISIONS.md — Send in the Clowns
# Purpose: Append-only ledger of locked decisions. One entry per decision, dated + numbered.
# Created: 2026-06-30 | Last Modified: 2026-06-30
# Rule: Never edit or delete past entries. If a decision changes, append a NEW entry
#       and add a one-line "SUPERSEDED BY DEC-..." note to the old one.
# Format: DEC-YYYY-MM-DD-<LETTER>

---

## DEC-2026-06-29-A
**Decision:** Co-op shape is Battlerite-style — 1 clown per player, no lanes/economy.
**Reasoning:** Defuses the "moba" scope trap; keeps the protected feature (humor combat) testable solo.
**Owner:** User, confirmed via Mission Control session 2026-06-29.

## DEC-2026-06-29-B
**Decision:** Authority model is client-authoritative (movement) + `NetworkTransform`,
NOT server-authoritative. No Prediction V2 / Replicate-Reconcile.
**Reasoning:** PvE + friends-only means cheating is a non-problem (Pillar 4). Matches the
Cabal precedent. Server-authority would be solving an unneeded problem and would inflate netcode cost.
**Owner:** Mission Control ruling (scaffold) — **confirm or override at next Mission Control review.**
**Load-bearing:** Yes — see `TOOL_ROLES.md` invariants and `CLAUDE.md`. Do not drift toward server authority mid-project.

## DEC-2026-06-29-C
**Decision:** All in-game "jokes" are performed videogame gibberish (Simlish / Animal
Crossing / Undertale-bark style) — never real, written, or scripted comedy. Humor type
reads via cadence, animation, action/prop use, VFX/SFX only.
**Reasoning:** Converts an unscopeable task (write good jokes) into a scopeable one (design
performance signatures); removes localization burden and copyright/IP risk.
**Owner:** User.
**Load-bearing:** Yes — content-pipeline invariant. No written joke/punchline text may exist
anywhere in code, assets, comments, or UI as the primary comedic payload. See `CLAUDE.md`.

## DEC-2026-06-30-D
**Decision:** Repo scaffolded in folder `send_the_clowns` (not `clowns`). Unity project will use
the guide's canonical internal names — `unity/unity_clowns/` with `Assets/_clowns/` as the code root.
**Reasoning:** All concept docs already live in `send_the_clowns`; renaming the folder would break
existing references and the user pointed Claude Code at this folder. Unity-internal canonical names
are kept to match `CLOWNS_PROJECT_SCAFFOLDING_GUIDE.md` §2 and parent CLAUDE_PROJECT_RULES §8.2.
**Owner:** Claude Code CLI (bootstrap) — confirm at next Mission Control review (cosmetic; non-blocking).
