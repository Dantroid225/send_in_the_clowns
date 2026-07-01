# PROJECT_SUMMARY.md — One-Page GDD
# Game: Send in the Clowns (working title — rename freely)
# Folder codename: clowns
# Date: 2026-06-29 (rev 1.2 DRAFT — adds gibberish/bark-text performance model; NOT locked)
# Phase: Concept
# Status: GREENFIELD — reuses the Cabal document scaffold, NOT the Cabal design
# Authored by: Deep Game Designer / game_designer_agent
#
# rev 1.1 NOTE: This revision folds in exploratory concept depth (the humor
# "color wheel," type-thematic mechanics, enemy mechanics, and a Gunfire-Reborn-
# style class/skill-tree/subclass layer). These are VISION, not MVP scope, and
# are explicitly NOT locked. The Phase 0 toy and the 5 pillars are unchanged.
# The deep humor model is handed to a separate agent via HUMOR_SYSTEM_BRIEF.md.
#
# rev 1.2 NOTE — SCOPE-POSITIVE FINDING: all in-game "jokes" are PERFORMED, not
# WRITTEN. Clowns speak in videogame gibberish (Simlish / Animal Crossing /
# Undertale "bark text" style) — no real jokes, punchlines, or scripted comedy
# text exist anywhere in the game. Humor type is communicated entirely through
# PERFORMANCE: vocal cadence, animation timing, action/prop use, and VFX/SFX
# character. This converts "write good jokes" (unscopeable, skill-dependent,
# copyright-adjacent) into "design a cadence/action signature per humor type"
# (a concrete animation + audio design problem). See new section below.

---

## Header

- **Title:** *Send in the Clowns* (working — a clown "troupe" of heroes; rename freely)
- **Elevator pitch:** A top-down co-op arena where you and friends each pilot a clown and *fight with comedy* — performing jokes and gags (in videogame gibberish, not real jokes) to fill an enemy's mirth meter until they're laughing themselves silly, reading each foe's temperament to pick the humor that lands.
- **X-statement:** *Battlerite's* arena combat × a humor "type chart" (a *Magic: the Gathering color-wheel* of comedy), played **co-op vs the AI** — with a *Gunfire Reborn*-style per-run class/skill layer as the eventual roguelite (backlog).
- **Target experience (3 words, PROVISIONAL — lock via CONCEPT_QUESTIONNAIRE.md):** *Read. Riff. Roar.*

---

## Core Loop

Each player pilots one clown (click to move, fire abilities) in a single arena against waves of AI enemies. Your "attacks" are **jokes and gags** — performed entirely in videogame gibberish (no real written comedy; see "Performance Model" below) — that fill the enemy's **mirth meter** instead of dealing damage. Each enemy has a **temperament**; your humor type is strong, weak, or neutral against it — so you read the room, pick the bit that lands, and keep the pressure on until they crack up. Survive the wave with your troupe intact.

---

## Design Pillars (5)

Full definitions and violation examples live in `PILLARS.md` (stamped at folder creation). Named here with their exclusions, because the exclusions are what give the scope agent something to test against:

1. **Comedy Is Combat** — your weapons are jokes; you win by breaking the room, not drawing blood. *Exclusion: rules out HP/damage/gore and any "serious" lethal-violence framing.*
2. **Read the Room** — humor type vs. audience temperament is the central mind-game. *Exclusion: rules out a single dominant attack, a damage race where matchup is irrelevant, and enemies with no temperament/affinity.*
3. **The Bit Lands or Bombs** — timing and feedback make a joke *hit*; comedic payoff is immediate and readable **through performance** (cadence, animation, action — not text). *Exclusion: rules out feedback-less abilities, sluggish input, a meter that fills with no "pop," and any reliance on written punchlines the player has to read.*
4. **Co-op Chaos, Not Competition** — friends vs. the crowd; jank is fine, cheating and balance are non-problems. *Exclusion: rules out PvP, ranked, matchmaking, accounts, anti-cheat spend.*
5. **Every Clown's a Different Act** — each class is a distinct comedic voice tied to humor archetypes, not a stat reskin. *Exclusion: rules out samey kits, palette-swap rosters, and classes that don't change how you read the room.*

