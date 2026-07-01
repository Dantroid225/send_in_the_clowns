# CONCEPT_QUESTIONNAIRE.md — Build-Out Questionnaire
# Game: Send in the Clowns
# Folder codename: clowns
# Date: 2026-06-29 (rev 2 — gibberish-performance constraint added)
# Authored by: Deep Game Designer / game_designer_agent
#
# PURPOSE: A standing set of design-elicitation questions to develop the concept
# from "locked core" toward a buildable Phase 0 spec. Answer top-down; later
# sections depend on earlier ones. Bring answers back into a session and the
# relevant doc gets updated. Sections marked [HUMOR-SYSTEM AGENT] are owned by
# the separate humor-system agent — seeded here only so the combat model stays
# compatible.

---

## Already locked (do not re-litigate without a reason)
- Co-op PvE arena, **1 clown per player**, Battlerite-style. No lanes/economy.
- Protected: **humor-meter combat (#1) + humor-type wheel (#2)**.
- Roguelite tour → **BACKLOG** (first to cut).
- Networking → **recommended Phase 1**, behind a solo Phase 0 toy. *(Pending your confirm.)*
- **All dialogue/jokes are performed videogame gibberish** (Simlish/Undertale-
  bark style) — never real written comedy. Humor type reads via cadence,
  animation, action, and VFX/SFX only. See `PROJECT_SUMMARY.md` "Performance
  Model" and `HUMOR_SYSTEM_BRIEF.md` §0.5.

---

## §1 — Identity & Feeling (game_designer_agent)
1. **Lock the 3-word target experience.** Push it to a *feeling*, not a verb.
   Candidates: "Read. Riff. Roar." / "Tickle. Outwit. Together." / something yours.
2. Describe the single funniest *moment* you imagine a player having. (This is
   the beat the whole toy should manufacture.)
3. Is the tone **affectionate/whimsical** (Pierrot pathos, gentle slapstick) or
   **anarchic/mean** (roast battles, dark humor)? This steers art, **performance
   design (cadence/animation — all dialogue is gibberish, no written copy; see
   PROJECT_SUMMARY.md "Performance Model")**, and the wheel's flavor.
3a. Standing reminder (not a question to answer, just a check): every "joke" is
    performed gibberish (Simlish/Undertale-bark style), never real text. Any
    answer above that implies written comedy should be reframed as a
    performance/cadence answer instead.

## §2 — The Mirth Mechanic (game_designer_agent → MIRTH_METER_SPEC.md)
4. Of the four "fill ≠ HP" levers, which do you *expect* to carry the fun:
   the read, bombing/overflow, decay/tempo, or setup→punchline combos?
   (Phase 0 confirms — this just sets the build order.)
5. Does mirth **decay** when you stop landing jokes, or only ever rise?
6. Player **loss condition** for Phase 0: heckle-meter, a small classic health
   pool, or survive-the-wave timer? (Pick the simplest that creates tension.)
7. Defeat term + meter name (flavor; can defer to narrative_agent):
   "in stitches" / "laughing themselves silly" / "corpsing" / "rolling" / ______.

## §3 — The Humor System / Wheel [HUMOR-SYSTEM AGENT owns; seed only]
8. How many humor types at MVP — ~3, or more? (Scope: small + fixed.)
9. Candidate type names (e.g., slapstick, dry one-liners, dark humor, absurdism,
   wordplay, physical/prop). Which 3 feel most *distinct* to read against?
10. Should the player **see** the matchup (a "super-effective!" tell) or **learn**
    it by feel? (Readability vs. discovery — affects Pillars 2 & 3.)
11. Confirm the interface: discrete **Strong/Neutral/Weak**, or numeric multipliers?
12. **Performance check:** for each candidate type, can you describe its cadence
    and physical delivery beat in one line, with zero written joke content?
    (Required — see HUMOR_SYSTEM_BRIEF.md §0.5. If you can't describe it without
    text, the type isn't designed yet.)

## §4 — Clown Classes / Roster (game_designer_agent → CLOWN_CLASS_DESIGN.md)
13. Which **2** clown archetypes ship first? (tramp / Pierrot / jester / Auguste /
    other.) Each must map to humor types so the class changes *what you read for*.
14. For each of the 2: its comedic voice in one line, and its primary humor type(s).
15. Does class also change *movement/feel* (e.g., a nimble jester vs. a lumbering
    tramp), or only the joke kit? (Scope: kit-only is cheaper.)

## §5 — The Audience / Enemies (game_designer_agent → AUDIENCE_DESIGN.md)
16. Enemies are "**the crowd**." How many **temperaments** at MVP (1–2)? Name them
    (e.g., the snob, the softie, the rowdy drunk) — each is a wheel axis.
17. What's a temperament's *tell*? (How does the player read it at a glance?)
18. One enemy behavior verb beyond "approach + heckle"? (Keep to ~1; variety is backlog.)

## §6 — Co-op Shape (game_designer_agent; technical follows)
19. Target player count for the MVP co-op (recommend **2** first; 3–4 is backlog).
20. Shared mirth pressure on a single enemy, or independent? (Affects whether
    teammates **combo** on one target — a strong fellowship beat.)
21. Comedic "friendly heckling" between players: fun, or noise? (Default: cut.)

## §7 — The Tour [BACKLOG — parked, answer later]
22. (Later) Venue list and the *crowd identity* of each (open mic / rodeo / theatre).
23. (Later) What carries between sets — nothing, your clown, or a light meta?
24. (Later) Boss = a single famous "headliner" act with a unique temperament?

---

## How to use this
- Answer **§1–§2 next session** → they finalize the GDD and the Phase 0 toy spec.
- **§3** goes to the humor-system agent in parallel.
- **§4–§6** unlock the full Phase 0 / Phase 1 build once the toy direction is set.
- **§7** stays parked until the combat toy passes its Phase 0 exit criterion.
