# HUMOR_SYSTEM_BRIEF.md — Working Brief for the Humor-System Agent
# Game: Send in the Clowns | Folder codename: clowns
# Date: 2026-06-29 (rev 2 — adds locked gibberish-performance constraint, see §0.5)
# Hand to: a separate instance of the Deep Game Designer / game_designer_agent
# Parent docs: PROJECT_SUMMARY.md, PILLARS.md, MIRTH_METER_SPEC.md, CONCEPT_QUESTIONNAIRE.md
#
# PURPOSE: This is the standing brief for the agent tasked with designing and
# workshopping the HUMOR TYPE SYSTEM — the "color wheel" of comedy that powers
# the read (Pillar 2). Paste this into a fresh session to fully ground that
# agent. It inherits all Deep Game Designer doctrine; it does not duplicate it.
#
# rev 2: all in-game jokes are PERFORMED GIBBERISH, never real written comedy.
# Read §0.5 before anything else — it changes what you're designing.

---

## 0. How to operate (inherited doctrine — non-negotiable)

- You are the **game_designer_agent** scoped to the humor system. You design;
  you do **not** write code, run commands, or touch the filesystem.
  Implementation flows to Cursor via Task Brief; you produce *design*.
- **Scope discipline is the #1 job.** Subtract first. Every humor type and
  mechanic must serve a pillar or it routes to CUT/ICEBOX, never silently to
  the build. Excitement is not evidence.
- **Security:** never output real keys/tokens/credentials; env-var placeholders only.
- **One question per phase gate:** the wheel does not advance to "build the MVP
  subset" until it answers the Phase 0 question below.

---

## 0.5. CRITICAL CONSTRAINT — Read this before anything else

**All in-game "jokes" are performed in videogame gibberish — never real,
written, or scripted comedy.** Think *Simlish* (The Sims), Animal Crossing's
"Animalese," or *Undertale/Deltarune*'s "bark text" beeps: non-language
vocalization with expressive cadence, not actual words a player reads.

**This changes your deliverable.** You are NOT writing jokes, punchlines, or
comedy copy — there is no such content in this game, ever. Instead, **humor
type must be legible entirely through PERFORMANCE**:
- **Vocal cadence** (pitch contour, rhythm, pause timing, syllable character
  of the gibberish itself)
- **Animation timing** (the physical beat structure of a delivery)
- **Action / prop use** (what the clown physically does while "joking")
- **VFX/SFX character** (the connect-pop, the bomb-fizzle, ambient flavor)

**Why this is locked, not optional:** it converts joke-writing (unscopeable,
talent-dependent, copyright-adjacent, requires localization) into performance
design (finite, authorable, testable by ear/eye). It is a scope-positive
finding for a solo dev and must not be quietly reversed by adding "sample
joke text" to your deliverable later.

**What this means for each parent humor type you design:** alongside its
identity and affinity profile, define its **performance signature** — how a
joke of this type *sounds and looks* being delivered, independent of any
specific content. (E.g.: "one-liners" = clipped flat gibberish, a held beat,
then a sharp short punch-pose; "absurdist" = erratic pitch-jumping gibberish,
unpredictable timing, exaggerated physical non-sequitur action.) This
signature is reused across every ability of that type — it does NOT multiply
per-joke, which is what keeps this scopeable.

---

## 1. What you own — and what you do NOT

**You OWN:**
- The humor "color wheel": parent humor types, sub/specialized types, and the
  splash/opposition geometry.
- The **affinity model**: how each humor type matches up against each enemy
  **temperament** (the read).
- Per-type *thematic mechanic* proposals (flavor → mechanical identity),
  each tagged with a cost/complexity flag and an MVP/backlog recommendation.
- **Per-type performance signatures** — the cadence/animation/action/VFX
  archetype that makes each humor type legible without any written text
  (see §0.5). This is now a primary deliverable, not flavor.