**Standing constraint (not a 6th pillar, but load-bearing on all 5):** every "joke" in the game is **performed gibberish** (Simlish/Undertale-bark-style vocalization), never real written comedy. Humor type must therefore be legible from **cadence, animation timing, action/prop use, and VFX/SFX character alone** — see "Performance Model (Gibberish, Not Real Jokes)" below.

**Candidate future pillar (BACKLOG, not launched): "The Tour Is the Run"** — escalating venues/crowds give the eventual roguelite its shape. Parked deliberately: it ranked last on the protect-list and is the first thing to cut. Promote it only after the combat toy proves fun.

---

## Player Experience Goals

- The satisfying beat is **nailing the read**: clocking that the heckler is a po-faced theatre snob, switching to dry one-liners, and watching the meter spike where slapstick was bouncing off.
- Pick up and play with a friend in under a minute — comedic chaos, not a competitive grind.
- A clown going down stings; a wipe is quick to retry. You always want one more set.

---

## Genre / Reference Anchors

| Reference | What this game BORROWS | What it deliberately does NOT borrow |
|---|---|---|
| **Battlerite / Bloodline Champions** | Pure arena combat feel; ability-driven fights; no lanes/creeps/towers/gold; fast pace | PvP focus, competitive balance, large roster, twin-stick aiming |
| **Pokémon type chart** | The strong/weak/neutral **read** as the core decision layer (humor type vs. audience temperament) | Capture, RPG stats, turn-based pace, 18-type sprawl (MVP = a tiny read) |
| **Magic: the Gathering color wheel** | The *deeper* humor model: a few parent humor types, each with signature keywords that **splash** into adjacent types and are **rare/opposite** across the wheel (owned by the humor-system agent) | The full card-game depth; a player-facing deckbuilder; anything that ships beyond a small MVP read |
| **Gunfire Reborn** | Per-run **ability pool** with unlocks; a **skill-tree → subclass** layer (e.g., Auguste → dark-humor tree → tramp/hobo subclass); the idea that your **"weapons" are jokes/gags** (like gun types) that synergize with trees | The FPS loop; the *depth* of its progression at MVP — this whole layer is **BACKLOG**, not the toy |
| **Gauntlet / co-op top-down horde arenas** | Co-op vs AI waves in one arena; short, retryable sets | Dungeon crawling, procedural levels, loot economies |
| **Overcooked / Lovers in a Dangerous Spacetime** | Friends-vs-the-game fellowship; "jank is fine" co-op chaos | The specific cooking/ship-sim verbs; forced cooperation puzzles |
| **League of Legends** | Camera + right-click-to-move + Q/W/E/R layout — *control scheme only* | Lanes, minions, towers, items, gold, leveling, match length, roster |

**Grounding note:** the buildable *toy* is *Battlerite* combat re-skinned so "damage" is laughter, with a *Pokémon-style read* as the brain of the fight, inside a *Gauntlet*-style co-op horde loop. The *MTG color wheel* and the *Gunfire Reborn* class/progression layer describe the **eventual** game — they are vision, deliberately backlogged, and must not leak into Phase 0. Each toy piece is small. League contributes only camera and controls.

---

## Humor System & Enemy Mechanics — Vision (EXPLORATORY, not locked)

> **Ownership:** the deep humor model is handed to a **separate game-dev agent**
> via `HUMOR_SYSTEM_BRIEF.md`. This section is the *gist* only. **MVP cap:** the
> *playable* read stays small (a few types); the wheel is the source the small
> MVP subset is drawn from — not a thing that ships whole. Cut-list item #4
> still holds: a fixed small set, never a rules editor.

**The humor "color wheel" (deeper than a triangle).** Rather than a flat 3-type
triangle, humor is modeled like MTG colors: **[X] parent humor types**, each with
**sub/specialized types**, where signature keywords are *prevalent* in one or two
parents, *splash* into adjacent ones, and are *rare/opposite* across the wheel.
(How many parents X is, and the splash rules, are the humor agent's first
deliverable — see `HUMOR_SYSTEM_BRIEF.md`.)

**Type-thematic mechanics (joke flavor → mechanical identity).** Reference
seeds only, all undecided:
- *One-liners* — high single-burst mirth, long cooldown.
- *Random / "lolz"* — RNG payoff.
- *Callbacks* — damage-over-time (mirth-over-time).
- *Self-deprecating* — trade self-cost (own composure/heckle) for extra mirth.
- *Shock* — big payoff but risks getting the clown "**cancelled**" (a backfire state).
- *Sad / classically-trained clown* — fills a **separate emotion bar** as an
  **alt defeat** condition. ⚠ *This is a SECOND metering system — see Cut List.*

**Enemy mechanics (the crowd reads back).** Reference seeds only:
- *Sensitive* enemy — shock humor **backfires**.
- *Pompous* enemy — needs **high-brow** humor; but a **stagger / "break-stance" bar**
  can be filled by enough *effective* low-brow to crack their composure.

**Scope discipline for this whole section:** every item above is a *source of
ability and enemy variety*, which is exactly where content cost multiplies. MVP
draws a **tiny subset** (a few jokes, ~2 enemy temperaments). The richness is the
humor agent's design space and the post-toy backlog — not the Phase 0 build.

---

## Performance Model — Gibberish, Not Real Jokes (LOCKED CONSTRAINT)

> **This is a scope-positive finding, not flavor.** It changes what "writing
> a joke" means for this game and should be treated as load-bearing on
> Pillars 1, 3, and 5, and on the humor-system agent's deliverables.

**The rule:** no clown or enemy ever speaks real, written jokes, punchlines, or
scripted comedy text. All vocalization is **videogame gibberish** — non-language
utterance in the tradition of *Simlish* (The Sims), *Animal Crossing*'s
"Animalese," and *Undertale/Deltarune*'s "bark text" beeps. There is no
joke-writing task anywhere in this project's content pipeline.

**What carries the comedy instead:** humor TYPE is communicated entirely through
**performance**, not content:
- **Vocal cadence** — pitch contour, rhythm, pause-before-punchline timing,
  pitch of the "gibberish" syllables (e.g., a one-liner's gibberish is clipped
  and flat; an absurdist bit's gibberish is erratic and pitch-jumpy).
- **Animation timing** — the physical beat structure of a delivery (setup pose
  → held beat → punch pose), distinct per humor type.
- **Action / prop use** — slapstick gibberish pairs with a physical bit (prop
  mishandling, a pratfall); high-brow gibberish pairs with a composed gesture
  (a raised eyebrow, an adjusted monocle); dark humor pairs with a deadpan stare.
- **VFX/SFX character** — the "joke connects" pop, the "bomb" silence/fizzle,
  and ambient sound design per type (a slide-whistle flavor vs. a dry rimshot
  vs. a discordant sting).

**Why this is good scope news:**
- **Removes the unscopeable task.** "Write N hilarious jokes per humor type per
  clown" is replaced by "design M cadence/action signatures per humor type" —
  finite, authorable, and testable by ear/eye rather than by comedic taste.
- **Removes localization entirely.** Gibberish needs no translation (a scope
  trap CLAUDE_PROJECT_RULES flags explicitly for any real text).
- **Removes copyright/IP risk.** No real jokes means no risk of inadvertently
  reproducing existing comedy material.
- **Reframes narrative_agent's job** from joke-writing (low odds of success for
  a solo dev) to **bark-cadence and performance-beat design** (a concrete,
  scopeable deliverable — see `narrative_agent` routing below).