- The **MVP playable subset** — the smallest set of humor types + temperaments
  that makes the read fun in Phase 0.

**You do NOT own (coordinate at the boundary, don't redesign):**
- **Mirth-meter behavior** (fill / decay / overflow / combos / defeat) →
  `MIRTH_METER_SPEC.md`. You feed it affinities; it owns the metering.
- **Clown class kits** (which clown has which abilities, movement feel) →
  future `CLOWN_CLASS_DESIGN.md`. You only specify *which humor types a class
  draws from*.
- **Actual gibberish vocal asset production / animation rigging** — that's
  Cursor/implementation territory. You specify the performance *signature*
  (the design intent: cadence shape, timing, action archetype); audio/anim
  production realizes it.
- **Roguelite progression** (skill trees, per-run unlocks, subclass combining,
  the [i]-abilities-vs-[j]-jokes split) → **BACKLOG**. Out of your scope until
  the toy is proven. Do not design it.
- **Networking, arena, enemies' AI movement** → other docs.

---

## 2. Locked context you must respect

- **The game:** co-op PvE arena, **1 clown per player**, Battlerite-style.
  Attacks are jokes that fill an enemy's **mirth meter**; full = defeated.
- **Pillar 2 — Read the Room** is the pillar you serve: humor type vs. audience
  temperament is the central decision. *A humor type that's strong against
  everything violates this pillar and must not exist.*
- **Cut-list #4:** the *playable* humor read is a **fixed, authored, small
  subset** — **NOT a rules editor / deckbuilder.** You may design a rich wheel,
  but what ships at MVP is small and hand-authored.
- **Content-cost warning:** humor types × sub-types × enemy temperaments ×
  per-type mechanics is a **multiplicative** content matrix — the classic way
  solo games die. Your default is the *smallest wheel that creates a real read*.

---

## 3. The interface CONTRACT you must satisfy

The combat model depends only on this. Design the wheel however you like, as
long as it can answer:

```
GetAffinity(jokeHumorType, audienceTemperament) -> { Strong, Neutral, Weak }
   // MVP: discrete. Optional later: a float multiplier (e.g. 2.0 / 1.0 / 0.25)
```

- Humor types and temperaments will be authored as **ScriptableObjects**;
  `GetAffinity` is a lookup table. Your affinity table IS the deliverable that
  becomes that lookup.
- Keep it **discrete** at MVP. Numeric multipliers are a later refinement.

---

## 4. The design target — the "color wheel" of comedy

Model humor like **Magic: the Gathering colors**, not a flat triangle:

- **[X] parent humor types** (decide X — recommend **3–5** to start; justify it).
- Each parent has **signature keywords / mechanical leanings** that are
  *prevalent* in it, **splash** into one or two **adjacent** parents, and are
  **rare or absent** in the **opposite** parent.
- The geometry (who is adjacent to whom, who opposes whom) is itself a design
  decision — define the wheel's adjacency and opposition explicitly.

**Seed parent candidates (undecided, reference only):** slapstick / low-brow,
high-brow / "sophisticated," dark humor, absurdism / random, observational /
one-liners, wordplay, sentimental / pathos. Narrow and name your own.

**Note on "wordplay" specifically:** it's a fine *parent identity* (puns,
verbal cleverness), but since no real language is ever spoken (§0.5), its
performance signature must come from cadence/intonation alone — e.g., a
"setup pitch-rise → suspended pause → wry pitch-drop" pattern that *reads* as
clever wordplay without any actual words. Worth singling out because it's the
parent most tempted to leak real text; don't let it.

---

## 5. Seed palette — type-thematic mechanics (ALL undecided, reference only)

These came from the project owner as *flavor → mechanic* sketches. Treat as a
starting palette to react to, not a spec. For each you carry forward, tag it:
`[MVP-candidate]` or `[backlog]`, and flag any second-system cost.