**What this requires instead (the new content surface):**
- A small library of **gibberish vocal phonemes/syllable sets** per humor
  type (likely a sound-design/audio task, not writing).
- A **cadence signature** per humor type (rhythm/timing pattern — reusable
  across all jokes of that type, so it does NOT multiply per-joke).
- A **delivery animation beat** per humor type, shared across abilities of
  that type (same scope-saving logic: type-level, not joke-level).
- Readable **land/bomb feedback** (Pillar 3) independent of any specific
  "joke content," since there isn't any.

**Routing implication:** `narrative_agent` is retasked from dialogue/joke
copy to **bark-cadence and performance-beat design** for this project. The
humor-system agent's deliverable also changes: instead of (or alongside)
naming actual jokes, it should define each humor type's **performance
signature** (cadence + action archetype), which is what actually needs to
feel distinct per Pillar 2/3 — see `HUMOR_SYSTEM_BRIEF.md`.

---

## Out of Scope From Day 1 (Cut List)

> **Moved to standing ledgers (single-source rule).** The full cut list was split out of this
> GDD at repo bootstrap (2026-06-30) so scope is tracked in one authoritative place, not buried
> in the concept doc. This section now points to those ledgers rather than duplicating them:
>
> - **[CUT.md](CUT.md)** — PvP (C-1), MOBA economy (C-2), matchmaking/accounts/servers/anti-cheat
>   (C-3), the deep humor-rules editor (C-4), minimap/spectator/reconnect (C-5), and the
>   **permanent** cut of written/scripted jokes (C-6, per the Performance Model + DEC-2026-06-29-C).
> - **[BACKLOG.md](BACKLOG.md)** — the roguelite tour (B-1), the Gunfire-Reborn progression layer
>   (B-2), large rosters (B-3), procedural gen / between-run meta (B-4). Parked, not killed.
> - **[ICEBOX.md](ICEBOX.md)** — the alt "emotion bar" defeat / sad-clown second meter (I-1),
>   with a review-or-kill default.
>
> If a ledger and this GDD ever disagree, the **ledger wins** for scope status.

---

## MDA Notes

**The central design tension (this toy's #1 risk): "Is the read the fun?"**
- *Aesthetic intended:* the delight of skillful comedy — **you** matter, because you clocked the room and chose the bit that lands.
- *Dynamic:* read the enemy's temperament → pick the humor type that's strong against it → sustain pressure to the breaking point.
- *Mechanic:* jokes fill a mirth meter, **modulated by a humor-type affinity multiplier** (see `MIRTH_METER_SPEC.md`).
- *The knife-edge:* a fill-meter is only more than a reskinned HP bar if the **read** (and tempo/overflow) creates a real decision. If any humor type beats anything, or if matchup is invisible/irrelevant, the system **collapses into a damage race** and the toy fails. Finding that the read is genuinely fun is the make-or-break question of the prototype — see `PHASE_PLAN.md`, Phase 0 exit criterion.

**Resolved by the 1-clown-per-player ruling:** the earlier multi-hero/APM concern (Cabal's autonomy band) does not apply — there is no squad to juggle. The aesthetic lands on **Challenge/Expression** (the matchup read) layered on **Fellowship** (co-op) and **Sensation** (a bit landing with a satisfying pop). Keep LoL only for camera/controls.

---

## Tech Stack Summary

- **Engine:** Unity LTS (frozen per project)
- **Render pipeline:** URP (2D / low-poly stylized 3D default — placeholder grey-box until the toy proves fun)
- **Architecture:** ScriptableObject-based (Ryan Hipple) — **abilities, humor types/sub-types, and per-type mechanics as SO data**, so the wheel and its affinities are inspector-tunable. (A skill-tree/progression layer would be a *separate, backlogged* system — not built until the toy proves out.)
- **Networking:** FishNet — host/listen server; client-authoritative movement + `NetworkTransform`; PvE means cheating is irrelevant, so no server-authority spend. **(Phase 1 — recommended gated behind the solo Phase 0 toy; see scope ruling in chat / PHASE_PLAN.md.)**
- **Movement / pathfinding:** Unity NavMesh — owner runs *its own clown's* agent; host runs *enemy* agents (same ownership split as Cabal, but simpler: one clown per player, no stance FSM)
- **Implementation:** Cursor via Task Brief; live Blender (if any 3D) via Claude Desktop

---

## Open Design Questions (first prototype questions)

1. **Is the read the fun?** Does humor-type-vs-temperament create a real, satisfying decision, or does it collapse into a damage race? (The Phase 0 make-or-break.)
2. **What makes "fill" differ from "deplete HP"?** Does the mirth meter need **decay**, **overflow/"bombing"**, or **setup→punchline combos** to feel distinct? (See `MIRTH_METER_SPEC.md`.)
3. **How many humor types at MVP?** A small read (~3), or does it want more? And how many **parent types [X]** does the full wheel have? (Owned by the humor-system agent via `HUMOR_SYSTEM_BRIEF.md`; seeded in `CONCEPT_QUESTIONNAIRE.md`.)
4. **Do type-thematic mechanics earn their keep at MVP,** or is a flat affinity read enough to prove the toy? (Risk: per-type mechanics multiply ability content.)
5. **Co-op shape:** shared mirth pressure on a single enemy, or per-player? Does "friendly heckling" (comedic friendly-fire) add fun or noise?
6. **Progression layer (BACKLOG):** if/when the roguelite earns its place — is it the **[i] class abilities vs. [j] jokes/gags** split, and do skill trees combine into subclasses? (Do not design until the toy passes Phase 0.)
7. **What's the defeat term?** "In stitches" / "laughing themselves silly" / "corpsing" / "rolling." (Flavor — narrative_agent, low priority.)
8. **Cadence/performance signatures:** how many distinct cadence+action signatures are needed at MVP — one per humor type (recommend: yes, 1:1), or can some types share a signature with a variant? (Performance Model — narrative_agent + humor-system agent.)

---

## Toy-Before-Game Check

**The toy (one sentence):** *Pilot one clown and land jokes on a single heckler to fill their mirth meter until they're in stitches — reading the heckler's temperament to pick the humor that lands.*

Strips out networking, the tour, and most of the roster. **Crucial doctrine note:** the toy check here is *not* "does the combat feel good" in the abstract — it's "**is the humor-type read a fun decision?**" Because of that, the **triangle is plausibly part of the toy, not decoration**: if the combat is only fun *with* a minimal 2–3 type read, then Phase 0 must include that read. If a single optimal joke wins every fight, the core doesn't work and the design pivots before a line of netcode is written.

---

## Phase 1 (Concept) Exit Note

This GDD satisfies the Concept-phase exit criterion **except**:
- `PILLARS.md` — drafted alongside this; stamp into its own file at folder creation. ✓ (drafted)
- **3-word target experience** — provisional ("Read. Riff. Roar."); lock via `CONCEPT_QUESTIONNAIRE.md` Q1.
- Reference moodboard — outstanding, low priority for a grey-box toy.

Otherwise met: elevator pitch ✓, X-statement ✓, 5 locked pillars ✓, one-page GDD ✓, cut list ✓.

**Scope-integrity note (rev 1.1):** the original pitch stacked four scope traps; the user's answers cut the tour to backlog, capped the roster, defused "moba," and protected the combat + read. Rev 1.1 then *added back* real depth — a humor color wheel, type-thematic mechanics, enemy mechanics, and a Gunfire-Reborn-style class/progression layer. **None of it enters MVP.** The wheel becomes the humor agent's design space (small MVP subset only); the progression layer is backlog; the alt emotion bar is iceboxed. The Phase 0 toy and its one question — *is the read fun?* — are unchanged. This is the scope-honest way to hold a big vision without letting it eat the toy.