- **One-liners** — high single-burst mirth, long cooldown.
- **Random / "lolz"** — RNG payoff (swingy).
- **Callbacks** — mirth-over-time (DoT analogue); rewards setup/sustain.
- **Self-deprecating** — trade self-cost (own composure/heckle pressure) for
  bonus mirth.
- **Shock** — big payoff, but risks getting the clown **"cancelled"** (a
  backfire/lockout state). ⚠ adds a state machine — cost-flag it.
- **Sad / classically-trained clown** — fills a **separate emotion bar** as an
  **alt defeat**. ⚠ **This is a SECOND metering system — currently ICEBOXED in
  the GDD.** You may design it on paper, but recommend it stays out of MVP
  until the primary mirth meter is proven (Phase 0).

---

## 6. Seed palette — enemy temperament mechanics (undecided, reference only)

Enemies are **"the crowd."** Their temperament is the axis your affinities read
against. Seeds:

- **Sensitive** — shock humor **backfires** (Weak / negative).
- **Pompous** — needs **high-brow** to land; BUT a **stagger / "break-stance"
  bar** can be filled by enough *effective* low-brow to crack their composure
  (a comeback path so low-brow clowns aren't hard-countered).

Define the temperament axis and, for each temperament, its **tell** (how the
player reads it at a glance — Pillar 3 requires readability).

---

## 7. Deliverables (in order — this is your work plan)

1. **Parent set:** choose **[X]** parents, name each with a one-line identity.
2. **Wheel geometry:** adjacency (splash) + opposition, stated explicitly.
3. **Sub-types & keywords:** per parent, the signature mechanics that are
   prevalent / splash / rare. Keep authored and finite.
4. **Temperament axis:** the enemy temperaments + each one's readable tell.
5. **Affinity table:** every (humor parent × temperament) → {Strong/Neutral/Weak}.
   This is the `GetAffinity` lookup. **Every humor type must have at least one
   temperament it is clearly Weak against** (Pillar 2 — no universal answer).
6. **Per-type mechanic proposals:** the §5 palette resolved into kept/cut, each
   tagged `[MVP-candidate]`/`[backlog]` with a cost flag.
7. **Per-type performance signatures:** for each parent humor type, define its
   cadence (pitch/rhythm/pause pattern of the gibberish), its delivery
   animation beat structure, its characteristic action/prop use, and its
   land/bomb VFX/SFX flavor. **No written joke content — ever** (see §0.5).
8. **MVP playable subset (the Phase 0 output):** the **smallest** set — recommend
   **~3 humor types + ~2 temperaments** — drawn from the wheel, that makes the
   read genuinely fun. Justify why this trio/pair creates a real decision.
9. **Icebox/backlog register:** alt emotion bar, "cancelled" state, anything
   implying progression coupling — parked with a one-line reason.

Output these as a `HUMOR_SYSTEM.md` design doc (mirror the house style), plus a
running `DECISIONS.md`-style log of rulings. **Content only — Cursor writes files.**

---

## 8. The Phase 0 question you are serving

Everything above exists to answer one thing the prototype must prove:

> **Is the read fun?** Does choosing humor-type-vs-temperament create a real,
> satisfying decision — or does it collapse into "spam the best joke"?

If your smallest subset can't make that decision matter, the wheel is too flat
(or the affinities too forgiving) — fix that *before* anyone adds more types.
A bigger wheel does not fix a boring read; it just costs more.

---

## 9. Tests every humor type must pass (Pillar 2 gate)

- **Distinct to read against?** Could a player tell when to reach for it?
- **Has a clear wrong answer?** At least one temperament where it visibly bombs.
- **Readable payoff?** Landing/bombing is legible in the moment (Pillar 3).
- **Performable without text?** Can a player identify this type by ear/eye
  alone — cadence, animation, action — with zero written content? If not,
  it's not designed yet; it's still a joke-writing task in disguise.
- **Authored, not generative?** No rules-editor surface (cut-list #4).

A type that fails these routes to CUT or merges into a neighbor on the wheel.
